using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{
    [CreateAssetMenu(menuName = "UI/TooltipBehaviors/SetText")]
    public class SetTextTooltipBehavior : TooltipBehavior
    {
        [SerializeField]
        [Multiline]
        private string m_TooltipText;

        public override void OnPointerEnter(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            base.OnPointerEnter(tooltipPopup, dataProvider, position);
            tooltipPopup.SetText(m_TooltipText);
        }
    }
}
