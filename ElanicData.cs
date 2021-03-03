using System.Collections.Generic;
using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace _0G
{
    public class ElanicData : ScriptableObject
    {
#if ODIN_INSPECTOR
        [ReadOnly]
#endif
        public int serializedVersion = 1;

        public List<Texture2D> Imprints = new List<Texture2D>();
        public List<Color> Colors = new List<Color>();
        public List<ElanicFrame> Frames = new List<ElanicFrame>();
    }
}