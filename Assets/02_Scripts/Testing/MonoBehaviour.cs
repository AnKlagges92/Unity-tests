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
        private List<BaseTestClass> Test_GetFields(TestUtils testUtils)
        {
            MonoBehaviour[] scriptComponents = GetComponents<MonoBehaviour>();

            List<BaseTestClass> fields = new List<BaseTestClass>();
            foreach (MonoBehaviour mono in scriptComponents)
            {
                var monoType = mono.GetType();
                foreach (var field in monoType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    var attributes = field.GetCustomAttributes(typeof(TestingFieldAttribute), true);
                    if (attributes.Length > 0)
                    {
                        var fieldValue = field.GetValue(mono) as UnityEngine.Object;
                        var testField = new TestField<UnityEngine.Object>(testUtils, field.Name, fieldValue);
                        fields.Add(testField);
                    }
                }
            }
            return fields;
        }

        /// <summary>
        /// Get the methods that will be tested during TestMethods()
        /// </summary>
        private List<BaseTestClass> Test_GetMethods(TestUtils testUtils)
        {
            MonoBehaviour[] scriptComponents = GetComponents<MonoBehaviour>();

            List<BaseTestClass> testMethods = new List<BaseTestClass>();
            foreach (MonoBehaviour mono in scriptComponents)
            {
                var methods = mono.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(TestingMethodAttribute), true);
                    if (attributes.Length > 0)
                    {
                        ActionTestMethod testMethod = null;

                        // Try use alternative method name
                        var attribute = attributes[0] as TestingMethodAttribute;
                        if (!string.IsNullOrEmpty(attribute.AltMethodName))
                        {
                            var altMethod = Array.Find(methods, x => x.Name == attribute.AltMethodName);
                            if (altMethod != null)
                            {
                                testMethod = new ActionTestMethod(testUtils, altMethod.Name, () => altMethod.Invoke(mono, null));
                            }
                            else
                            {
                                TestDebug.LogTestFail(TestUtils.kTestMethodName, "Alternative name not found for method: " + method.Name);
                            }
                        }

                        // If needed, use method name
                        if (testMethod == null)
                        {
                            testMethod = new ActionTestMethod(testUtils, method.Name, () => method.Invoke(mono, null));
                        }
                        testMethods.Add(testMethod);
                    }
                }
            }
            return testMethods;
        }
    }
}
