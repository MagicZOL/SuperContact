using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPopupViewManager : PopupViewManager
{
    public void OnClcikOK()
    {
        NavigationManager manager = GameObject.Find("Canvas").GetComponent<NavigationManager>();

        Close();
    }
}