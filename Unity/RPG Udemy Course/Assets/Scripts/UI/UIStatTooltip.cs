using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatTooltip : UIToolTip
{
    [SerializeField] private TextMeshProUGUI description;

    public void ShowStatTooltip(string _text)
    {
        description.text = _text;
        AdjustPosition();

        gameObject.SetActive(true);
    }

    public void HideStatToolTip()
    {
        description.text = "";
        gameObject.SetActive(false);
    }
}
