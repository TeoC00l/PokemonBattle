//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;
using UnityEngine.UI;

public class ViewTextElement : IViewElement
{
    private Text text;
    private BattleViewElements elements;

    public bool SetActive
    {
        get { return SetActive; }

        set { text.gameObject.SetActive(value); }
    }

    public ViewTextElement(string str, Vector2 position)
    {
        elements = BattleViewElements.Instance;
        SetupTextElement(str, position);
    }

    private void SetupTextElement(string str, Vector2 position)
    {
        GameObject TextObject = CreateTextObject();
        TextObject.transform.SetParent(elements.canvas.transform);
        TextObject.transform.localPosition = position;
        text = TextObject.GetComponent<Text>();
        ChangeText(str);
    }

    public void ChangeText(string str)
    {
        text.text = str;
    }

    private GameObject CreateTextObject()
    {
        GameObject textObject = new GameObject();
        textObject.AddComponent<RectTransform>().pivot = new Vector2(0f,1f);
        text = textObject.AddComponent<Text>();
        text.font = elements.font;
        text.color = Color.black;
        text.fontSize = elements.fontSize;
        text.alignment = TextAnchor.UpperLeft;

        return textObject;
    }
}
