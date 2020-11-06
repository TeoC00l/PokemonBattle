//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using DataTable = PokemonBattle.DataTable<IBattleInterfaceItem>;

public class Pokemon
{
    private string name;
    private int level;
    private static int MAX_MOVES = 4;

    private Move[] moves;
    private PokemonType pokemonType;
    private Stats stats;
    private PokemonSprites sprites;

    public Pokemon(string name, int level)
    {
        this.name = name;
        this.level = level;
        
        stats = new Stats(PokemonManager.Instance.GetPokemonStats(name), level);
        
        moves = new Move[1];
        moves[0] = MoveManager.Instance.Move("Tackle");
    }

    private Attack GetAttack(int moveIndex)
    {
        Move move = moves[moveIndex];
        return new Attack(move.power, move.accuracy, stats.CurrentSpeed, move.damageType);
    }

    private bool AddMove(Move move)
    {
        if (moves.Length == MAX_MOVES)
        {
            return false;
        }

        int newMoveListLength = moves.Length + 1;
        
        Move[] newMoveList = new Move[newMoveListLength];

        for (int i = 0; i <= moves.Length; i++)
        {
            newMoveList[i] = moves[i];
        }

        newMoveList[newMoveListLength - 1] = move;
        moves = newMoveList;
        
        return true;
    }

    public Move[] GetMoves()
    {
        return moves;
    }

    public DataTable GetAttackTable()
    {
        IBattleInterfaceItem[] attacks = new IBattleInterfaceItem[4];
        
        for (int i = 0; i < moves.Length; i++)
        {
            attacks[i] = (IBattleInterfaceItem) GetAttack(i);
        }

        DataTable attackTable = new DataTable (2,2, attacks);

        return attackTable;
    }
}
