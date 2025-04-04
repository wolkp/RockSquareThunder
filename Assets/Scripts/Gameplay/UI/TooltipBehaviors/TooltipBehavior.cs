using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{
    public abstract class TooltipBehavior : ScriptableObject
    {
        public virtual void OnPointerEnter(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            // Default: Do nothing
        }

        public virtual void OnPointerClick(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            // Default: Do nothing
        }

        public virtual void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
        {
            // Default: Do nothing
        }
    }
}
