using TMPro;

public class LocalizationTextMeshPro : LocalizationText
{
    TextMeshProUGUI text;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public override void SetText(string value)
    {
        text.text = value;
    }

    public override string GetText()
    {
        return text.text;
    }
}
