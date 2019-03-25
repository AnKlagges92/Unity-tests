using System;
using UnityEngine;

[Serializable]
public abstract class BaseField
{
    [SerializeField]
    private string _name;
    public string Name
    {
        get
        {
            if (string.IsNullOrEmpty(_name))
            {
                return TestUtils.kDefaultReferenceName;
            }
            return _name;
        }
    }

    protected TestUtils _testUtils;

    public abstract bool IsSafe { get; }

    public BaseField(string name)
    {
        _name = name;
    }

    public void Setup(TestUtils testUtils)
    {
        _testUtils = testUtils;
    }

    public bool Test()
    {
        string scriptName = _testUtils != null ? _testUtils.ScriptName : TestUtils.kDefaultScriptName;
        string testName = _testUtils != null ? _testUtils.TestName : TestUtils.kDefaultTestName;
        if (!IsSafe)
        {
            TestUtils.LogTestFail(testName, scriptName + "." + Name + " is null");
            return false;
        }
        return true;
    }
}

[Serializable]
public class BaseField<T> : BaseField where T : UnityEngine.Object
{
    public T Reference;

    public override bool IsSafe
    {
        get { return Reference != null; }
    }

    public BaseField(string name, T reference)
        : base(name)
    {
        Reference = reference;
    }
}
