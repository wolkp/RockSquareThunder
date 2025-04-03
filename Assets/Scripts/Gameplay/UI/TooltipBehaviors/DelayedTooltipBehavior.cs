using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{
    public abstract class DelayedTooltipBehavior : TooltipBehavior
    {
        [SerializeField]
        private float m_Delay;

        private CancellationTokenSource m_CancellationTokenSource;

        protected abstract void PerformAction(
            UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position);

        public override void OnPointerEnter(
            UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider, Vector3 position)
        {
            base.OnPointerEnter(tooltipPopup, dataProvider, position);

            CancelPreviousTask();
            m_CancellationTokenSource = new CancellationTokenSource();

            StartDelayedAction(tooltipPopup, dataProvider, position, m_CancellationTokenSource.Token).Forget();
        }

        public override void OnPointerExit(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider)
        {
            base.OnPointerExit(tooltipPopup, dataProvider);

            CancelPreviousTask();
        }

        private async UniTask StartDelayedAction(UITooltipPopup tooltipPopup, UITooltipDataProvider dataProvider,
            Vector3 position, CancellationToken cancellationToken)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(m_Delay), cancellationToken: cancellationToken);

            if (!cancellationToken.IsCancellationRequested)
            {
                PerformAction(tooltipPopup, dataProvider, position);
            }
        }

        private void CancelPreviousTask()
        {
            if (m_CancellationTokenSource != null)
            {
                m_CancellationTokenSource.Cancel();
                m_CancellationTokenSource.Dispose();
                m_CancellationTokenSource = null;
            }
        }
    }
}
