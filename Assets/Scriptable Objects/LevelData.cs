using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "Kei Tools/Create New Level Data", order = 151)]
public class LevelData : ScriptableObject
{
    public string LevelName;
    public int LevelIndex;
}