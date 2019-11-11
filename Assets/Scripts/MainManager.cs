using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Prefab
    [SerializeField] GameObject alertPopupViewPrefab;   // 첫 실행시 나타날 Popup 창 Prefab
    [SerializeField] GameObject scrollViewPrefab;       // ScrollView Prefab;

    // 자식 요소들
    [SerializeField] NavigationView navigationView;     // 상단 Navigation View
    [SerializeField] RectTransform content;             // 화면이 표시될 위치

    // Present한 ViewManager들
    Stack<ViewManager> viewManagers = new Stack<ViewManager>();

    void Start()
    {
        // Welcome 메시지 출력
        if (PlayerPrefs.GetInt(Constant.kIsFirst, 1) == 1)
        {
            AlertPopupViewManager alertPopupViewManager =
                Instantiate(alertPopupViewPrefab, transform).GetComponent<AlertPopupViewManager>();

            alertPopupViewManager.Open();

            PlayerPrefs.SetInt(Constant.kIsFirst, 0);
        }

        // Scroll View 만들어서 화면에 배치
        ScrollViewManager scrollViewManager = 
            Instantiate(scrollViewPrefab, transform).GetComponent<ScrollViewManager>();
        PresentViewManager(scrollViewManager);
    }

    // 새로운 화면 Content에 표시하기
    public void PresentViewManager(ViewManager viewManager, bool isAnimated=false)
    {
        viewManager.transform.SetParent(content);
        viewManager.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        viewManager.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        viewManager.GetComponent<RectTransform>().localScale = Vector3.one;

        if (viewManagers.Count > 0)
        {
            viewManager.Open(true);
        }

        // ViewManager에게 MainManager 할당
        viewManager.mainManager = this;

        // Navigation View에 타이틀 표시
        navigationView.Title = viewManager.title;

        // ViewManager에서 오른쪽 버튼이 설정되어 있으면 
        // 해당 버튼의 부모를 Navigation View의 RightButtonArea로 설정
        if (viewManager.rightNavgationViewButton)
        {
            viewManager.rightNavgationViewButton.transform.SetParent(navigationView.RightButtonArea);
            viewManager.rightNavgationViewButton.GetComponent<RectTransform>().anchoredPosition 
                = Vector2.zero;
            viewManager.rightNavgationViewButton.GetComponent<RectTransform>().sizeDelta
                = Vector2.zero;
            viewManager.rightNavgationViewButton.GetComponent<RectTransform>().localScale = Vector3.one;
        }

        // 왼쪽 Navigation button 표시
        if (viewManager.leftNavgationViewButton)
        {
            viewManager.leftNavgationViewButton.transform.SetParent(navigationView.LeftButtonArea);
            viewManager.leftNavgationViewButton.GetComponent<RectTransform>().anchoredPosition 
                = Vector2.zero;
            viewManager.leftNavgationViewButton.GetComponent<RectTransform>().sizeDelta 
                = Vector2.zero;
            viewManager.leftNavgationViewButton.GetComponent<RectTransform>().localScale
                = Vector3.one;
        }

        // 이전 화면 Navigation Button을 비활성화
        if (viewManagers.Count > 0)
        {
            ViewManager oldViewManager = viewManagers.Peek();
            if (oldViewManager.rightNavgationViewButton)
            {
                oldViewManager.rightNavgationViewButton.gameObject.SetActive(false);
            }
            if (oldViewManager.leftNavgationViewButton)
            {
                oldViewManager.leftNavgationViewButton.gameObject.SetActive(false);
            }
        }

        // ViewManager를 관리대상으로 추가
        viewManagers.Push(viewManager);

        // Back Button 활성화 여부 확인
        CheckBackButton();
    }

    // 마지막 화면 Content에서 제거하기
    public void DismissViewManager(bool isAnimated=false)
    {
        ViewManager viewManager = viewManagers.Pop();

        viewManager.Close();

        // Destroy(viewManager.gameObject);

        // 마지막 화면이 사라지면서 이전 화면의 타이틀 표시
        ViewManager lastViewManager = viewManagers.Peek();
        navigationView.Title = lastViewManager.title;

        // 이전 화면의 Navigation Button을 활성화
        if (lastViewManager.rightNavgationViewButton)
        {
            lastViewManager.rightNavgationViewButton.gameObject.SetActive(true);
        }
        if (lastViewManager.leftNavgationViewButton)
        {
            lastViewManager.leftNavgationViewButton.gameObject.SetActive(true);
        }

        // Back Button 활성화 여부 확인
        CheckBackButton();
    }

    void CheckBackButton()
    {
        // Back 버튼 추가여부 확인
        if (viewManagers.Count > 1)
        {
            navigationView.ShowBackButton(true);
        }
        else
        {
            navigationView.ShowBackButton(false);
        }
    }
}