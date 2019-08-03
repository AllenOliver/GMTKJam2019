using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialog;

    /// <summary>
    /// Starts Dialogue from manager
    /// </summary>
    public virtual void TriggerDialogue() => FindObjectOfType<DialogueManager>().StartDialogue(dialog);
}