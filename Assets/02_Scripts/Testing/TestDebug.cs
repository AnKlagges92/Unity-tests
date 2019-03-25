using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OPTIONAL Utility class for log standarization
/// </summary>
public static class TestDebug
{
    //Formats
    private const string kTestSucceedFormat = "[{0} Succeed]"; // 1: TestName
    private const string kTestNotStartedFormat = "[{0} NOT STARTED] {1}"; // 1: TestName, 2: Reason
    private const string kTestFailFormat = "[{0} FAILED] {1}"; // 1: TestName, 2: Reason
    private const string kTestInfoFormat = "[{0} INFO] {1}"; // 1: TestName, 2: Reason

    public static void LogTestNotStarted(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestNotStartedFormat, testName, reason));
    }

    public static void LogTestFail(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestFailFormat, testName, reason));
    }

    public static void LogTestInfo(string testName, string reason)
    {
        Debug.LogError(string.Format(kTestInfoFormat, testName, reason));
    }

    public static void LogTestSucceed(string testName)
    {
        Debug.Log(string.Format(kTestSucceedFormat, testName));
    }
}