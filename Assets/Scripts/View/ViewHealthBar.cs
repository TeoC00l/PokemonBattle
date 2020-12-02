//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViewHealthBar : IViewElement
{
    private BattleViewElements elements;
    private Image bar;

    private int currentHP;
    public int CurrentHP
    {
        get
        {
            return currentHP;
        }
        set
        {
            
        }
    }

    private int maxHP;

    private RectTransform healthBarTransform;

    public bool SetActive { get; set; }

    public ViewHealthBar(int maxHP, int currentHP, Vector2 position)
    {
        elements = BattleViewElements.Instance;
        this.maxHP = maxHP;
        this.CurrentHP = currentHP;

        SetUpGraphics(position);
    }

    private void SetUpGraphics(Vector2 position)
    {
        GameObject healthBarObject = new GameObject();
        healthBarObject.transform.SetParent(elements.canvas.transform);
        healthBarTransform = healthBarObject.AddComponent<RectTransform>();
        healthBarObject.AddComponent<Image>().color = Color.red;

        healthBarTransform.pivot = Vector2.up;
        healthBarTransform.localScale = new Vector3(1,1,1);
        healthBarTransform.sizeDelta = new Vector3(elements.healthBarWidth,elements.healthBarHeight, 1f);
        healthBarTransform.localPosition = position;
    }

    private void UpdateHP()
    {
        
    }
}
