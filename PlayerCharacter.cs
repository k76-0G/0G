using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _0G
{
    public class PlayerCharacter : Character
    {
        public static readonly List<PlayerCharacter> PlayerCharacters = new List<PlayerCharacter>(Player.DEFAULT_PLAYER_COUNT);

        public Player Player;

        public static void Setup(GameObject anchor)
        {
            for (int i = 0; i < Player.DEFAULT_PLAYER_COUNT; ++i)
            {
                _ = anchor.NewChildGameObject<PlayerCharacter>();
            }
        }

        private void Awake()
        {
            PlayerCharacters.Add(this);
            Player = Player.LocalPlayers[PlayerCharacters.Count - 1];
        }

        private void OnDestroy()
        {
            PlayerCharacters.Remove(this);
        }
    }
}