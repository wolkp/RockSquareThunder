using Cysharp.Threading.Tasks;
using Unity.BossRoom.Gameplay.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/TooltipBehaviors/ShowOnClick")]
public class ShowOnClickTooltipBehavior : TooltipBehavior
{
    public override void OnPointerClick(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        base.OnPointerClick(tooltipPopup, dataProvider, position);
        tooltipPopup.ShowTooltip(position);
    }
}
