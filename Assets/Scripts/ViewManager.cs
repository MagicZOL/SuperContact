using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ViewManager : MonoBehaviour
{
    [SerializeField] protected GameObject buttonPrefab;
    [HideInInspector] public string title;                        // Navigation View에 표시할 타이틀
    [HideInInspector] public SCButton leftNavgationViewButton;    // Navigation View 왼쪽에 표시할 버튼
    [HideInInspector] public SCButton rightNavgationViewButton;   // Navigation View 오른쪽에 표시할 버튼
    [HideInInspector] public NavigationManager mainManager;

    Animator animator;

    public void Close()
    {
        GetComponent<Animator>().SetTrigger(Constant.kViewManagerClose);
    }

    public void Open(bool isAnimated=false)
    {
        if (isAnimated)
        {
           GetComponent<Animator>().SetTrigger(Constant.kViewManagerOpen);
        }
    }

    public void DestroyViewManager()
    {
        Destroy(gameObject);
    }
}
