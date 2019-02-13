using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class BaseUIController<T> where T : BaseUIController<T>.BaseParts
    {
        public abstract class BaseParts
        {
            public TPart NullCheck<TPart>(TPart part) where TPart : BaseUIPart
            {
                if (part == null)
                {
                    string controllerName = typeof(T).FullName.Split('+')[0];
                    Debug.LogError("A NULL part was found: '" + typeof(TPart).Name + "' on the controller: " + controllerName);
                }
                return part;
            }
        }

        protected T _parts;

        public BaseUIController(T parts)
        {
            _parts = parts;
        }
    }
}