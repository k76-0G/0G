using UnityEngine;

namespace _0G
{
    public class Flow : MonoBehaviour
    {
        public static Flow Instance { get; private set; }

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