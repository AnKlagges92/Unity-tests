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
            public Parts(LevelTextsUIPart levelText)
            {
                LevelText = NullCheck(levelText);
            }
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Text : BaseLevelUIContainer
    {
        [SerializeField] protected LevelTextsUIPart _levelText;

        protected LevelUIController _levelController;

        protected void Start()
        {
            _levelController = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts(_levelText);
        }
    }
}