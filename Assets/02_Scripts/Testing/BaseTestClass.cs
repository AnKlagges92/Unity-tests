
namespace Testing
{
    public abstract class BaseTestClass
    {
        protected string _name;
        protected TestUtils _testUtils;

        public BaseTestClass(TestUtils testUtils, string name)
        {
            _testUtils = testUtils;
            _name = name;
        }

        public bool Test()
        {
            string scriptName = _testUtils != null ? _testUtils.ScriptName : TestUtils.kDefaultScriptName;
            string testName = _testUtils != null ? _testUtils.TestName : TestUtils.kDefaultTestName;

            try
            {
                return Inner_Test(scriptName, testName);
            }
            catch
            {
                TestDebug.LogTestFail(testName, scriptName + "." + _name + " didn't passed Test(). UNHANDLED ERROR!");
                return false;
            }
        }

        protected abstract bool Inner_Test(string scriptName, string testName);
    }
}