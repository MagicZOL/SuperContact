using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationView : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] RectTransform leftButtonArea;
    [SerializeField] RectTransform rightButtonArea;
    [SerializeField] GameObject backButton;
    [SerializeField] NavigationManager mainManager;

    // Navigation View의 가운데 Text 값을 변경하는 속성
    public string Title
    {
        get
        {
            return titleText.text;
        }
        set
        {
            titleText.text = value;
        }
    }

    private void Start()
    {
        backButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            mainManager.DismissViewManager();
        });
    }

    public RectTransform LeftButtonArea
    {
        get
        {
            return leftButtonArea;
        }
    }

    public RectTransform RightButtonArea
    {
        get
        {
            return rightButtonArea;
        }
    }

    // 뒤로가기 버튼 활성화
    public void ShowBackButton(bool isShow)
    {
        backButton.SetActive(isShow);
    }
}
