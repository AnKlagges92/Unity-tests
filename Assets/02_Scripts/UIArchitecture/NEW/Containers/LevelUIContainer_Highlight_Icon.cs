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
    public class LevelUIContainer_Highlight_Icon : LevelUIContainer_Icon
    {
        [SerializeField] protected GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = null,
                Highlight = _highlight,
                Icon = _icon
            };
        }
    }
}