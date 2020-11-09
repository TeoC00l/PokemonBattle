//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

namespace PokemonBattle
{
    public class DataTable<T> : IBattleInterfaceItem
    {
        private int row = default;
        private int column = default;
    
        private int noOfRows;
        private int noOfColumns;
    
        private T[,] table;
    
        public DataTable(int noOfRows, int noOfColumns, T[] t)
        {
            this.noOfRows = noOfRows;
            this.noOfColumns = noOfColumns;
    
            table = new T[noOfRows, noOfColumns];
            
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

            return true;
        }
        
        public T ConfirmSelection()
        {
            return table[row,column];
        }
        
        private bool CheckForNullIndex(int row, int column)
        {
            if (row > noOfRows-1 || column > noOfColumns-1)
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
                    table[j, i] = t[currentIndex];
                    currentIndex++;
                }
            }
        }
    }
}
