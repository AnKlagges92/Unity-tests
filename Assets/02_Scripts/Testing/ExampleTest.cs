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

    [ContextMenu("Test All")]
    private bool Test_All()
    {
        TestUtils testUtils = new TestUtils(this);
        testUtils.SetupReferences(
            _textComponentReference,
            new BaseReference<GameObject>("Portrait Icon", _iconComponent)); // Examples

        testUtils.SetupMethods(
            testUtils.AddMethod("SwapComponents", Test_SwapComponents),
            testUtils.AddMethod("MultiSwapping", Test_MultiSwapping)); // Examples

        return testUtils.Test_All();
    }

    /// <summary>
    /// [EXAMPLE] Testing with both Utility & Standard implementations 
    /// Additional code that will test the requirements for the given method.
    /// This methods could add additional logs to the Test
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

    #endregion
}
