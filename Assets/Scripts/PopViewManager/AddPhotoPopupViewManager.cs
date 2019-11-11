using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPhotoPopupViewManager : PopupViewManager
{
    Sprite[] sprites;

    [SerializeField] Image tempImage; 

    protected override void Awake() {
        base.Awake();
        sprites = Resources.LoadAll<Sprite>("photo");
        Debug.Log(sprites);

        tempImage.sprite = sprites[0];
    }

    public void OnClickClose()
    {
        Close();
    }
}
