using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageButton : MonoBehaviour
{
    [SerializeField] Image buttonImage;                     //상세화면 버튼이미지
    [SerializeField] GameObject addPhotoPopupViewPrefab;    //포토팝업띄우기위한 프리팹
    Button cachedButton; 

    //버튼캐시
    Button CachedButton
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

    //버튼의 이미지 스프라이트에 접근할때 코드를 줄일수 있는 프라퍼티선언
    public Sprite Image
    {
        get
        {
            return this.buttonImage.sprite;
        }
        set
        {
            buttonImage.sprite = value;
        }
    }

    public bool Editable
    {
        get
        {
            return this.CachedButton.interactable;
        }
        set
        {
            this.CachedButton.interactable = value;
        }
    }

    public void Onclick()
    {
        if(addPhotoPopupViewPrefab)
        {
            AddPhotoPopupViewManager addPhotoPopupViewManager 
                = Instantiate(addPhotoPopupViewPrefab, NavigationManager.Instance.transform).GetComponent<AddPhotoPopupViewManager>();

            addPhotoPopupViewManager.Open(PopupViewManager.AnimationType.TYPE2);
            addPhotoPopupViewManager.didSelectImage = (sprite) =>
            {
                this.Image = sprite;
            };
        }
    }
}
