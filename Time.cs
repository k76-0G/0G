using System.Collections.Generic;
using UnityEngine;

namespace _0G
{
    public class Time : MonoBehaviour
    {
        private static readonly List<Time> s_Instances = new List<Time>();

        public static int InstanceCount => s_Instances.Count;

        public static void Setup(GameObject anchor)
        {
            anchor.AddComponent<Time>();
        }

        public static Time GetInstance(int index)
        {
            return s_Instances[index];
        }

        private void Awake()
        {
            s_Instances.Add(this);
        }

        private void OnDestroy()
        {
            s_Instances.Remove(this);
        }
    }
}