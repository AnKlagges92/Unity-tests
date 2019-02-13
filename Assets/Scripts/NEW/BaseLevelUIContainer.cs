using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class BaseLevelUIContainer : MonoBehaviour
    {
        protected LevelUIController _levelController;

        protected void Start()
        {
            _levelController = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }

        public abstract LevelUIController.Parts GetParts();
    }
}