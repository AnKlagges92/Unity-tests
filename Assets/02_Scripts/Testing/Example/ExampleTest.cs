using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : MonoBehaviour
{
    /// <summary>
    /// [EXAMPLE] Utility implementation (Automatic log implementation)
    /// </summary>
    [SerializeField]
    private GameObject_Reference _textComponentReference = null;

    /// <summary>
    /// [EXAMPLE] Standard implementation (Manual log implementation)
    /// </summary>
    [SerializeField]
    private GameObject _iconComponent = null;

    /// <summary>
    /// [EXAMPLE] Optional getter that improves the readability
    /// </summary>
    private GameObject TextComponent { get { return _textComponentReference.Reference; } }

    /// <summary>
    /// [EXAMPLE]
    /// TEST: Test_SwapComponents()
    /// </summary>
    private void SwapComponents()
    {
        if (_textComponentReference.IsSafe)
        {
            bool enable = !TextComponent.activeSelf;
            TextComponent.SetActive(enable);
        }
        if (_iconComponent != null)
        {
            bool enable = !_iconComponent.activeSelf;
            _iconComponent.SetActive(enable);
        }
    }

    #region Tests

    /// <summary>
    /// Get the references that will be tested during TestReferences()
    /// [OVERRIDE] Replace references
    /// </summary>
    private BaseReference[] Test_GetReferences(TestUtils testUtils)
    {
        return new BaseReference[]
        { // Examples
            _textComponentReference,
            testUtils.AddReference("Portrait Icon", _iconComponent)
        };
    }

    /// <summary>
    /// Get the methods that will be tested during TestMethods()
    /// [OVERRIDE] Replace methods
    /// </summary>
    private BaseTestMethod[] Test_GetMethods(TestUtils testUtils)
    {
        return new BaseTestMethod[]
        { // Examples
            testUtils.AddMethod("SwapComponents", Test_SwapComponents),
            testUtils.AddMethod("SwapComponents", Test_SwapComponents_Lazy),
            testUtils.AddMethod("MultiSwapping", Test_MultiSwapping)
        };
    }
    /// <summary>
    /// [EXAMPLE] Testing with both Utility & Standard implementations 
    /// Additional code that will test the requirements for the given method.
    /// [OPTIONAL] ExtraInfo: Add additional information
    /// </summary>
    /// <returns></returns>
    private bool Test_SwapComponents()
    {
        if (!_textComponentReference.Test() || _iconComponent == null)
        {
            if (_iconComponent == null)
            {
                TestUtils.LogTestFail(TestUtils.kTestMethodName, "Portrait icon is null");
            }
            if (_iconComponent == null && _textComponentReference.Test())
            {
                TestUtils.LogTestExtraInfo(TestUtils.kTestMethodName, "Portrait is null, but TextComponent passed the test!"); // ExtraInfo Example
            }
            return false;
        }

        SwapComponents();
        return true;
    }

    /// <summary>
    /// [EXAMPLE] Testing with both Utility & Standard implementations 
    /// [LAZY] References are not tested (They are redundant since are tested in another part when TestAll() is  invoked)
    /// Additional code that will test the requirements for the given method.
    /// [OPTIONAL] Add additional information
    /// </summary>
    /// <returns></returns>
    private bool Test_SwapComponents_Lazy()
    {
        if (_iconComponent == null && _textComponentReference.Test())
        {
            TestUtils.LogTestExtraInfo(TestUtils.kTestMethodName, "Portrait is null, but TextComponent passed the test!"); // ExtraInfo Example, Not a real requisite
            return false;
        }

        SwapComponents();
        return true;
    }

    /// <summary>
    /// [EXAMPLE] Testing some edge case
    /// This can tackle an specific bug [BUG-1939]
    /// </summary>
    /// <returns></returns>
    private bool Test_MultiSwapping()
    {
        // Test feature
        if (!Test_SwapComponents())
        {
            TestUtils.LogTestNotStarted(TestUtils.kTestMethodName, "MultiSwapping failed!");
            return false;
        }

        // Initial setup
        bool passed = true;
        _iconComponent.SetActive(true);
        TextComponent.SetActive(false);

        // Execution
        passed &= Test_SwapComponents();
        passed &= Test_SwapComponents();
        passed &= Test_SwapComponents();

        // Test results
        passed &= !_iconComponent.activeSelf && TextComponent.activeSelf;

        if (!passed)
        {
            TestUtils.LogTestFail(TestUtils.kTestMethodName, "MultiSwapping failed!");
        }
        return passed;
    }

    #region Common

    [ContextMenu("Test All", true)]
    private bool Test_ValidateTestAll()
    {
        return Test_ValidateTestReferences() || Test_ValidateTestMethods();
    }

    [ContextMenu("Test All", false)]
    private bool Test_TestAll()
    {
        return Test_TestReferences() && Test_TestMethods();
    }

    [ContextMenu("1- Test References", true)]
    private bool Test_ValidateTestReferences()
    {
        var testUtils = new TestUtils(this);
        return Test_GetReferences(testUtils).Length > 0;
    }

    [ContextMenu("1- Test References", false)]
    private bool Test_TestReferences()
    {
        var testUtils = new TestUtils(this);
        var references = Test_GetReferences(testUtils);
        testUtils.SetupReferences(references);
        return testUtils.Test_References();
    }

    [ContextMenu("2- Test Methods", true)]
    private bool Test_ValidateTestMethods()
    {
        var testUtils = new TestUtils(this);
        return Test_GetMethods(testUtils).Length > 0;
    }

    [ContextMenu("2- Test Methods", false)]
    private bool Test_TestMethods()
    {
        var testUtils = new TestUtils(this);
        var methods = Test_GetMethods(testUtils);
        testUtils.SetupMethods(methods);
        return testUtils.Test_Methods();
    }

    #endregion

    #endregion
}
