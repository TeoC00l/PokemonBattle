//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using PokemonBattle;
using UnityEngine;

public class ViewDataTable : IViewElement
{
    private BattleViewElements elements;

    private ViewTextElement[,] textElements;
    private ViewSpriteElement overlay;
    private ViewSpriteElement cursor;
    
    private Vector2[,] positions;

    public string Name { get; private set; }
    public bool SetActive
    {
        get { return SetActive; }

        set
        {
            overlay.SetActive = value;
            cursor.SetActive = value;

            foreach (ViewTextElement textElement in textElements)
            {
                textElement.SetActive = value;
            }
        }
    }

    public ViewDataTable(DataTable<IBattleInterfaceItem> dataTable, float columnDistance, float rowDistance, Sprite overlaySprite, Vector2 position)
    {
        Name = dataTable.Name;
        
        textElements = new ViewTextElement[dataTable.NoOfColumns,dataTable.NoOfRows];

        DrawTable(dataTable, columnDistance, rowDistance, overlaySprite, position);
    }

    private void DrawTable(DataTable<IBattleInterfaceItem> table, float columnDistance, float rowDistance, Sprite overlaySprite, Vector2 position)
    {
        positions = new Vector2[table.NoOfColumns,table.NoOfRows];
        
        IBattleInterfaceItem[,] interfaceItems = table.Table;
        ViewSpriteElement overlayElement = new ViewSpriteElement(overlaySprite, position);

        float x = position.x;
        float y = position.y;
        
        for (int i = 0; i < table.NoOfColumns; i++)
        {
            x += columnDistance * i;

            for (int j = 0; i < table.NoOfRows; i++)
            {
                y -= rowDistance * j;
                Vector2 elementPosition = new Vector2(x,y);

                if (table.Table[i, j] != null)
                {
                    textElements[i,j] = new ViewTextElement(table.Table[i,j].Name, elementPosition);
                }
            }
        }
    }
}
