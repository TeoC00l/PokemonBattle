//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Battle : StateMachine
{
    private Trainer player;
    private Trainer enemy;
    private Pokemon playerCurrentPokemon;
    private Pokemon enemyCurrentPokemon;
    
    public override void Initialize()
    {
        states[0] = new StrategyState();
        states[1] = new AttackState();
    }
}
