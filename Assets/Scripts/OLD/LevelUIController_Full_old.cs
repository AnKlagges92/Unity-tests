using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public class LevelUIController_Full_old : LevelUIController_old
    {
        [SerializeField]
        private GameObject _highlight;

        [SerializeField]
        private Image _icon;

        public void Setup(Observable<int> level, Sprite icon = null)
        {
            base.Setup(level);
            if (_icon != null)
            {
                _icon.sprite = icon;
            }
        }

        public void Setup(Observable<int> level, Observable<int> maxLevel, Sprite icon = null)
        {
            base.Setup(level, maxLevel);
            if (_icon != null)
            {
                _icon.sprite = icon;
            }
        }

        public void Highlight(bool enable)
        {
            if (_highlight != null)
            {
                _highlight.SetActive(enable);
            }
        }
    }
}