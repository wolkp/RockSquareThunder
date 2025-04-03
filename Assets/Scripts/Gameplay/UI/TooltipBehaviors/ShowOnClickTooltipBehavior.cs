using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{
    [CreateAssetMenu(menuName = "UI/TooltipBehaviors/ShowOnClick")]
    public class ShowOnClickTooltipBehavior : TooltipBehavior
    {
        public override void OnPointerClick(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            base.OnPointerClick(tooltipPopup, dataProvider, position);
            tooltipPopup.ShowTooltip(position);
        }
    }
}
