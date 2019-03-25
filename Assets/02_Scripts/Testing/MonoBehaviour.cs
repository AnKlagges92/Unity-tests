using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Testing
{
    public abstract class MonoBehaviour : UnityEngine.MonoBehaviour
    {
        [ContextMenu("Test All", true)]
        private bool Test_ValidateTestAll()
        {
            return Test_ValidateTestFields() || Test_ValidateTestMethods();
        }

        [ContextMenu("Test All", false)]
        private bool Test_TestAll()
        {
            bool passed = true;
            passed &= Test_TestFields();
            passed &= Test_TestMethods();
            return passed;
        }

        [ContextMenu("1- Test Fields", true)]
        private bool Test_ValidateTestFields()
        {
            var testUtils = new TestUtils(this);
            return Test_GetFields(testUtils).Count > 0;
        }

        [ContextMenu("1- Test Fields", false)]
        private bool Test_TestFields()
        {
            var testUtils = new TestUtils(this);
            var fields = Test_GetFields(testUtils);
            testUtils.SetupFields(fields.ToArray());
            return testUtils.Test_Fields();
        }

        [ContextMenu("2- Test Methods", true)]
        private bool Test_ValidateTestMethods()
        {
            var testUtils = new TestUtils(this);
            return Test_GetMethods(testUtils).Count > 0;
        }

        [ContextMenu("2- Test Methods", false)]
        private bool Test_TestMethods()
        {
            var testUtils = new TestUtils(this);
            var methods = Test_GetMethods(testUtils);
            testUtils.SetupMethods(methods.ToArray());
            return testUtils.Test_Methods();
        }

        /// <summary>
        /// Get the fields that will be tested during TestFields()
        /// </summary>
        private List<BaseField> Test_GetFields(TestUtils testUtils)
        {
            MonoBehaviour[] scriptComponents = GetComponents<MonoBehaviour>();

            List<BaseField> fields = new List<BaseField>();
            foreach (MonoBehaviour mono in scriptComponents)
            {
                var monoType = mono.GetType();
                foreach (var field in monoType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    var attributes = field.GetCustomAttributes(typeof(TestingFieldAttribute), true);
                    if (attributes.Length > 0)
                    {
                        if (field.GetValue(mono) is UnityEngine.Object)
                        {
                            var testField = new BaseField<UnityEngine.Object>(field.Name, (UnityEngine.Object)field.GetValue(mono));
                            fields.Add(testField);
                        }
                    }
                }
            }
            return fields;
        }

        /// <summary>
        /// Get the methods that will be tested during TestMethods()
        /// </summary>
        private List<BaseTestMethod> Test_GetMethods(TestUtils testUtils)
        {
            MonoBehaviour[] scriptComponents = GetComponents<MonoBehaviour>();

            List<BaseTestMethod> methods = new List<BaseTestMethod>();
            foreach (MonoBehaviour mono in scriptComponents)
            {
                var monoType = mono.GetType();
                foreach (var method in monoType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    var attributes = method.GetCustomAttributes(typeof(TestingMethodAttribute), true);
                    if (attributes.Length > 0)
                    {
                        var testMethod = new TestMethod(testUtils, method.Name, () => method.Invoke(mono, null));
                        methods.Add(testMethod);
                    }
                }
            }
            return methods;
        }
    }
}
