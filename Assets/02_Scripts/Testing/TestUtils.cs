using System;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public class TestUtils
    {
        // Names
        public const string kTestFieldsName = "Fields Test";
        public const string kTestMethodName = "Methods Test";

        // Default Names
        public const string kDefaultScriptName = "SCRIPT_NAME_NOT_FOUND";
        public const string kDefaultTestName = "TEST_NAME_NOT_FOUND";
        public const string kDefaultFieldName = "FIELD_NAME_NOT_FOUND";

        private string _scriptName;
        private List<BaseTestClass> _fieldsList;
        private List<BaseTestClass> _methodsList;

        private string _testName;

        public string ScriptName { get { return _scriptName; } }
        public string TestName { get { return _testName; } }

        #region Setup

        public TestUtils(object script)
        {
            _scriptName = script.GetType().Name;
        }

        public bool TestField(UnityEngine.Object reference, string fieldName = kDefaultFieldName)
        {
            var testField = new TestField<UnityEngine.Object>(this, fieldName, reference);
            return testField.Test();
        }

        public void SetupFields(params BaseTestClass[] fields)
        {
            _fieldsList = new List<BaseTestClass>(fields.Length);
            foreach (var field in fields)
            {
                _fieldsList.Add(field);
            }
        }

        public void SetupMethods(params BaseTestClass[] methods)
        {
            _methodsList = new List<BaseTestClass>(methods.Length);
            foreach (var method in methods)
            {
                _methodsList.Add(method);
            }
        }

        #endregion

        public bool Test_All()
        {
            bool passed = true;
            passed &= Test_Fields();
            passed &= Test_Methods();

            if (passed)
            {
                TestDebug.LogTestSucceed("ALL Tests");
            }
            return passed;
        }

        public bool Test_Fields()
        {
            _testName = kTestFieldsName;
            if (_fieldsList == null)
            {
                TestDebug.LogTestNotStarted(_testName, "Fields list is null");
                return true;
            }

            bool passed = true;
            foreach (var field in _fieldsList)
            {
                passed &= field.Test();
            }

            if (passed)
            {
                TestDebug.LogTestSucceed(_testName);
            }
            return passed;
        }

        public bool Test_Methods()
        {
            _testName = kTestMethodName;
            if (_methodsList == null)
            {
                TestDebug.LogTestNotStarted(_testName, "Methods list is null");
                return true;
            }

            bool passed = true;
            foreach (var method in _methodsList)
            {
                passed &= method.Test();
            }

            if (passed)
            {
                TestDebug.LogTestSucceed(_testName);
            }
            return passed;
        }
    }
}