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
        [SerializeField] private bool _initOnStart = true;

        protected LevelUIController _controller;

        protected void Start()
        {
            if (_initOnStart)
            {
                Init();
            }
        }

        public void Init()
        {
            _controller = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
        }

        public abstract LevelUIController.Parts GetParts();
    }
}