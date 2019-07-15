using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// [EXAMPLE]
/// This is a SPECIFIC part
/// [EXAMPLE]
/// </summary>
[Serializable]
public class AmountUIPart
{
    [SerializeField] private Text _amountText = null;
    [SerializeField] private Text _maxAmountText = null;

    [SerializeField] private bool _showMaxAmount = false;

    public void SetAmount(int amount, int maxAmount = 0)
    {
        if(!_showMaxAmount)
        {
            SetText(_amountText, amount);
        }
        else if (_maxAmountText != null)
        {
            SetText(_amountText, amount);
            SetText(_maxAmountText, "/" + maxAmount);
        }
        else
        {
            SetText(_amountText, amount + " /" + maxAmount);
        }
    }

    private void SetText(Text component, object value)
    {
        if (component != null)
        {
            component.text = value.ToString();
        }
    }
}
