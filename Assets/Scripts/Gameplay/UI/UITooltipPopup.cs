using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Unity.BossRoom.Gameplay.UI
{
    /// <summary>
    /// Represents the visual tooltip popup that displays a text blurb when activated. 
    /// It is responsible for displaying the tooltip's content, positioning it on the screen, and hiding it when no longer needed.
    /// </summary>
    public class UITooltipPopup : MonoBehaviour
    {
        [SerializeField]
        private Canvas m_Canvas;
        [SerializeField]
        [Tooltip("This transform is shown/hidden to show/hide the popup box")]
        private GameObject m_WindowRoot;
        [SerializeField]
        private TextMeshProUGUI m_TextField;
        [SerializeField]
        private Vector3 m_CursorOffset;

        private string m_Text;
        private string m_TextFormat = "{0}";

        private void Awake()
        {
            Assert.IsNotNull(m_Canvas);
        }

        /// <summary>
        /// Shows a tooltip at the given mouse coordinates.
        /// </summary>
        public void ShowTooltip(Vector3 screenXy)
        {
            screenXy += m_CursorOffset;
            m_WindowRoot.transform.position = GetCanvasCoords(screenXy);
            m_WindowRoot.SetActive(true);
        }

        /// <summary>
        /// Hides the current tooltip.
        /// </summary>
        public void HideTooltip()
        {
            m_WindowRoot.SetActive(false);
        }

        /// <summary>
        /// Sets the displayed text.
        /// </summary>
        public void SetText(string text)
        {
            m_Text = text;
            UpdateTextField();
        }

        /// <summary>
        /// Sets the format of the displayed text.
        /// Html-esque tags allowed!
        /// </summary>
        public void SetTextFormat(string format)
        {
            m_TextFormat = format;
            UpdateTextField();
        }

        /// <summary>
        /// Updates the text field with the cached text and applied text format
        /// </summary>
        private void UpdateTextField()
        {
            var formattedText = string.Format(m_TextFormat, m_Text);
            m_TextField.text = formattedText;
        }

        /// <summary>
        /// Maps screen coordinates (e.g. Input.mousePosition) to coordinates on our Canvas.
        /// </summary>
        private Vector3 GetCanvasCoords(Vector3 screenCoords)
        {
            Vector2 canvasCoords;

            // To ensure proper position calculation on Overlay Canvases
            Camera canvasCamera = m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : m_Canvas.worldCamera;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                m_Canvas.transform as RectTransform,
                screenCoords,
                canvasCamera,
                out canvasCoords);
            return m_Canvas.transform.TransformPoint(canvasCoords);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (gameObject.scene.rootCount > 1) // Hacky way for checking if this is a scene object or a prefab instance and not a prefab definition.
            {
                if (!m_Canvas)
                {
                    // typically there's only one canvas in the scene, so pick that
                    m_Canvas = FindObjectOfType<Canvas>();
                }
            }
        }
#endif

    }
}
