using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PopupViewManager : MonoBehaviour
{
    public enum AnimationType { TYPE1, TYPE2 };
    public AnimationType animationType;

    Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    // 팝업 나타날때 호출할 함수
    public void Open(AnimationType animationType=AnimationType.TYPE1)
    {
        this.animationType = animationType;

        gameObject.SetActive(true);

        switch (this.animationType)
        {
            case AnimationType.TYPE1:
                animator.SetTrigger("open");
                break;
            case AnimationType.TYPE2:
                animator.SetTrigger("open2");
                break;
        }
    }

    protected void Close()
    {
        switch (this.animationType)
        {
            case AnimationType.TYPE1:
                animator.SetTrigger("close");
                break;
            case AnimationType.TYPE2:
                animator.SetTrigger("close2");
                break;
        }
    }
    
    public void SetDisablePanel()
    {
        gameObject.SetActive(false);
    }
}
