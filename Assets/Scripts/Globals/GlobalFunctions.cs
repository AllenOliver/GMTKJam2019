using UnityEngine;

namespace Assets.Scripts.Globals
{
    public static class GlobalFunctions
    {
        public static void DebugLog(string message) => Debug.Log($"{message}");
    }
}