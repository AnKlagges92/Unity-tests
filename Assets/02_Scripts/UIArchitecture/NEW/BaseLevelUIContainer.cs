using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is an OPTIONAL BASE container
    /// [EXAMPLE]
    /// </summary>
    public abstract class BaseLevelUIContainer : MonoBehaviour
    {
        protected LevelUIController _levelController;

        protected void Start()
        {
            InitLevelController();
        }

        protected void InitLevelController()
        {
            _levelController = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }

        public abstract LevelUIController.Parts GetParts();
    }
}