using System;

[AttributeUsage(AttributeTargets.Field)]
public class TestingFieldAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Method)]
public class TestingMethodAttribute : Attribute { }