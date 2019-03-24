using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : MonoBehaviour
{
    /// <summary>
    /// [EXAMPLE]
    /// </summary>
    [SerializeField]
    private GameObject_Reference _textComponent = null;

    /// <summary>
    /// [EXAMPLE]
    /// </summary>
    [SerializeField]
    private GameObject_Reference _iconComponent = null;

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
        if (_iconComponent.IsSafe)
        {
            bool enable = !_iconComponent.Reference.activeSelf;
            _iconComponent.Reference.SetActive(enable);
        }
    }

    #region Tests

    [ContextMenu("Test All")]
    private bool Test_All()
    {
        TestUtils testUtils = new TestUtils(this);
        testUtils.SetupReferences(_textComponent, _iconComponent); // Examples
        testUtils.SetupMethods(testUtils.AddMethod("SwapComponents", Test_SwapComponents)); // Example
        return testUtils.Test_All();
    }

    /// <summary>
    /// [EXAMPLE]
    /// Additional code that will test the requirements for the given method.
    /// This methods could add additional logs to the Test
    /// </summary>
    /// <returns></returns>
    private bool Test_SwapComponents()
    {
        if (!_textComponent.Test() || !_iconComponent.Test())
        {
            return false;
        }

        SwapComponents();
        return true;
    }

    #endregion
}
