using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    [SerializeField] GameObject[] tabList;
    [SerializeField] Image[] tabIcons;

    Color initColor;
    private void Start()
    {
        OnclickTabButton(0);
    }
    //tabList들의 게임오브젝트들을 선택한것에 따라 활성/비활성화 시킴
    public void OnclickTabButton(int buttonIndex)
    {
        if (buttonIndex > tabList.Length - 1)
            return;
        for (int i = 0; i < tabList.Length; i++)
        {
            if (i == buttonIndex)
            {
                tabList[i].SetActive(true);
                tabIcons[i].color = Color.white;
                //tabIcons[i].color = new Color32(202, 0, 156, 255);
            }
            else
            {
                tabList[i].SetActive(false);
                tabIcons[i].color = Color.black;
            }
        }
    }
}
