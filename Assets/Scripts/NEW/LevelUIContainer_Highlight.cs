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

    public class LevelUIContainer_Highlight : LevelUIContainer_Base
    {
        [SerializeField] private GameObjectUIPart _levelHighlight;

        protected new void Start()
        {
            var levelParts = new LevelUIController.Parts(_levelText, _levelHighlight);
            _levelController = new LevelUIController(levelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }
    }
}