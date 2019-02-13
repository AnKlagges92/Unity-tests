using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
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

    public class LevelUIContainer_Base : MonoBehaviour
    {
        [SerializeField] protected LevelTextsUIPart _levelText;

        protected LevelUIController _levelController;

        protected void Start()
        {
            var levelParts = new LevelUIController.Parts(_levelText);
            _levelController = new LevelUIController(levelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }
    }
}