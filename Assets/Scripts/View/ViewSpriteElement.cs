//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class ViewSpriteElement : IViewElement
{
    private SpriteRenderer renderer;
    public Vector2 defaultPosition;

    public bool SetActive
    {
        get { return SetActive; }

        set { renderer.gameObject.SetActive(value); }
    }

    public ViewSpriteElement(Sprite sprite, Vector2 defaultPosition)
    {
        CreateGraphicObject(sprite);
        this.defaultPosition = defaultPosition;
        renderer.transform.position = defaultPosition;
        SetActive = false;
    }

    private void CreateGraphicObject(Sprite sprite)
    {
        GameObject graphicObject = new GameObject();
        renderer = graphicObject.AddComponent<SpriteRenderer>();
        ChangeGraphic(sprite);
    }

    public void ChangeGraphic(Sprite sprite)
    {
        renderer.sprite = sprite;
    }
}
