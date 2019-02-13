using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// The UI Controllers handle a single concept
    /// Any number of UI parts can be inyected to manage all UI related aspects
    /// This class can modify internal data and cache external data
    /// </summary>
    /// <typeparam name="T"></typeparam>
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