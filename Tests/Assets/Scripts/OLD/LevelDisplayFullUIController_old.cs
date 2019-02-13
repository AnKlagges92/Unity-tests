using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public class LevelDisplayFullUIController_old : LevelDisplayUIController_old
    {
        [SerializeField]
        private GameObject _highlight;

        public void Highlight(bool enable)
        {
            if (_highlight != null)
            {
                _highlight.SetActive(enable);
            }
        }
    }
}