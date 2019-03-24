using System;
using System.Collections.Generic;
using UnityEngine;

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
        if (_testMethod == null)
        {
            _testUtils.LogTestFail(TestUtils.kTestMethodName, _testUtils.ScriptName + "." + _name + " is null");
            return false;
        }
        if (!_testMethod())
        {
            _testUtils.LogTestFail(TestUtils.kTestMethodName, _testUtils.ScriptName + "." + _name + " didn't passed Test()");
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
        if (_method == null)
        {
            _testUtils.LogTestFail(TestUtils.kTestMethodName, _testUtils.ScriptName + "." + _name + " is null");
            return false;
        }

        try
        {
            _method();
            return true;
        }
        catch
        {
            _testUtils.LogTestFail(TestUtils.kTestMethodName, _testUtils.ScriptName + "." + _name + " didn't passed Test()");
            return false;
        }
    }
}

public class TestReference
{
    public string Name;
    public UnityEngine.Object Reference;

    public TestReference(string name, UnityEngine.Object reference)
    {
        Name = name;
        Reference = reference;
    }
}

public class TestUtils
{
    public const string kTestReferenceName = "Test_References";
    public const string kTestMethodName = "Test_Methods";

    private string _scriptName;
    private List<TestReference> _referencesList;
    private List<BaseTestMethod> _methodsList;

    public string ScriptName { get { return _scriptName; } }

    #region Setup

    public TestUtils(object script)
    {
        _scriptName = script.GetType().Name;
    }

    public void SetupReferences(params TestReference[] references)
    {
        _referencesList = new List<TestReference>(references.Length);
        foreach (var reference in references)
        {
            _referencesList.Add(reference);
        }
    }

    public void SetupMethods(params BaseTestMethod[] methods)
    {
        _methodsList = new List<BaseTestMethod>(methods.Length);
        foreach (var method in methods)
        {
            _methodsList.Add(method);
        }
    }

    public TryTestMethod AddMethod(string name, Action method)
    {
        return new TryTestMethod(this, name, method);
    }

    public CustomTestMethod AddMethod(string name, Func<bool> testMethod)
    {
        return new CustomTestMethod(this, name, testMethod);
    }

    #endregion

    public bool Test_All()
    {
        bool passed = false;
        passed |= Test_References();
        passed |= Test_Methods();
        return passed;
    }

    public bool Test_References()
    {
        if (_referencesList == null)
        {
            LogTestNotStarted(kTestReferenceName, "References list is null");
            return true;
        }

        bool passed = true;
        foreach (var reference in _referencesList)
        {
            if (reference.Reference == null)
            {
                passed = false;
                LogTestFail(kTestReferenceName, _scriptName + "." + reference.Name + " is null");
            }
        }
        return passed;
    }

    public bool Test_Methods()
    {
        if (_methodsList == null)
        {
            LogTestNotStarted(kTestMethodName, "Methods list is null");
            return true;
        }

        bool passed = true;
        foreach (var method in _methodsList)
        {
            passed |= !method.Test();
        }
        return passed;
    }

    public void LogTestNotStarted(string testName, string reason)
    {
        Debug.LogError("[" + testName + " NOT STARTED] " + _scriptName + "." + reason);
    }

    public void LogTestFail(string testName, string reason)
    {
        Debug.LogError("[" + testName + " FAILED] " + reason);
    }
}
