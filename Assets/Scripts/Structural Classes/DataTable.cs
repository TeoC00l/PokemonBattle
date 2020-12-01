//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace PokemonBattle
{
    public class DataTable<T> : IBattleInterfaceItem where T : IBattleInterfaceItem
    {
        public string Name { get; set; }
        public int NoOfRows { get; private set; }
        public int NoOfColumns { get; private set; }
        public int CursorRow { get; private set; }
        public int CursorColumn { get; private set; }
        public T[,] Table { get; private set; }

        public DataTable(string name, int noOfRows, int noOfColumns, T[] t)
        {
            Name = name;

            this.NoOfRows = noOfRows;
            this.NoOfColumns = noOfColumns;

            Table = new T[noOfColumns, noOfRows];

            FillTable(t);
        }

        public bool Navigate(InputCommand inputCommand)
        {
            int rowDisplacement = 0;
            int columnDisplacement = 0;

            if (inputCommand == InputCommand.Up)
            {
                columnDisplacement--;
            }
            else if (inputCommand == InputCommand.Down)
            {
                columnDisplacement++;
            }
            else if (inputCommand == InputCommand.Left)
            {
                rowDisplacement--;
            }
            else if (inputCommand == InputCommand.Right)
            {
                rowDisplacement++;
            }

            int newRowIndex = CursorRow + rowDisplacement;
            int newColumnIndex = CursorColumn + columnDisplacement;

            if (!CheckForNullIndex(newRowIndex, newColumnIndex))
            {
                return false;
            }

            CursorRow = newRowIndex;
            CursorColumn = newColumnIndex;

            Debug.Log(">" + Table[CursorRow, CursorColumn]);

            return true;
        }

            public T ConfirmSelection()
            {
                return Table[CursorRow, CursorColumn];
            }

            private bool CheckForNullIndex(int row, int column)
            {
                if (row > NoOfRows - 1 || column > NoOfColumns - 1)
                {
                    return false;
                }
                else if (row < 0 || column < 0)
                {
                    return false;
                }
                else if (Table[row, column] == null)
                {
                    return false;
                }

                return true;
            }

            private void FillTable(T[] t)
            {
                int currentIndex = 0;

                for (int i = 0; i < NoOfColumns; i++)
                {
                    for (int j = 0; j < NoOfRows; j++)
                    {
                        Table[i, j] = t[currentIndex];
                        currentIndex++;
                    }
                }
            }

            public void PrintTable()
            {
                string str = "Options: \n \n";
                string item = "";
                int strLength = 20;
                int itemLength = 0;

                for (int i = 0; i < NoOfRows; i++)
                {
                    str += " ______________________";
                }
                str += "\n";

                
                for (int i = 0; i < NoOfColumns; i++)
                {
                    str += "|";

                    for (int j = 0; j < NoOfRows; j++)
                    {
                            
                        if (CursorColumn == i && CursorRow == j) 
                        {
                            item = ">";

                        }
                        else
                        {
                             item = "_";
                        }

                        if (Table[j, i] != null)
                        {
                            item += Table[j, i].Name;
                            itemLength = item.Length;
                        }
                        else
                        {
                            itemLength = 0;
                        }
                        
                        for (int y = 0; y < strLength-itemLength; y++)
                        {
                            item += "_";
                        }

                        str += item + "|";
                    }

                    str += "\n";
                }
                
                Debug.Log(str);
            }

        }
}
