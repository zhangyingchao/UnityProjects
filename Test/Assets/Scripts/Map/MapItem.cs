using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem:MonoBehaviour
{
    private int cross;
    private int portait;

    public MapItem(int _cross,int _portait)
    {
        SetMapItemPosition(_cross,_portait);
    }

    /// <summary>
    /// 设置位置坐标
    /// </summary>
    void SetMapItemPosition(int _cross, int _portait)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(_cross*100,_portait*100);
    }
}
