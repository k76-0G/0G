using System.Collections.Generic;
using UnityEngine;

namespace _0G
{
    public static class ExtensionMethods
    {
        // GAME OBJECT

        public static GameObject NewChildGameObject<T>(this GameObject parentGameObject) where T : Component
        {
            GameObject go;
            System.Type type = typeof(T);
            if (type == typeof(Transform))
            {
                go = new GameObject(type.ToString());
            }
            else
            {
                go = new GameObject(type.ToString(), type);
            }
            go.transform.parent = parentGameObject.transform;
            return go;
        }

        public static T NewChildGameObjectTyped<T>(this GameObject parentGameObject) where T : Component
            => parentGameObject.NewChildGameObject<T>().GetComponent<T>();

        // LIST <T>

        public static void Shift<T>(this List<T> list, T item, int indexDelta)
        {
            int index = list.IndexOf(item);
            list.RemoveAt(index);
            list.Insert(index + indexDelta, item);
        }
    }
}