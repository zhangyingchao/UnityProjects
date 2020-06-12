using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicMap : MonoBehaviour
{
    //2500*1500
    private int widthMax = 2500;
    private int heightMax = 1500;
    public Button mapItemPrefab;
    private int widthBase = 100;
    private int heightBase = 100;
    // Start is called before the first frame update
    void Start()
    {
        CreateBaseMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBaseMap()
    {
        for (int w = 0;w<widthMax/widthBase;w++)
        {
            for (int h=0;h<heightMax/heightBase;h++)
            {
                Button item = Instantiate(mapItemPrefab);
                item.transform.SetParent(transform);
                item.transform.localScale = Vector3.one;
                RectTransform rect = item.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(w*100,h*100);
            }
        }
    }
}
