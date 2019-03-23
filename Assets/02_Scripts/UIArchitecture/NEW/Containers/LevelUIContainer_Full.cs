﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Full : LevelUIContainer_Text
    {
        [SerializeField] protected GameObjectUIPart _highlight;
        [SerializeField] protected ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = _highlight,
                Icon = _icon
            };
        }
    }
}