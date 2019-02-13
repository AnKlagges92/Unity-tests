using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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

    [Serializable]
    public class GameObjectUIPart : BaseUIPart
    {
        public GameObject gameObject;

        public void SetActive(bool enable)
        {
            SafeAction(gameObject, () => gameObject.SetActive(enable));
        }
    }

    [Serializable]
    public class TextUIPart : BaseUIPart
    {
        public Text text;

        public void SetText(object format, params object[] args)
        {
            string value = string.Format(format.ToString(), args);
            SafeAction(text, () => text.text = value);
        }

        public void SetText(object value)
        {
            SafeAction(text, () => text.text = value.ToString());
        }

        public void SetColor(Color value)
        {
            SafeAction(text, () => text.color = value);
        }
    }

    [Serializable]
    public class ImageUIPart : BaseUIPart
    {
        public Image image;

        public void SetSprite(Sprite sprite)
        {
            SafeAction(image, () => image.sprite = sprite);
        }
    }
}