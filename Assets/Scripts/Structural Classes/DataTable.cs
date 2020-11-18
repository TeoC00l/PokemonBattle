//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace PokemonBattle
{
    public class DataTable<T> : IBattleInterfaceItem where T : IBattleInterfaceItem
    {
        public string Name { get; set; }

        private int row = default;
        private int column = default;

        private int noOfRows;
        private int noOfColumns;

        private T[,] table;

        public DataTable(string name, int noOfRows, int noOfColumns, T[] t)
        {
            Name = name;

            this.noOfRows = noOfRows;
            this.noOfColumns = noOfColumns;

            table = new T[noOfColumns, noOfRows];

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

            int newRowIndex = row + rowDisplacement;
            int newColumnIndex = column + columnDisplacement;

            if (!CheckForNullIndex(newRowIndex, newColumnIndex))
            {
                return false;
            }

            row = newRowIndex;
            column = newColumnIndex;

            Debug.Log(">" + table[row, column]);

            return true;
        }

            public T ConfirmSelection()
            {
                return table[row, column];
            }

            private bool CheckForNullIndex(int row, int column)
            {
                if (row > noOfRows - 1 || column > noOfColumns - 1)
                {
                    return false;
                }
                else if (row < 0 || column < 0)
                {
                    return false;
                }
                else if (table[row, column] == null)
                {
                    return false;
                }

                return true;
            }

            private void FillTable(T[] t)
            {
                int currentIndex = 0;
                int tableSize = t.Length;

                for (int i = 0; i < noOfColumns; i++)
                {
                    for (int j = 0; j < noOfRows; j++)
                    {
                        table[i, j] = t[currentIndex];
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

                for (int i = 0; i < noOfRows; i++)
                {
                    str += " ______________________";
                }
                str += "\n";

                
                for (int i = 0; i < noOfColumns; i++)
                {
                    str += "|";

                    for (int j = 0; j < noOfRows; j++)
                    {
                            
                        if (column == i && row == j) 
                        {
                            item = ">";

                        }
                        else
                        {
                             item = "_";
                        }

                        if (table[j, i] != null)
                        {
                            item += table[j, i].Name;
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
