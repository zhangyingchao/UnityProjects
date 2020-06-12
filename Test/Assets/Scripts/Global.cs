using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
    public static UserData userData;
}

public class DelegateManager
{
    public delegate void SaveUserData();
    public static SaveUserData SaveData;
    public static void OnSaveData()
    {
        //Debug.Log("切换场景后调用此方法");
        SaveData?.Invoke();
    }
}

public class UserData
{
    /// <summary>
    /// 用户昵称
    /// </summary>
    public string userName;
    /// <summary>
    /// 用户性别
    /// </summary>
    public string userGender;
    /// <summary>
    /// 角色头像
    /// </summary>
    public Texture portraitTexture;
}
