﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is an OPTIONAL extension
    /// [EXAMPLE]
    /// </summary>
    public partial class LevelUIController : BaseUIController<LevelUIController.Parts>
    {
        public partial class Parts : BaseParts
        {
            public Parts(LevelTextsUIPart levelText, ImageUIPart icon = null)
            {
                LevelText = NullCheck(levelText);
                Icon = icon;
            }
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Icon : LevelUIContainer_Text
    {
        [SerializeField] private ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts(_levelText, _icon);
        }
    }
}