using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Unity.BossRoom.Gameplay.UI
{
    /// <summary>
    /// Manages the logic and behaviors for showing and hiding the tooltip. 
    /// It is responsible for executing tooltip behaviors when triggered by the UITooltipDetector's events.
    [RequireComponent(typeof(UITooltipPopup))]
    public class UITooltipController : MonoBehaviour
    {
        [SerializeField]
        private TooltipBehavior[] m_TooltipBehaviors;

        private UITooltipPopup m_Popup;

        private void Awake()
        {
            Assert.IsNotNull(m_Popup);
        }

        public void OnPointerEnter(UITooltipDataProvider dataProvider, Vector3 position)
        {
            ExecuteOnTooltipBehaviors(b => b.OnPointerEnter(m_Popup, dataProvider, position));
        }

        public void OnPointerClick(UITooltipDataProvider dataProvider, Vector3 position)
        {
            ExecuteOnTooltipBehaviors(b => b.OnPointerClick(m_Popup, dataProvider, position));
        }

        public void OnPointerExit(UITooltipDataProvider dataProvider)
        {
            ExecuteOnTooltipBehaviors(b => b.OnPointerExit(m_Popup, dataProvider));
        }

        private void ExecuteOnTooltipBehaviors(Action<TooltipBehavior> action)
        {
            for (var i = 0; i < m_TooltipBehaviors.Length; i++)
            {
                var behavior = m_TooltipBehaviors[i];
                action?.Invoke(behavior);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!m_Popup)
            {
                m_Popup = GetComponent<UITooltipPopup>();
            }
        }
#endif
    }
}
