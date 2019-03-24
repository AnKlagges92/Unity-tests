using System;
using UnityEngine;

[Serializable]
public abstract class BaseReference
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

    public BaseReference(string name)
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
public class BaseReference<T> : BaseReference where T : UnityEngine.Object
{
    public T Reference;

    public override bool IsSafe
    {
        get { return Reference != null; }
    }

    public BaseReference(string name, T reference)
        : base(name)
    {
        Reference = reference;
    }
}

[Serializable]
public class Object_Reference : BaseReference<UnityEngine.Object>
{
    public Object_Reference(string name, UnityEngine.Object reference)
        : base(name, reference) { }
}

[Serializable]
public class GameObject_Reference : BaseReference<GameObject>
{
    public GameObject_Reference(string name, GameObject reference)
        : base(name, reference) { }
}

[Serializable]
public class Component_Reference : BaseReference<Component>
{
    public Component_Reference(string name, Component reference)
        : base(name, reference) { }
}
