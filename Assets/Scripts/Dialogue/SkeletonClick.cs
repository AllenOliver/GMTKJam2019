using UnityEngine;

public class SkeletonClick : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnMouseDown() => FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
}