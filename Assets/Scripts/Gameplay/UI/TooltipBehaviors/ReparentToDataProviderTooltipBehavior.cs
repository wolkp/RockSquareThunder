using Unity.BossRoom.Gameplay.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/TooltipBehaviors/ReparentToDataProvider")]
public class ReparentToDataProviderTooltipBehavior : DelayedTooltipBehavior
{
    private Transform m_OriginalParent;

    public override void OnPointerEnter(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        base.OnPointerEnter(tooltipPopup, dataProvider, position);
        m_OriginalParent = tooltipPopup.transform.parent;
    }

    public override void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
    {
        base.OnPointerExit(tooltipPopup, dataProvider);
        tooltipPopup.transform.SetParent(m_OriginalParent, true);
    }

    protected override void PerformAction(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        tooltipPopup.transform.SetParent(dataProvider.transform, true);
        if(tooltipPopup.TryGetComponent<UITooltipDetector>(out var detector))
        {
            var statsProvider = dataProvider.GetComponent<ActionStatsTooltipDataProvider>();
            detector.SetDataProvider(statsProvider);
        }
    }
}
