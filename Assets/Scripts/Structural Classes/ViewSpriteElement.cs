//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class ViewSpriteElement : IViewElement
{
    private string name;
    private GameObject graphic;
    private Vector2 defaultPosition;

    public bool SetActive
    {
        get
        {
            return SetActive;
        }

        set
        {
            graphic.SetActive(value);
        }
    }

    public ViewSpriteElement(string name, Sprite sprite, Vector2 defaultPosition)
    {
        graphic = CreateGraphicObject(sprite);
        this.name = name;
        this.defaultPosition = defaultPosition;
        graphic.transform.position = defaultPosition;
        SetActive = false;
    }

    private GameObject CreateGraphicObject(Sprite sprite)
    {
        GameObject graphicObject = new GameObject();
        graphicObject.AddComponent<SpriteRenderer>().sprite = sprite;

        return graphicObject;
    }
}
