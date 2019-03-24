using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// The UI Parts handle UI components
    /// The components are serialized. It could contain other related variables (Example: Text format, Localization keys, etc..)
    /// This class is semi-stateless, only the components will change.
    /// The methods from this classes should remain simple and hopefully do one thing
    /// </summary>
    public abstract class BaseUIPart
    {
        protected void SafeAction<T>(T component, Action callback)
        {
            if (component != null)
            {
                callback();
            }
        }
    }

    /// <summary>
    /// Common UI Part that handles a GameObject
    /// </summary>
    [Serializable]
    public class GameObjectUIPart : BaseUIPart
    {
        [SerializeField] protected GameObject _gameObject;

        public void SetActive(bool enable)
        {
            SafeAction(_gameObject, () => _gameObject.SetActive(enable));
        }
    }

    /// <summary>
    /// Common UI Part that handles a Text
    /// </summary>
    [Serializable]
    public class TextUIPart : BaseUIPart
    {
        [SerializeField] protected Text _text;

        public void SetText(object format, params object[] args)
        {
            string value = string.Format(format.ToString(), args);
            SafeAction(_text, () => _text.text = value);
        }

        public void SetText(object value)
        {
            SafeAction(_text, () => _text.text = value.ToString());
        }

        public void SetColor(Color value)
        {
            SafeAction(_text, () => _text.color = value);
        }
    }

    /// <summary>
    /// Common UI Part that handles a Image
    /// </summary>
    [Serializable]
    public class ImageUIPart : BaseUIPart
    {
        [SerializeField] protected Image _image;

        public void SetSprite(Sprite sprite)
        {
            SafeAction(_image, () => _image.sprite = sprite);
        }
    }
}