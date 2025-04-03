using Unity.BossRoom.Gameplay.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/TooltipBehaviors/ToggleInteractable")]
public class ToggleInteractableTooltipBehavior : DelayedTooltipBehavior
{
    public override void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
    {
        base.OnPointerExit(tooltipPopup, dataProvider);
        var canvasGroup = GetCanvasGroup(tooltipPopup.gameObject);
        canvasGroup.interactable = false;
    }

    protected override void PerformAction(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
    {
        var canvasGroup = GetCanvasGroup(tooltipPopup.gameObject);
        canvasGroup.interactable = true;
    }

    private CanvasGroup GetCanvasGroup(GameObject rootObject)
    {
        if (!rootObject.TryGetComponent<CanvasGroup>(out var canvasGroup))
        {
            canvasGroup = rootObject.AddComponent<CanvasGroup>();
        }

        return canvasGroup;
    }
}
