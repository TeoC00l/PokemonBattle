//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;
using UnityEngine.UI;

public class ViewSpriteElement : IViewElement
{
    private Image renderer;
    private GameObject canvas;
    public Vector2 DefaultPosition { get; private set; }

    public Vector2 CurrentPosition
    {
        get
        {
            return renderer.transform.localPosition;
        }

        set
        {
            renderer.transform.localPosition = value;
        }
    }
    public object gameObject;

    public bool SetActive
    {
        get { return SetActive; }

        set { renderer.gameObject.SetActive(value); }
    }

    public ViewSpriteElement(Sprite sprite, Vector2 defaultPosition)
    {
        canvas = BattleViewElements.Instance.canvas;
        this.DefaultPosition = defaultPosition;
        CreateGraphicObject(sprite);
        SetActive = true;
    }

    public void ChangeGraphic(Sprite sprite)
    {
        renderer.sprite = sprite;
        Resize();

    }

    private GameObject CreateGraphicObject(Sprite sprite)
    {
        GameObject graphicObject = new GameObject();
        RectTransform rectTransform = graphicObject.AddComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0f, 1f);
        renderer = graphicObject.AddComponent<Image>();
        renderer.useSpriteMesh = true;
        renderer.preserveAspect = true;
        renderer.sprite = sprite;

        Resize();
        
        graphicObject.transform.SetParent(canvas.transform);
        rectTransform.localPosition = DefaultPosition;

        return graphicObject;
    }

    private void Resize()
    {
        if (renderer.sprite != null)
        {
            float w = renderer.sprite.rect.width / renderer.sprite.pixelsPerUnit;
            float h = renderer.sprite.rect.height / renderer.sprite.pixelsPerUnit;
            renderer.rectTransform.anchorMax = renderer.rectTransform.anchorMin;
            renderer.rectTransform.sizeDelta = new Vector2(w, h);
        }
    }
}