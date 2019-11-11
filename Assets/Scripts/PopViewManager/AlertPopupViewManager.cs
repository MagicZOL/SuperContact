using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPopupViewManager : PopupViewManager
{
    public void OnClcikOK()
    {
        MainManager manager = GameObject.Find("Canvas").GetComponent<MainManager>();

        Close();
    }
}