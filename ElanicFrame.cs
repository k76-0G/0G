using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace _0G
{
    [System.Serializable]
    public struct ElanicFrame
    {
        public int ImprintIndex;
        
        [HideInInspector]
        public ushort[] PixelX;
        [HideInInspector]
        public ushort[] PixelY;
        [HideInInspector]
        public sbyte[] PixelColorIndex;

#if ODIN_INSPECTOR
        [ShowInInspector]
#endif
        public int DiffPixelCount => PixelColorIndex?.Length ?? 0;

        public bool HasDiffData => DiffPixelCount > 0;
    }
}