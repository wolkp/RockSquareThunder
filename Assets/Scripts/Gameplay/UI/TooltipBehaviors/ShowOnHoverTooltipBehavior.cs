using Cysharp.Threading.Tasks;
using Unity.BossRoom.Gameplay.UI;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "UI/TooltipBehaviors/ShowOnHover")]
public class ShowOnHoverTooltipBehavior : DelayedTooltipBehavior
{
    protected override void PerformAction(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        tooltipPopup.ShowTooltip(position);
    }

    public override void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
    {
        base.OnPointerExit(tooltipPopup, dataProvider);
        tooltipPopup.HideTooltip();
    }
}
