﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// The UI Parts handle UI components.
    /// This class are semi-stateless, only the components can change.
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
        public GameObject gameObject;

        public void SetActive(bool enable)
        {
            SafeAction(gameObject, () => gameObject.SetActive(enable));
        }
    }

    /// <summary>
    /// Common UI Part that handles a Text
    /// </summary>
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

    /// <summary>
    /// Common UI Part that handles a Image
    /// </summary>
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