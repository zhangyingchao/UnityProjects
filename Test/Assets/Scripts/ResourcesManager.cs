using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AllConstInGame;
using System.ComponentModel.Design;
using System;
using System.Linq;

public class ResourcesManager : Singleton<ResourcesManager>
{
    private Canvas mycanvas;
    private Dictionary<Texture, string> portraitsDic;
    protected override void Awake()
    {
        mycanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        LoadPortraitsBySex();
    }

    public BaseUI CreateUIForm(UIFormBaseType uIFormBase)
    {
        GameObject go = Resources.Load(ReturnPathByType(uIFormBase)) as GameObject;
        GameObject ui = Instantiate(go);

        ui.transform.parent = mycanvas.transform;
        ui.transform.position = Vector3.zero;
        ui.transform.eulerAngles = Vector3.zero;
        ui.transform.localScale = Vector3.one;
        
        ui.name = ui.name.Replace("(Clone)", "");
        return ui.GetComponent<BaseUI>();
    }

    public void LoadPortraitsBySex()
    {
        List<Texture> portraitsListOfFemale = Resources.LoadAll<Texture>("Portraits/Female").ToList();
        List<Texture> portraitsListOfMale = Resources.LoadAll<Texture>("Portraits/Male").ToList();

        portraitsDic = new Dictionary<Texture, string>();

        for (int i=0;i< portraitsListOfFemale.Count; i++)
        {
            portraitsDic.Add(portraitsListOfFemale[i], "Female");
        }
        for (int i = 0; i < portraitsListOfFemale.Count; i++)
        {
            portraitsDic.Add(portraitsListOfMale[i], "Male");
        }
    }

    ///---------------------------------------------------------------------------------------------
    ///---------------------------------------------------------------------------------------------
    ///---------------------------------------------------------------------------------------------

    private string ReturnPathByType(UIFormBaseType uIFormBase)
    {
        switch (uIFormBase)
        {
            case UIFormBaseType.StartUIForm:
                return UIFormPath.StartUIFormPath;
            case UIFormBaseType.MainUIForm:
                return UIFormPath.MainUIFormPath;
            default:
                return null;
        }
    }

    public Texture RandomTextureInPortraitsDic(string gender)
    {
        gender = (gender == "男") ? "Male" : "Female";
        Debug.Log("gender:"+ gender);
        List<Texture> textureList = portraitsDic.Where(t => t.Value == gender).Select(t => t.Key).ToList();
        Debug.Log("textureList.count:"+ textureList.Count);
        int r = UnityEngine.Random.Range(0, textureList.Count);
        Debug.Log("R:"+r);
        return textureList[r];
    }

}
