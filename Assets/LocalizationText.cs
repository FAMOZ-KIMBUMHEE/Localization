using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string tag;
    public string position;
    public bool isNotUse;
    Text text;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        text = GetComponent<Text>();
    }

    public virtual void SetText(string value)
    {
        text.text = value;
    }

    public virtual string GetText()
    {
        return text.text;
    }
}
