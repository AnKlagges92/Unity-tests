using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class LevelUIContainer_Full : LevelUIContainer_Text
    {
        [SerializeField] private GameObjectUIPart _highlight;
        [SerializeField] private ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts(_levelText, _icon, _highlight);
        }
    }
}