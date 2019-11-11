using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class AddPopupViewManager : PopupViewManager
{
    [SerializeField] InputField nameInputField;
    [SerializeField] InputField phoneNumberInputField;
    [SerializeField] InputField emailInputField;
    [SerializeField] ImageButton profilePhotoImageButton;

    [SerializeField] GameObject addPhotoPopupViewPrefab;

    public delegate void AddContact(Contact contact);
    public AddContact addContactCallback;

    public void OnClickAddPhoto()
    {
        AddPhotoPopupViewManager addPhotoPopupViewManager 
            = Instantiate(addPhotoPopupViewPrefab, transform.parent).GetComponent<AddPhotoPopupViewManager>();

        addPhotoPopupViewManager.Open(AnimationType.TYPE2);
        addPhotoPopupViewManager.didSelectImage = (sprite) =>
        {
            profilePhotoImageButton.Image = sprite;
        };
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        InitInputField(nameInputField);
        InitInputField(phoneNumberInputField);
        InitInputField(emailInputField);
    }

    public void OnClickAdd()
    {
        // TODO:
        // InputField의 값을 불러와서 Main 화면으로 값 전달
        string name = nameInputField.text;
        string phoneNumber = phoneNumberInputField.text;
        string email = emailInputField.text;

        bool isValid = true;

        if (name.Length < 1)
        {
            nameInputField.image.color = Color.red;
            isValid = false;
        }

        if (phoneNumber.Length < 1)
        {
            phoneNumberInputField.image.color = Color.red;
            isValid = false;
        }

        if (!IsCorrectEmail(email))
        {
            emailInputField.image.color = Color.red;
            isValid = false;
        }

        if (isValid)
        {
            Contact contact = new Contact();
            contact.name = name;
            contact.phoneNumber = phoneNumber;
            contact.email = email;
    
            if (profilePhotoImageButton.Image)
                contact.profilePhotoFileName = profilePhotoImageButton.Image.name;

            // Main 화면에 Contact 객체 전달
            addContactCallback(contact);

            // AddPanel 닫기
            Close();
        }
    }

    // 취소 버튼
    public void OnClickClose()
    {
        Close();
    }

    // 이메일 형식 체크
    bool IsCorrectEmail(string emailStr)
    {
        Regex regex = new Regex(@"[a-zA-Z0-9]+@[a-zA-Z0-9]");
        if (regex.IsMatch(emailStr))
        {
            return true;
        }
        return false;
    }

    // InputField의 내용을 초기화
    public void InitInputField(InputField inputField)
    {
        inputField.text = "";
        inputField.image.color = Color.white;
    }
}
