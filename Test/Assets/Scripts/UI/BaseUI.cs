using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum UIFormBaseType
{
    StartUIForm,
    MainUIForm,
    None
}

public enum UIFormAppearsType
{
    NormalUIForm,
    FixedUIForm,
    PopupUIForm,
    None
}

public abstract class BaseUI : MonoBehaviour
{
    protected UIFormAppearsType appearsType = UIFormAppearsType.None;
    public bool uiFormState = false;
    private void OnEnable()
    {
        UIFormInit();
    }

    protected virtual void Awake()
    {
        
    }

    public virtual void ShowUI(Action action = null) 
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1, .2f).OnComplete(delegate {
            Debug.Log("显示完毕");
            cg.interactable = cg.blocksRaycasts = true;
            uiFormState = true;
            action?.Invoke();
        });
    }

    public virtual void HideUI(Action action = null) 
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 0, .2f).OnComplete(delegate {
            cg.interactable = cg.blocksRaycasts = false;
            uiFormState = false;
            action?.Invoke();
        });
    }
    public virtual void DestroyUI()
    {
        Destroy(gameObject);
    }

    protected abstract void UIFormInit();
}
