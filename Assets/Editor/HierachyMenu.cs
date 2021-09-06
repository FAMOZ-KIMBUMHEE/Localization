using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class HierachyMenu : MonoBehaviour
{
    [MenuItem("GameObject/UI/Localization/LocalizationText")]
    static void CreateTextPrefab()
    {
        GameObject go = new GameObject("LocalizationText");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;
        go.AddComponent<Text>();
        go.AddComponent<LocalizationText>();
        go.AddComponent<ContentSizeFitter>();

        go.transform.localPosition = Vector3.zero;
        go.GetComponent<Text>().text = "내용을 입력하세요...";
        go.GetComponent<Text>().fontSize = 34;
        go.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        go.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    [MenuItem("GameObject/UI/Localization/LocalizationText-TMP")]
    static void CreateTextMeshProPrefab()
    {
        GameObject go = new GameObject("LocalizationText-TMP");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;
        go.AddComponent<TextMeshProUGUI>();
        go.AddComponent<LocalizationTextMeshPro>();
        go.AddComponent<ContentSizeFitter>();

        go.transform.localPosition = Vector3.zero;
        go.GetComponent<TextMeshProUGUI>().text = "Please enter...";
        go.GetComponent<TextMeshProUGUI>().fontSize = 34;
        go.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        go.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    [MenuItem("GameObject/UI/Localization/LocalizationButton")]
    static void CreateButtonPrefab()
    {
        GameObject go = new GameObject("LocalizationButton");
        GameObject child = new GameObject("LocalizationText");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;

        go.AddComponent<Button>();
        go.AddComponent<RectTransform>();
        go.AddComponent<Image>();

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60);
        go.transform.localPosition = Vector3.zero;

        child.transform.parent = go.transform;
        child.AddComponent<Text>();
        child.AddComponent<LocalizationText>();
        child.AddComponent<ContentSizeFitter>();

        child.transform.localPosition = Vector3.zero;
        child.GetComponent<Text>().text = "Please enter...";
        child.GetComponent<Text>().fontSize = 25;
        child.GetComponent<Text>().color = Color.black;
        child.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        child.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        child.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        child.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
    }

    [MenuItem("GameObject/UI/Localization/LocalizationButton-TMP")]
    static void CreateButtonProPrefab()
    {
        GameObject go = new GameObject("LocalizationButton-TMP");
        GameObject child = new GameObject("LocalizationText-TMP");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;

        go.AddComponent<Button>();
        go.AddComponent<RectTransform>();
        go.AddComponent<Image>();

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60);
        go.transform.localPosition = Vector3.zero;

        child.transform.parent = go.transform;
        child.AddComponent<TextMeshProUGUI>();
        child.AddComponent<LocalizationTextMeshPro>();
        child.AddComponent<ContentSizeFitter>();

        child.transform.localPosition = Vector3.zero;
        child.GetComponent<TextMeshProUGUI>().text = "Please enter...";
        child.GetComponent<TextMeshProUGUI>().fontSize = 25;
        child.GetComponent<TextMeshProUGUI>().color = Color.black;
        child.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        child.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        child.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        child.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
    }

    [MenuItem("GameObject/UI/Localization/LocalizationInputField")]
    static void CreateInputPrefab()
    {
        GameObject go = new GameObject("LocalizationInputField");
        GameObject PlaceHolderChild = new GameObject("LocalizationPlaceHolder");
        GameObject child = new GameObject("LocalText");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;

        go.AddComponent<InputField>();
        go.AddComponent<RectTransform>();
        go.AddComponent<Image>();

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<InputField>().targetGraphic = go.GetComponent<Graphic>();


        child.transform.parent = go.transform;
        child.AddComponent<Text>();
        child.AddComponent<LocalizationText>();

        child.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        child.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        child.GetComponent<RectTransform>().offsetMin = new Vector2(10,6);
        child.GetComponent<RectTransform>().offsetMax = new Vector2(-10, -7);
        child.GetComponent<Text>().text = "";
        child.GetComponent<Text>().fontSize = 14;
        child.GetComponent<Text>().color = Color.black;
        child.GetComponent<Text>().supportRichText = false;


        PlaceHolderChild.transform.parent = go.transform;
        PlaceHolderChild.AddComponent<Text>();
        PlaceHolderChild.AddComponent<LocalizationText>();

        PlaceHolderChild.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        PlaceHolderChild.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        PlaceHolderChild.GetComponent<RectTransform>().offsetMin = new Vector2(10, 6);
        PlaceHolderChild.GetComponent<RectTransform>().offsetMax = new Vector2(-10, -7);
        PlaceHolderChild.GetComponent<Text>().text = "Please enter...";
        PlaceHolderChild.GetComponent<Text>().fontSize = 14;
        PlaceHolderChild.GetComponent<Text>().color = Color.gray;


        go.GetComponent<InputField>().textComponent = child.GetComponent<Text>();
        go.GetComponent<InputField>().placeholder = PlaceHolderChild.GetComponent<Text>();
    }

    [MenuItem("GameObject/UI/Localization/LocalizationInputField-TMP")]
    static void CreateInputProPrefab()
    {
        GameObject go = new GameObject("LocalizationInputField-TMP");
        GameObject PlaceHolderChild = new GameObject("LocalizationPlaceHolder-TMP");
        GameObject child = new GameObject("LocalizationText-TMP");
        if (Selection.activeTransform != null)
            go.transform.parent = Selection.activeTransform;

        go.AddComponent<TMP_InputField>();
        go.AddComponent<RectTransform>();
        go.AddComponent<Image>();

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<TMP_InputField>().targetGraphic = go.GetComponent<Graphic>();


        child.transform.parent = go.transform;
        child.AddComponent<TextMeshProUGUI>();
        child.AddComponent<LocalizationTextMeshPro>();

        child.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        child.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        child.GetComponent<RectTransform>().offsetMin = new Vector2(10, 6);
        child.GetComponent<RectTransform>().offsetMax = new Vector2(-10, -7);
        child.GetComponent<TextMeshProUGUI>().text = "";
        child.GetComponent<TextMeshProUGUI>().fontSize = 14;
        child.GetComponent<TextMeshProUGUI>().color = Color.black;
        child.GetComponent<TextMeshProUGUI>().richText = false;


        PlaceHolderChild.transform.parent = go.transform;
        PlaceHolderChild.AddComponent<TextMeshProUGUI>();
        PlaceHolderChild.AddComponent<LocalizationTextMeshPro>();
        
        PlaceHolderChild.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        PlaceHolderChild.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        PlaceHolderChild.GetComponent<RectTransform>().offsetMin = new Vector2(10, 6);
        PlaceHolderChild.GetComponent<RectTransform>().offsetMax = new Vector2(-10, -7);
        PlaceHolderChild.GetComponent<TextMeshProUGUI>().text = "Please enter...";
        PlaceHolderChild.GetComponent<TextMeshProUGUI>().fontSize = 14;
        PlaceHolderChild.GetComponent<TextMeshProUGUI>().color = Color.gray;


        go.GetComponent<TMP_InputField>().textComponent = child.GetComponent<TextMeshProUGUI>();
        go.GetComponent<TMP_InputField>().placeholder = PlaceHolderChild.GetComponent<TextMeshProUGUI>();
    }
}
