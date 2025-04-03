using Unity.BossRoom.Gameplay.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/TooltipBehaviors/FormatText")]
public class FormatTextTooltipBehavior : DelayedTooltipBehavior
{
    [SerializeField]
    [Multiline]
    [Tooltip("Format of a tooltip, where {0} is the original text. Html-esque tags allowed!")]
    private string m_TooltipFormat = "<b>{0}</b>";

    [SerializeField]
    private string m_DefaultFormat = "{0}";

    protected override void PerformAction(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        tooltipPopup.SetTextFormat(m_TooltipFormat);
    }

    public override void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
    {
        base.OnPointerExit(tooltipPopup, dataProvider);
        tooltipPopup.SetTextFormat(m_DefaultFormat);
    }
}
