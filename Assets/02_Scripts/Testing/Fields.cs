using System;

namespace Testing
{
    [Serializable]
    public class TestField<T> : BaseTestClass where T : UnityEngine.Object
    {
        public T Reference;

        public TestField(TestUtils testUtils, string name, T reference)
            : base(testUtils, name)
        {
            Reference = reference;
        }

        protected virtual bool IsSafe
        {
            get { return Reference != null; }
        }

        protected override bool Inner_Test(string scriptName, string testName)
        {
            if (!IsSafe)
            {
                TestDebug.LogTestFail(testName, scriptName + "." + _name + " is null");
                return false;
            }
            return true;
        }
    }
}