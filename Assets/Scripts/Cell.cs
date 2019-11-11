using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICell
{
    void DidSelectCell(Cell cell);
    void DidSelectDeleteCell(Cell cell);
}

public class Cell : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Button deleteButton;
    public ICell cellDelegate;
    Button cellButton;

    public string Title
    {
        get
        {
            return this.title.text;
        }
        set
        {
            // title에 대한 유효성 체크
            this.title.text = value;
        }
    }

    public bool ActiveDelete
    {
        get 
        {
            return deleteButton.gameObject.activeSelf;
        }
        set
        {
            deleteButton.gameObject.SetActive(value);

            if (value)
            {
                cellButton.interactable = false;
            }
            else
            {
                cellButton.interactable = true;
            }

//            cellButton.interactable = !value;
        }
    }

    private void Start() 
    {
        cellButton = GetComponent<Button>();
        this.ActiveDelete = false;
    }

    public void OnClick()
    {
        cellDelegate.DidSelectCell(this);
    }

    public void OnClickDelete()
    {
        cellDelegate.DidSelectDeleteCell(this);
    }
}
