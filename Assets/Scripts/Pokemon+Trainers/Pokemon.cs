//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using DataTable = PokemonBattle.DataTable<IBattleInterfaceItem>;

public class Pokemon : ISubject
{
    public string Name { get; private set; } 
    private int level;
    private static int MAX_MOVES = 4;

    private Move[] moves;
    private PokemonType pokemonType;
    public Stats Stats { get; private set; }

    public delegate void Fainted(Pokemon pokemon);
    public event Fainted OnFainted;

    private Action observerActions;
    
    public Pokemon(string name, int level)
    {
        this.Name = name;
        this.level = level;

        Stats = new Stats(PokemonManager.Instance.GetPokemonStats(name), level);

        moves = new Move[1];
        moves[0] = MoveManager.Instance.Move("tackle");
    }

    public Attack GetAttack(int moveIndex)
    {
        Move move = moves[moveIndex];
        return new Attack(move.name, move.power, move.accuracy, Stats.CurrentSpeed, move.damageType, this);
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

    public int GetNoOfMoves()
    {
        return moves.Length;
    }

    public DataTable GetAttackTable()
    {
        IBattleInterfaceItem[] attacks = new IBattleInterfaceItem[4];

        for (int i = 0; i < moves.Length; i++)
        {
            attacks[i] = (IBattleInterfaceItem) GetAttack(i);
        }

        DataTable attackTable = new DataTable("attack",2, 2, attacks);

        return attackTable;
    }

    public void RecieveAttack(Attack attack)
    {
        TakeDamage(attack.damage);
    }

    private void TakeDamage(int damage)
    {
        Stats.CurrentHP -= damage;

        if (Stats.CurrentHP <= 0)
        {
            Faint();
        }
    }

    private void Faint()
    {
        OnFainted?.Invoke(this);
    }

    public void registerObserver(IObserver observer)
    {
        observerActions += observer.Update;
    }

    public void removeObserver(IObserver observer)
    {
        observerActions -= observer.Update;
    }

    public void notifyObservers()
    {
        observerActions();
    }
}