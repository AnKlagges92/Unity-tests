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
    /// </summary>
    [TestingMethod("Test_SwapComponents")] // Example
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
    /// [EXAMPLE] Additional code that will test the requirements for the given method.
    /// [OPTIONAL] Info: Add additional information
    /// </summary>
    private bool Test_SwapComponents()
    {
        if (_textComponent == null || _iconComponent == null)
        {
            TestDebug.LogTestInfo("Test_SwapComponents", "Portrait Icon and/or Name Text is null"); // Info Example
            return false;
        }

        SwapComponents();
        return true;
    }

    /// <summary>
    /// [EXAMPLE] This tackle an specific bug [BUG-1939]
    /// [OPTIONAL] Add a context menu option to test individually
    /// </summary>
    [TestingMethod, ContextMenu("Test MultiSwapping", false)]
    private bool Test_MultiSwapping()
    {
        // Test feature
        if (!Test_SwapComponents())
        {
            TestDebug.LogTestNotStarted("Test_MultiSwapping", "Failed!");
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
            TestDebug.LogTestFail("Test_MultiSwapping", "MultiSwapping failed!");
        }
        return passed;
    }

    #endregion
}
