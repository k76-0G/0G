using UnityEngine;

namespace _0G
{
    //     0G  [ z e r o  g r a v i t y ]

    public class Loader : MonoBehaviour
    {
        public static Loader Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }
    }
}