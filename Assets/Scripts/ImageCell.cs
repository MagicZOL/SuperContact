using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]

[RequireComponent(typeof(Button))]
public class ImageCell : MonoBehaviour
{
    public void SetImageCell(Sprite sprite, Action<Sprite> onClickAction)
    {
        this.GetComponent<Image>().sprite = sprite;

        GetComponent<Button>().onClick.AddListener(() => {
            if (this.GetComponent<Image>().sprite != null)
            {
                onClickAction(this.GetComponent<Image>().sprite);
            }
        });
    }
}
