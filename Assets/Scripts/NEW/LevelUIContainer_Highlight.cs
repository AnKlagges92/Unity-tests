using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public partial class LevelUIController : BaseUIController<LevelUIController.Parts>
    {
        public partial class Parts : BaseParts
        {
            public Parts(LevelTextsUIPart levelText, GameObjectUIPart highlight = null)
            {
                LevelText = NullCheck(levelText);
                Highlight = highlight;
            }
        }
    }

    public class LevelUIContainer_Highlight : LevelUIContainer_Text
    {
        [SerializeField] private GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts(_levelText, _highlight);
        }
    }
}