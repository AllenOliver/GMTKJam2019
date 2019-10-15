using UnityEngine;

namespace Assets.Scripts.Globals
{
    public static class GameObjectExtension
    {
        public static void Active(this GameObject go)
        {
            go.SetActive(true);
        }

        public static void Inactive(this GameObject go)
        {
            go.SetActive(false);
        }
    }
}