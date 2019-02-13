using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public class LevelUIController_Icon_old : LevelUIController_old
    {
        [SerializeField]
        private Image _icon;

        public void Setup(Observable<int> level = null, Sprite icon = null)
        {
            base.Setup(level);
            if (_icon != null)
            {
                _icon.sprite = icon;
            }
        }
    }
}