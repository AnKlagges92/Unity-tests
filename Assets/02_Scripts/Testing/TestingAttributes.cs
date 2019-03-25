using System;

[AttributeUsage(AttributeTargets.Field)]
public class TestingFieldAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Method)]
public class TestingMethodAttribute : Attribute
{
    public readonly string AltMethodName;

    public TestingMethodAttribute() { }

    public TestingMethodAttribute(string altMethodName)
    {
        AltMethodName = altMethodName;
    }
}