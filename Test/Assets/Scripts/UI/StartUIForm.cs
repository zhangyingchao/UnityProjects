using AllConstInGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIForm : BaseUI
{
    private InputField userNameInputField;
    private ToggleGroup genderToggleGroup;
    public RawImage userPortrait;
    protected override void Awake()
    {
        base.Awake();
        transform.Find("StartButton").GetComponent<Button>().onClick.AddListener(delegate
        {
            UIManager.Instance.HideUIForm(UIFormBaseType.StartUIForm);
            Global.userData = SaveUserData();
            UIManager.Instance.ShowUIForm(UIFormBaseType.MainUIForm);
        });
        userNameInputField = transform.Find("UserName").GetComponentInChildren<InputField>();
        genderToggleGroup = transform.Find("Gender").GetComponent<ToggleGroup>();
        userPortrait = transform.Find("Portrait/TravelerPortrait").GetComponentInChildren<RawImage>();



        transform.Find("Portrait/TravelerPortrait").GetComponent<Button>().onClick.AddListener(delegate
        {
            RandomPortrait();
        });
    }

    /// <summary>
    /// 根据性别随机选择头像
    /// </summary>
    void RandomPortrait()
    {
        string currentGender = ReturnActiveToggleInGroup(genderToggleGroup.ActiveToggles()).GetComponentInChildren<Text>().text;
        userPortrait.texture = ResourcesManager.Instance.RandomTextureInPortraitsDic(currentGender);
    }


    UserData SaveUserData()
    {
        UserData data = new UserData();
        data.userName = userNameInputField.text;
        data.userGender = ReturnActiveToggleInGroup(genderToggleGroup.ActiveToggles()).GetComponentInChildren<Text>().text;
        data.portraitTexture = userPortrait.texture;
        return data;
    }

    Toggle ReturnActiveToggleInGroup(IEnumerable<Toggle> toggleGroup)
    {
        foreach (Toggle t in toggleGroup)
        { 
            if (t.isOn)
            {
                return t;
            }
        }
        return null;
    }

    protected override void UIFormInit()
    {
        appearsType = UIFormAppearsType.NormalUIForm;
        
    }
}
