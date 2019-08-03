using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Object", menuName = "Tools/Create New Dialogue", order = 151)]
public class Dialogue : ScriptableObject
{
    public string SpeakerName;

    [TextArea(3, 10)]
    public string[] sentences;
}