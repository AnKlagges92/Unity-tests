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

    public abstract bool Test();
}

public class CustomTestMethod : BaseTestMethod
{
    public Func<bool> _testMethod;

    public CustomTestMethod(TestUtils testUtils, string name, Func<bool> testMethod)
        : base(testUtils, name)
    {
        _testMethod = testMethod;
    }

    public override bool Test()
    {
        string scriptName = _testUtils != null ? _testUtils.ScriptName : "SCRIPT_NAME_NOT_FOUND";
        string testName = _testUtils != null ? _testUtils.TestName : "TEST_NAME_NOT_FOUND";
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

public class TryTestMethod : BaseTestMethod
{
    public Action _method;

    public TryTestMethod(TestUtils testUtils, string name, Action method)
        : base(testUtils, name)
    {
        _method = method;
    }

    public override bool Test()
    {
        string scriptName = _testUtils != null ? _testUtils.ScriptName : "SCRIPT_NAME_NOT_FOUND";
        string testName = _testUtils != null ? _testUtils.TestName : "TEST_NAME_NOT_FOUND";
        if (_method == null)
        {
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " is null");
            return false;
        }

        try
        {
            _method();
            return true;
        }
        catch
        {
            TestUtils.LogTestFail(testName, scriptName + "." + _name + " didn't passed Test()");
            return false;
        }
    }
}