using System;

namespace Testing
{
    public class FuncTestMethod : BaseTestClass
    {
        public Func<bool> _testMethod;

        public FuncTestMethod(TestUtils testUtils, string name, Func<bool> testMethod)
            : base(testUtils, name)
        {
            _testMethod = testMethod;
        }

        protected override bool Inner_Test(string scriptName, string testName)
        {
            if (_testMethod == null)
            {
                TestDebug.LogTestFail(testName, scriptName + "." + _name + " is null");
                return false;
            }
            if (!_testMethod())
            {
                TestDebug.LogTestFail(testName, scriptName + "." + _name + " didn't passed Test()");
                return false;
            }
            return true;
        }
    }

    public class ActionTestMethod : BaseTestClass
    {
        public Action _method;

        public ActionTestMethod(TestUtils testUtils, string name, Action method)
            : base(testUtils, name)
        {
            _method = method;
        }

        protected override bool Inner_Test(string scriptName, string testName)
        {
            if (_method == null)
            {
                TestDebug.LogTestFail(testName, scriptName + "." + _name + " is null");
                return false;
            }

            _method();
            return true;
        }
    }
}