using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public abstract class MonoBehaviour : UnityEngine.MonoBehaviour
    {
        /// <summary>
        /// Get the references that will be tested during TestReferences()
        /// </summary>
        protected abstract BaseReference[] Test_GetReferences(TestUtils testUtils);

        /// <summary>
        /// Get the methods that will be tested during TestMethods()
        /// </summary>
        protected abstract BaseTestMethod[] Test_GetMethods(TestUtils testUtils);

        #region Common Menu Options

        [ContextMenu("Test All", true)]
        private bool Test_ValidateTestAll()
        {
            return Test_ValidateTestReferences() || Test_ValidateTestMethods();
        }

        [ContextMenu("Test All", false)]
        private bool Test_TestAll()
        {
            bool passed = true;
            passed &= Test_TestReferences();
            passed &= Test_TestMethods();
            return passed;
        }

        [ContextMenu("1- Test References", true)]
        private bool Test_ValidateTestReferences()
        {
            var testUtils = new TestUtils(this);
            return Test_GetReferences(testUtils).Length > 0;
        }

        [ContextMenu("1- Test References", false)]
        private bool Test_TestReferences()
        {
            var testUtils = new TestUtils(this);
            var references = Test_GetReferences(testUtils);
            testUtils.SetupReferences(references);
            return testUtils.Test_References();
        }

        [ContextMenu("2- Test Methods", true)]
        private bool Test_ValidateTestMethods()
        {
            var testUtils = new TestUtils(this);
            return Test_GetMethods(testUtils).Length > 0;
        }

        [ContextMenu("2- Test Methods", false)]
        private bool Test_TestMethods()
        {
            var testUtils = new TestUtils(this);
            var methods = Test_GetMethods(testUtils);
            testUtils.SetupMethods(methods);
            return testUtils.Test_Methods();
        }

        #endregion
    }
}
