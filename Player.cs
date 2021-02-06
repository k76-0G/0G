using System.Collections.Generic;
using UnityEngine;

namespace _0G
{
    public class Player : MonoBehaviour
    {
        public const int DEFAULT_PLAYER_COUNT = 4;

        public static readonly List<Player> LocalPlayers = new List<Player>(DEFAULT_PLAYER_COUNT);

        public int Number => LocalPlayers.IndexOf(this);

        public static void Setup(GameObject anchor)
        {
            for (int i = 0; i < DEFAULT_PLAYER_COUNT; ++i)
            {
                anchor.AddComponent<Player>();
            }
        }

        private void Awake()
        {
            LocalPlayers.Add(this);
        }

        private void OnDestroy()
        {
            LocalPlayers.Remove(this);
        }
    }
}