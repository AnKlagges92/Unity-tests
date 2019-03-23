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
        [SerializeField] private bool _initOnStart;

        protected LevelUIController _levelController;

        protected void Start()
        {
            if (_initOnStart)
            {
                Init();
            }
        }

        public void Init()
        {
            _levelController = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }

        public abstract LevelUIController.Parts GetParts();
    }
}