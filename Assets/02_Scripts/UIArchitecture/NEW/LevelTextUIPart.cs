using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// [EXAMPLE]
/// This is a SPECIFIC part
/// [EXAMPLE]
/// </summary>
[Serializable]
public class LevelTextsUIPart
{
    public enum ELevelFormat
    {
        Level,
        LevelAndMax
    }

    [SerializeField] private Text _levelText;
    [SerializeField] private Text _maxLevelText;

    [SerializeField] protected ELevelFormat _format = ELevelFormat.Level;

    public void SetLevelText(int level, int maxLevel = 0)
    {
        if (_format == ELevelFormat.Level)
        {
            SetText(_levelText, level);
        }
        else
        {
            if (_maxLevelText != null)
            {
                SetText(_levelText, level);
                SetText(_maxLevelText, maxLevel);
            }
            else
            {
                SetText(_levelText, level + " /" + maxLevel);
            }
        }
    }

    public void SetText(Text component, object value)
    {
        if (component != null)
        {
            component.text = value.ToString();
        }
    }
}
