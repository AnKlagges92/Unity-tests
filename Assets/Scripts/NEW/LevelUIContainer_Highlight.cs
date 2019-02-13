using System.Collections;
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
            public Parts(LevelTextsUIPart levelText, GameObjectUIPart highlight = null)
            {
                LevelText = NullCheck(levelText);
                Highlight = highlight;
            }
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Highlight : LevelUIContainer_Text
    {
        [SerializeField] private GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts(_levelText, _highlight);
        }
    }
}