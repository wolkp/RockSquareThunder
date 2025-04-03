using System.Collections.Generic;
using System.Linq;
using System;

namespace Unity.BossRoom.Gameplay.Actions
{
    public class ActionTooltipFormatter
    {
        private readonly ActionConfig _actionConfig;

        private readonly Dictionary<string, Func<ActionConfig, string>> PropertyMappings = new()
    {
        { "Power",  actionConfig => actionConfig.Amount > 0    ? $"Power: {actionConfig.Amount}" : null },
        { "Mana",   actionConfig => actionConfig.ManaCost > 0  ? $"Mana: {actionConfig.ManaCost}" : null },
        { "Range",  actionConfig => actionConfig.Range > 0     ? $"Range:  {actionConfig.Range}" : null }
    };

        public ActionTooltipFormatter(ActionConfig actionConfig)
        {
            _actionConfig = actionConfig;
        }

        /// <summary>
        /// Get a formatted string with relevant information about the action.
        /// </summary>
        public string GetFormattedTooltipText()
        {
            var result = string.Join("\n", PropertyMappings.Values
                .Select(formatter => formatter(_actionConfig))
                .Where(formattedText => formattedText != null));

            return result;
        }
    }
}
