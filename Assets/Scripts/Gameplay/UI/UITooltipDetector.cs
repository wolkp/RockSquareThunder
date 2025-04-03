using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Unity.BossRoom.Gameplay.UI
{
    /// <summary>
    /// Detects hover events and triggers corresponding methods in TooltipController.
    /// </summary>
    /// <remarks>
    /// Having trouble getting the tooltips to show up? The event-handlers use physics raycasting, so make sure:
    /// - the main camera in the scene has a PhysicsRaycaster component
    /// - if you're attaching this to a UI element such as an Image, make sure you check the "Raycast Target" checkbox
    /// </remarks>
    public class UITooltipDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        [Tooltip("The actual TooltipController that should be triggered")]
        private UITooltipController m_TooltipController;

        [SerializeField]
        [Tooltip("Provider of tooltip data. This field can be left empty when not providing dynamic data")]
        private UITooltipDataProvider m_TooltipDataProvider;

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_TooltipController.OnPointerEnter(m_TooltipDataProvider, transform.position);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_TooltipController.OnPointerClick(m_TooltipDataProvider, transform.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_TooltipController.OnPointerExit(m_TooltipDataProvider);
        }

        public void SetDataProvider(UITooltipDataProvider tooltipDataProvider)
        {
            m_TooltipDataProvider = tooltipDataProvider;
        }
    }
}
