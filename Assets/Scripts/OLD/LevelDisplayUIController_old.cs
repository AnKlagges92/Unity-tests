using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public class LevelDisplayUIController_old : LevelUIController_old
    {
        [SerializeField]
        private Image _levelIcon;

        public void Setup(Observable<int> level = null, Sprite icon = null)
        {
            base.Setup(level);
            if (_levelIcon != null)
            {
                _levelIcon.sprite = icon;
            }
        }
    }
}