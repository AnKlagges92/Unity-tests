using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_alt_alt_alt
{
    public enum EBaseUIAction
    {
        SetActive = 0,
        SetImage = 1,
        SetText = 2,
        TOTAL = 3
    }

    public abstract class BaseUIPart
    {
        #region Generic Actions

        public virtual bool CanHandleAction<T>(T action) { return false; }
        public virtual bool HandleAction<T>(T action, params object[] parameters)
        {
            if (action.Equals(EBaseUIAction.SetActive))
            {
                SetActive((bool)parameters[0]);
            }
            else if (action.Equals(EBaseUIAction.SetText))
            {
                SetText((string)parameters[0]);
            }
            else if (action.Equals(EBaseUIAction.SetImage))
            {
                SetImage((Sprite)parameters[0]);
            }
            else
            {
                Debug.LogWarning("Action not being handled: " + action);
                return false;
            }
            return true;
        }

        public virtual void SetActive(bool enable) { }
        public virtual void SetText(string text) { }
        public virtual void SetImage(Sprite sprite) { }

        #endregion

        #region Utils

        protected void SetActive(GameObject component, bool enable)
        {
            SafeAction(component, () => component.SetActive(enable));
        }

        protected void SetText(Text component, string text)
        {
            SafeAction(component, () => component.text = text);
        }

        protected void SetSprite(Image component, Sprite sprite)
        {
            SafeAction(component, () => component.sprite = sprite);
        }

        protected void SafeAction<T>(T component, Action callback)
        {
            if (component != null)
            {
                callback();
            }
        }

        #endregion
    }

    [Serializable]
    public class GameObjectUIPart : BaseUIPart
    {
        public GameObject gameObject;

        public override bool CanHandleAction<T>(T action)
        {
            return action.Equals(EBaseUIAction.SetActive);
        }

        public override void SetActive(bool enable)
        {
            SetActive(gameObject, enable);
        }
    }

    [Serializable]
    public class TextUIPart : BaseUIPart
    {
        public Text text;

        public override bool CanHandleAction<T>(T action)
        {
            return action.Equals(EBaseUIAction.SetText);
        }

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

        public override bool CanHandleAction<T>(T action)
        {
            return action.Equals(EBaseUIAction.SetImage);
        }

        public override void SetImage(Sprite sprite)
        {
            SetSprite(image, sprite);
        }
    }

    public abstract class BaseUIController<TAction> where TAction : Enum
    {
        private BaseUIPart[] _parts;
        private Dictionary<int, List<BaseUIPart>> _actionToParts = new Dictionary<int, List<BaseUIPart>>();

        protected abstract int ActionsCount { get; }
        protected abstract int GetActionAsInt(TAction action);
        protected abstract TAction GetActionByIndex(int index);

        public BaseUIController(params BaseUIPart[] parts)
        {
            _parts = parts;
            foreach (var part in parts)
            {
                for (int i = 0; i < ActionsCount; i++)
                {
                    var action = GetActionByIndex(i);
                    if (part.CanHandleAction(action))
                    {
                        int actionAsInt = GetActionAsInt(action);
                        if (!_actionToParts.ContainsKey(actionAsInt))
                        {
                            _actionToParts[actionAsInt] = new List<BaseUIPart>(1);
                        }
                        _actionToParts[actionAsInt].Add(part);
                    }
                }
            }
        }

        protected void HandleAction(TAction action, params object[] parameters)
        {
            int actionAsInt = GetActionAsInt(action);
            var parts = GetPartsFor(actionAsInt);
            if (parts.Count == 0)
            {
                Debug.LogWarning("Action not being handled: " + action);
            }

            foreach (var part in parts)
            {
                part.HandleAction(action, parameters);
            }
        }

        protected void HandleAction(EBaseUIAction action, params object[] parameters)
        {
            var parts = GetPartsFor((int)action);
            if (parts.Count == 0)
            {
                Debug.LogWarning("Basic action not being handled: " + action);
            }

            foreach (var part in parts)
            {
                part.HandleAction(action, parameters);
            }
        }

        private List<BaseUIPart> GetPartsFor(int action)
        {
            if (_actionToParts.TryGetValue(action, out List<BaseUIPart> parts))
            {
                return parts;
            }
            return new List<BaseUIPart>();
        }

        #region Actions

        public void SetImage(Sprite sprite)
        {
            if (sprite == null) return;

            HandleAction(EBaseUIAction.SetImage, sprite);
        }

        public void SetText(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            HandleAction(EBaseUIAction.SetText, text);
        }

        public void SetActive(bool enable)
        {
            HandleAction(EBaseUIAction.SetActive, enable);
        }

        #endregion
    }
}