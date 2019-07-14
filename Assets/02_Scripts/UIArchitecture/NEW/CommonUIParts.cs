using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Common UI Part that handles a GameObject
    /// </summary>
    [Serializable]
    public class GameObjectUIPart
    {
        [SerializeField] protected GameObject _gameObject;

        public void SetActive(bool enable)
        {
            if (_gameObject != null)
            {
                _gameObject.SetActive(enable);
            }
        }
    }

    /// <summary>
    /// Common UI Part that handles a Text
    /// </summary>
    [Serializable]
    public class TextUIPart
    {
        [SerializeField] protected Text _text;

        public void SetText(object format, params object[] args)
        {
            if (_text != null)
            {
                string value = string.Format(format.ToString(), args);
                _text.text = value;
            }
        }

        public void SetText(object value)
        {
            if (_text != null)
            {
                _text.text = value.ToString();
            }
        }

        public void SetColor(Color value)
        {
            if (_text != null)
            {
                _text.color = value;
            }
        }
    }

    /// <summary>
    /// Common UI Part that handles a Image
    /// </summary>
    [Serializable]
    public class ImageUIPart
    {
        [SerializeField] protected Image _image;

        public void SetSprite(Sprite sprite)
        {
            if (_image != null)
            {
                _image.sprite = sprite;
            }
        }
    }
}