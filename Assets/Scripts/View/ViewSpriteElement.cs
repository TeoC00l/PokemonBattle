//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;
using UnityEngine.UI;

public class ViewSpriteElement : IViewElement
{
    private Image renderer;
    private GameObject canvas;
    public Vector2 defaultPosition;
    public object gameObject;
    
    public bool SetActive
    {
        get { return SetActive; }

        set { renderer.gameObject.SetActive(value); }
    }

    public ViewSpriteElement(Sprite sprite, Vector2 defaultPosition)
    {
        canvas = BattleViewElements.Instance.canvas;
        CreateGraphicObject(sprite);
        this.defaultPosition = defaultPosition;
        renderer.transform.position = defaultPosition;
        SetActive = true;

    }

    // private void CreateGraphicObject(Sprite sprite)
    // {
    //     GameObject graphicObject = new GameObject();
    //     renderer = graphicObject.AddComponent<SpriteRenderer>();
    //     ChangeGraphic(sprite);
    // }

    public void ChangeGraphic(Sprite sprite)
    {
        renderer.sprite = sprite;
    }
    
    private GameObject CreateGraphicObject(Sprite sprite)
    {
        GameObject graphicObject = new GameObject();
        RectTransform rectTransform =  graphicObject.AddComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0f, 1f);
        renderer = graphicObject.AddComponent<Image>();
        renderer.useSpriteMesh = true;
        renderer.preserveAspect = true;
        renderer.sprite = sprite;

        graphicObject.transform.SetParent(canvas.transform);

        return graphicObject;
    }
}
