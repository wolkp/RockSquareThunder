using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{
    [CreateAssetMenu(menuName = "UI/TooltipBehaviors/SetProvidedText")]
    public class SetProvidedTextTooltipBehavior : TooltipBehavior
    {
        public override void OnPointerEnter(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            base.OnPointerEnter(tooltipPopup, dataProvider, position);
            string providedText = dataProvider.GetTooltipText?.Invoke();
            tooltipPopup.SetText(providedText);
        }
    }
}
