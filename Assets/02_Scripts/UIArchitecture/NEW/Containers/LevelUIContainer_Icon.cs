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
    public class LevelUIContainer_Icon : BaseLevelUIContainer
    {
        [SerializeField] protected ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = null,
                Highlight = null,
                Icon = _icon
            };
        }
    }
}