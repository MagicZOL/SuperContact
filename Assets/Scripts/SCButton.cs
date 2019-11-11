using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SCButton : MonoBehaviour
{
    Button cachedButton;
    public Button CachedButton
    {
        get
        {
            if(cachedButton == null)
            {
                cachedButton = GetComponent<Button>();
            }
            return cachedButton;
        }
    }
    // 버튼에 타이틀 변경 함수
    public void SetTitle(string title)
    {
        GetComponentInChildren<Text>().text = title;
    }

    // 버튼의 OnClick 이벤트 변경 함수
    public void SetOnClickAction(UnityAction action)
    {
        GetComponent<Button>().onClick.AddListener(action);
    }

    public void SetInterractable(bool value)
    {
        this.CachedButton.interactable = value;
    }
}
