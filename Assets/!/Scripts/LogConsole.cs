using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogConsole : MonoBehaviour
{
    [SerializeField] private TMP_Text m_LogText;

    [SerializeField] private bool m_ShowStackTrace = false;

    private string m_CurrentLog = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void Update()
    {
        m_LogText.text = m_CurrentLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType logType)
    {
        m_CurrentLog = m_ShowStackTrace ? logString + "\n" + stackTrace + "\n\n" + m_CurrentLog : logString + "\n\n" + m_CurrentLog;
    }

    public void ClearLog()
    {
        m_CurrentLog = "";
    }
}
