using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : MonoBehaviour
{
    /// <summary>
    /// [EXAMPLE] Utility implementation (Automatic log implementation)
    /// </summary>
    [SerializeField]
    private GameObject_Reference _textComponent = null;

    /// <summary>
    /// [EXAMPLE] Standard implementation (Manual log implementation)
    /// </summary>
    [SerializeField]
    private GameObject _iconComponent = null;

    /// <summary>
    /// [EXAMPLE]
    /// TEST: Test_SwapComponents()
    /// </summary>
    private void SwapComponents()
    {
        if (_textComponent.IsSafe)
        {
            bool enable = !_textComponent.Reference.activeSelf;
            _textComponent.Reference.SetActive(enable);
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
        testUtils.SetupReferences(_textComponent, new BaseReference<GameObject>("Portrait Icon", _iconComponent)); // Examples
        testUtils.SetupMethods(testUtils.AddMethod("SwapComponents", Test_SwapComponents)); // Example
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
        if (!_textComponent.Test())
        {
            return false;
        }

        if (_iconComponent == null)
        {
            TestUtils.LogTestFail(TestUtils.kTestMethodName, "Portrait icon is null");
            return false;
        }

        SwapComponents();
        return true;
    }

    #endregion
}
