using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : MonoBehaviour
{
    /// <summary>
    /// [EXAMPLE]
    /// </summary>
    [SerializeField]
    private Component _textComponent = null;

    /// <summary>
    /// [EXAMPLE] Additional code that will test the requirements for the given method.
    /// This methods could add additional logs to the Test
    /// </summary>
    /// <returns></returns>
    private bool Test_SomeFunctionality()
    {
        if (_textComponent is UnityEngine.UI.Text)
        {
            SomeFunctionality();
            return true;
        }
        return false;
    }

    /// <summary>
    /// [EXAMPLE] Just some stupid example where _component is null
    /// </summary>
    private void SomeFunctionality()
    {
        var text = _textComponent as UnityEngine.UI.Text;
        if (text != null)
        {
            _textComponent.gameObject.SetActive(true);
        }
    }

    #region Tests

    [ContextMenu("Test All")]
    private bool Test_All()
    {
        TestUtils testUtils = new TestUtils(this);
        testUtils.SetupReferences(new TestReference("Some Reference", _textComponent)); // Example
        testUtils.SetupMethods(testUtils.AddMethod("SomeFunctionality", Test_SomeFunctionality)); // Example
        return testUtils.Test_All();
    }

    #endregion
}
