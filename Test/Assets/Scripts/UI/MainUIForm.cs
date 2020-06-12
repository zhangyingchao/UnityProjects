using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIForm : BaseUI
{
    private Button userButton;
    private Text timeText;
    //累计时间（60秒=1天）
    private int cumulativeTime = 0;
    private float timer = 1.0f;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            cumulativeTime++;
            timer = 1.0f;
        }
        //不准确临时
        timeText.text = "方块历" + ReturnCalendarByCumulativeTime();
    }

    protected override void UIFormInit()
    {
        SetLeftTopBarInMainUI();
    }

    void SetLeftTopBarInMainUI()
    {
        if (!userButton) userButton = transform.Find("User").GetComponent<Button>();
        if (!timeText) timeText = transform.Find("TimeText").GetComponent<Text>();

        
        UserData _data = Global.userData;
        userButton.GetComponentInChildren<RawImage>().texture = _data.portraitTexture;
        
    }

    string ReturnCalendarByCumulativeTime()
    {
        int year = cumulativeTime/365;
        int month = (cumulativeTime % 365) / 30;
        int day = cumulativeTime % 365 % 30;
        return year+"年"+month+"月"+day+"日";
    }
}
