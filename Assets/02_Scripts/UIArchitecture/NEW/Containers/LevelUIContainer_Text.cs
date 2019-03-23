using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Text : BaseLevelUIContainer
    {
        [SerializeField] protected LevelTextsUIPart _levelText;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = null,
                Icon = null
            };
        }
    }
}