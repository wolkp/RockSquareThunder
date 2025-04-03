using UnityEngine;
using System;

/// <summary>
/// Provides tooltip data - e.g. formatted text containing name and description of an action.
/// </summary>
public class UITooltipDataProvider : MonoBehaviour
{
    public Func<string> GetTooltipText { get; private set; }

    public void SetTooltipText(Func<string> tooltipTextProvider)
    {
        GetTooltipText = tooltipTextProvider;
    }
}
