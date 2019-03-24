using System;
using System.Collections.Generic;
using UnityEngine;

public class TestUtils
{
    // Names
    public const string kTestReferenceName = "References Test";
    public const string kTestMethodName = "Methods Test";

    // Default Names
    public const string kDefaultScriptName = "SCRIPT_NAME_NOT_FOUND";
    public const string kDefaultTestName = "TEST_NAME_NOT_FOUND";
    public const string kDefaultReferenceName = "REFERENCE_NAME_NOT_FOUND";

    //Formats
    private const string kTestSucceedFormat = "[{0} Succeed]"; // 1: TestName
    private const string kTestNotStartedFormat = "[{0} NOT STARTED] {1}"; // 1: TestName, 2: Reason
    private const string kTestFailFormat = "[{0} FAILED] {1}"; // 1: TestName, 2: Reason
    private const string kTestExtraInfoFormat = "[{0} EXTRA INFO] {1}"; // 1: TestName, 2: Reason

    private string _scriptName;
    private List<BaseReference> _referencesList;
    private List<BaseTestMethod> _methodsList;

    private string _testName;

    public string ScriptName { get { return _scriptName; } }
    public string TestName { get { return _testName; } }

    #region Setup

    public TestUtils(object script)
    {
        _scriptName = script.GetType().Name;
    }

    public void SetupReferences(params BaseReference[] references)
    {
        _referencesList = new List<BaseReference>(references.Length);
        foreach (var reference in references)
        {
            reference.Setup(this);
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

    public TestMethod AddMethod(string name, Action method)
    {
        return new TestMethod(this, name, method);
    }

    public CustomTestMethod AddMethod(string name, Func<bool> testMethod)
    {
        return new CustomTestMethod(this, name, testMethod);
    }

    public BaseReference<T> AddReference<T>(string name, T reference) where T : UnityEngine.Object
    {
        return new BaseReference<T>(name, reference);
    }

    #endregion

    public bool Test_All()
    {
        bool passed = true;
        passed &= Test_References();
        passed &= Test_Methods();

        if (passed)
        {
            LogTestSucceed("ALL Tests");
        }
        return passed;
    }

    public bool Test_References()
    {
        _testName = kTestReferenceName;
        if (_referencesList == null)
        {
            LogTestNotStarted(_testName, "References list is null");
            return true;
        }

        bool passed = true;
        foreach (var reference in _referencesList)
        {
            passed &= reference.Test();
        }

        if (passed)
        {
            LogTestSucceed(_testName);
        }
        return passed;
    }

    public bool Test_Methods()
    {
        _testName = kTestMethodName;
        if (_methodsList == null)
        {
            LogTestNotStarted(_testName, "Methods list is null");
            return true;
        }

        bool passed = true;
        foreach (var method in _methodsList)
        {
            passed &= method.Test();
        }

        if (passed)
        {
            LogTestSucceed(_testName);
        }
        return passed;
    }

    public static void LogTestNotStarted(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestNotStartedFormat, testName, reason));
    }

    public static void LogTestFail(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestFailFormat, testName, reason));
    }

    public static void LogTestExtraInfo(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestExtraInfoFormat, testName, reason));
    }

    public static void LogTestSucceed(string testName)
    {
        Debug.Log(string.Format(kTestSucceedFormat, testName));
    }
}

