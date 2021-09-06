using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] string xmlDataName;
    public enum LANGUAGE { KR, EN, CH, JA, NONE };
    [HideInInspector] public LANGUAGE language;
    [HideInInspector] public LANGUAGE selected_lang = LANGUAGE.NONE;
    
    [HideInInspector] public LocalizationText[] textUIArray;

    //xml 다국어 코드 값 (xml 형식에 따라 수정)
    [SerializeField] string[] lang_order = { "kr_a", "kr_b", "kr_c", "en_a", "en_b", "en_c", "ch_a", "ch_b", "ch_c", "ja_a", "ja_b", "ja_c" };
    //xml로 부터 스크립트데이터 저장
    public Dictionary<string, Dictionary<string, string>> scripts = new Dictionary<string, Dictionary<string, string>>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        LoadXML();

        if (selected_lang != LANGUAGE.NONE)
        {
            language = selected_lang;
        }
    }

    void LoadXML()
    {
        TextAsset tAsset = Resources.Load(xmlDataName) as TextAsset;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(tAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("Root/script");

        foreach (XmlNode node in nodes)
        {
            Dictionary<string, string> texts = new Dictionary<string, string>();

            for (int i = 0; i < lang_order.Length; i++)
            {
                string key = lang_order[i];

                bool isCanRead = true;

                try
                {
                    node.SelectSingleNode(key).GetType();
                }
                catch (Exception e)
                {
                    isCanRead = false;
                    //print("error is : " + e);
                }

                if (isCanRead)
                {
                    texts.Add(key, node.SelectSingleNode(key).InnerText);
                }
            }
            //print("no : " + node.SelectSingleNode("no").InnerText);
            scripts.Add(node.SelectSingleNode("no").InnerText, texts);
        }

        print("language load done!");
    }

    public string GetScript(string key, string position)
    {
        string value = "";

        switch (language)
        {
            case LANGUAGE.KR: // KR
                try
                {
                    value = scripts[key]["kr_" + position];

                }
                catch
                {
                    value = "";
                }
                break;

            case LANGUAGE.EN: // EN
                try
                {
                    value = scripts[key]["en_" + position];
                }
                catch
                {
                    value = "";
                }
                break;

            case LANGUAGE.CH: // CH
                try
                {
                    value = scripts[key]["ch_" + position];
                }
                catch
                {
                    value = "";
                }
                break;

            case LANGUAGE.JA: // JA
                try
                {
                    value = scripts[key]["ja_" + position];
                }
                catch
                {
                    value = "";
                }
                break;

        }

        return value;
    }

    //전체텍스트에 로컬라이제이션 제공
    public void SetScripts(int langNum)
    {
        string lang = "kr_";
        switch (langNum)
        {
            case 1:
                lang = "en_";
                break;
            case 2:
                lang = "ch_";
                break;
            case 3:
                lang = "ja_";
                break;
        }

        if (textUIArray.Length <= 0)
        {
            textUIArray = GameObject.FindObjectsOfType<LocalizationText>();
        }

        foreach (var text in textUIArray)
        {
            if (text.isNotUse) continue;

            foreach (var script in scripts)
            {
                if (text.tag == script.Key)
                {
                    text.SetText(script.Value[lang + text.position]);
                    break;
                }
            }
        }
    }

}
