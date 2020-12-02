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
                if (textElement != null)
                {
                    textElement.SetActive = value;
                }
            }
        }
    }

    public ViewDataTable(DataTable<IBattleInterfaceItem> dataTable, float columnDistance, float rowDistance, Sprite overlaySprite, Vector2 position, int padding)
    {
        Name = dataTable.Name;
        elements = BattleViewElements.Instance;
        textElements = new ViewTextElement[dataTable.NoOfColumns,dataTable.NoOfRows];

        DrawTable(dataTable, columnDistance, rowDistance, overlaySprite, position,padding);
    }

    private void DrawTable(DataTable<IBattleInterfaceItem> table, float columnDistance, float rowDistance, Sprite overlaySprite, Vector2 position, int padding)
    {
        positions = new Vector2[table.NoOfColumns,table.NoOfRows];
        
        IBattleInterfaceItem[,] interfaceItems = table.Table;

        float x = position.x + padding;
        float y = position.y -padding;
        
        overlay = new ViewSpriteElement(overlaySprite, position);
        cursor = new ViewSpriteElement(elements.cursor, new Vector2(x,y) + elements.horizontalCursorDefaultOffset);
        
        for (int i = 0; i < table.NoOfColumns; i++)
        {
            y = position.y -padding;
            x += columnDistance * i;

            for (int j = 0; j < table.NoOfRows; j++)
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

    public void UpdateCursor(DataTable<IBattleInterfaceItem> dataTable)
    {
        cursor.CurrentPosition = textElements[dataTable.CursorColumn, dataTable.CursorRow].position + elements.horizontalCursorDefaultOffset;
    }
}
