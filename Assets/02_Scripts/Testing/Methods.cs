using System;

public abstract class BaseTestMethod
{
    protected string _name;
    protected TestUtils _testUtils;

    public BaseTestMethod(TestUtils testUtils, string name)
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
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " didn't passed Test(). Unhandled error");
            return false;
        }
    }

    protected abstract bool Inner_Test(string scriptName, string testName);
}

public class CustomTestMethod : BaseTestMethod
{
    public Func<bool> _testMethod;

    public CustomTestMethod(TestUtils testUtils, string name, Func<bool> testMethod)
        : base(testUtils, name)
    {
        _testMethod = testMethod;
    }

    protected override bool Inner_Test(string scriptName, string testName)
    {
        if (_testMethod == null)
        {
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " is null");
            return false;
        }
        if (!_testMethod())
        {
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " didn't passed Test()");
            return false;
        }
        return true;
    }
}

public class TestMethod : BaseTestMethod
{
    public Action _method;

    public TestMethod(TestUtils testUtils, string name, Action method)
        : base(testUtils, name)
    {
        _method = method;
    }

    protected override bool Inner_Test(string scriptName, string testName)
    {
        if (_method == null)
        {
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " is null");
            return false;
        }

        _method();
        return true;
    }
}