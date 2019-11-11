using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPopupViewManager : PopupViewManager
{
    public delegate void ConfirmPopupViewManagerDelegate();
    public ConfirmPopupViewManagerDelegate confirmPopupViewManagerDelegate;

    public void OnClickOK()
    {
        confirmPopupViewManagerDelegate?.Invoke();
        
        // 창 닫기
        Close();
    }

    public void OnClickCancel()
    {
        Close();
    }
}
