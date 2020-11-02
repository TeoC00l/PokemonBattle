//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Trainer playerTrainer = new Trainer("Red");
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 5);
        playerTrainer.AddPokemon(bulbasaur);

        Trainer enemyTrainer = new Trainer("Blue");
        Pokemon charmander = new Pokemon("Charmander", 5);
        enemyTrainer.AddPokemon(charmander);
    }
}
