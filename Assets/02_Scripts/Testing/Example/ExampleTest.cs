using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : Testing.MonoBehaviour
{
    /// <summary>
    /// [EXAMPLE]
    /// </summary>
    [SerializeField, TestingField]
    private GameObject _textComponent = null;

    /// <summary>
    /// [EXAMPLE]
    /// </summary>
    [SerializeField, TestingField]
    private GameObject _iconComponent = null;

    /// <summary>
    /// [EXAMPLE]
    /// TEST: Test_SwapComponents()
    /// </summary>
    [TestingMethod("Test_SwapComponents")]
    private void SwapComponents()
    {
        if (_textComponent != null)
        {
            bool enable = !_textComponent.activeSelf;
            _textComponent.SetActive(enable);
        }
        if (_iconComponent != null)
        {
            bool enable = !_iconComponent.activeSelf;
            _iconComponent.SetActive(enable);
        }
    }

    #region Tests

    /// <summary>
    /// [EXAMPLE] Testing with both Utility & Standard implementations 
    /// Additional code that will test the requirements for the given method.
    /// [OPTIONAL] Info: Add additional information
    /// </summary>
    /// <returns></returns>
    [TestingMethod]
    private bool Test_SwapComponents()
    {
        if (_textComponent == null || _iconComponent == null)
        {
            TestUtils.LogTestInfo(TestUtils.kTestMethodName, "Portrait Icon and/or Name Text is null"); // Info Example
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
    [TestingMethod]
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
        _textComponent.SetActive(false);

        // Execution
        passed &= Test_SwapComponents();
        passed &= Test_SwapComponents();
        passed &= Test_SwapComponents();

        // Test results
        passed &= !_iconComponent.activeSelf && _textComponent.activeSelf;

        if (!passed)
        {
            TestUtils.LogTestFail(TestUtils.kTestMethodName, "MultiSwapping failed!");
        }
        return passed;
    }

    #endregion
}
