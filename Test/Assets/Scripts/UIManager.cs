using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllConstInGame;

public class UIManager : Singleton<UIManager>
{
    private BaseUI currentUIForm;
    public BaseUI CurrentUIForm
    {
        get
        {
            return currentUIForm;
        }
        set
        {
            currentUIForm = value;
        }
    }
    void Start()
    {
        ShowUIForm(UIFormBaseType.StartUIForm);
    }

    void Update()
    {

    }

    /// <summary>
    /// 显示窗口
    /// </summary>
    /// <param name="uIFormBase"></param>
    public void ShowUIForm(UIFormBaseType uIFormBase)
    {
        if (currentUIForm != null) currentUIForm.HideUI();
        //得到窗口
        currentUIForm = ReturnFormByType(uIFormBase);
        currentUIForm.ShowUI();
    }

    /// <summary>
    /// 隐藏窗口
    /// </summary>
    /// <param name="uIFormBase"></param>
    public void HideUIForm(UIFormBaseType uIFormBase)
    {
        BaseUI uiForm = ReturnFormByType(uIFormBase);
        currentUIForm = null;
        if (uiForm.uiFormState) uiForm.HideUI();
    }

    /// <summary>
    /// 删除窗口
    /// </summary>
    /// <param name="uIFormBase"></param>
    public void DestroyUIFom(UIFormBaseType uIFormBase)
    {
        BaseUI uiForm = ReturnFormByType(uIFormBase);
        if (uiForm) Destroy(uiForm.gameObject);
    }

    /// <summary>
    /// 删除所有存在的窗口
    /// </summary>
    public void DestroyUIFormAll()
    {
        for (int i=0;i<transform.childCount;i++)
        {
            Transform _child = transform.GetChild(i);
            if (_child.GetComponent<BaseUI>()) Destroy(_child.gameObject);
        }
    }

    /// <summary>
    /// 根据窗口类型尝试得到窗口实体
    /// </summary>
    /// <param name="uIFormBase"></param>
    /// <returns></returns>
    private BaseUI ReturnFormByType(UIFormBaseType uIFormBase)
    {
        string formName = ReturnFormNameByType(uIFormBase);
        BaseUI _form = (ReturnChildTransformByName(transform, formName)!=null) ? ReturnChildTransformByName(transform, formName).GetComponent<BaseUI>() :
            ResourcesManager.Instance.CreateUIForm(uIFormBase);
        return _form;
    }

    /// <summary>
    /// 根据窗口类型得到窗口名称
    /// </summary>
    /// <param name="uIFormBase"></param>
    /// <returns></returns>
    private string ReturnFormNameByType(UIFormBaseType uIFormBase)
    {
        string formName = "";
        switch (uIFormBase)
        {
            case UIFormBaseType.StartUIForm:
                formName = "StartUIForm";
                break;
            case UIFormBaseType.MainUIForm:
                formName = "MainUIForm";
                break;
            default:
                break;
        }
        return formName;
    }

    /// <summary>
    /// 根据名字得到父节点下的制定子物体
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
    private Transform ReturnChildTransformByName(Transform parent,string childName)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).name == childName) return parent.GetChild(i);
        }
        return null;
    }
}
