//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Battle : StateMachine<Battle>
{
    public Trainer player;
    public Trainer enemy;
    public Pokemon playerCurrentPokemon;
    public Pokemon enemyCurrentPokemon;

    public Battle(Trainer player, Trainer enemy)
    {
        this.player = player;
        this.enemy = enemy;
        
        Initialize();
    }

    public override void Initialize()
    {
        stateDictionary.Add(typeof(StrategyState), new StrategyState(this));
        stateDictionary.Add(typeof(AttackState), new AttackState(this));

        playerCurrentPokemon = player.GetPokemon(0);
        enemyCurrentPokemon = enemy.GetPokemon(0);

        currentState = stateDictionary[typeof(StrategyState)];
    }
}
