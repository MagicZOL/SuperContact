using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddPhotoPopupViewManager : PopupViewManager
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GridLayoutGroup gridLayoutGroup;
    [SerializeField] GameObject baseImageCell;

    public Action<Sprite> didSelectImage;

    protected override void Awake() {
        base.Awake();

        // Sprite 불러와서 ImageCell 만들기
        Sprite[] sprites = SpriteManager.Load();
        MakeImageCell(sprites);

        // baseImageCell 비활성화
        baseImageCell.SetActive(false);
    }

    private void MakeImageCell(Sprite[] sprites)
    {
        float cellHeight = (gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y)
            * (sprites.Length / gridLayoutGroup.constraintCount) + gridLayoutGroup.padding.top
            + gridLayoutGroup.padding.bottom;

        scrollRect.content.sizeDelta = new Vector2(0, cellHeight);

        foreach (Sprite sprite in sprites)
        {
            GameObject imageCellObject = Instantiate(baseImageCell, scrollRect.content);
            ImageCell imageCell = imageCellObject.GetComponent<ImageCell>();
            imageCell.SetImageCell(sprite, (selectedSprite) => {

                didSelectImage?.Invoke(selectedSprite);

                Debug.Log(selectedSprite);
                Close();
            });
        }
    }

    public void OnClickClose()
    {
        Close();
    }
}
