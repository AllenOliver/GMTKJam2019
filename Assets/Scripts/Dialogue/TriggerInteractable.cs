using UnityEngine;

public class TriggerInteractable : MonoBehaviour
{
    public bool HasBeenTriggered;
    public GameObject Visual;
    public Dialogue dialogue;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HasBeenTriggered)
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    HasBeenTriggered = true;
                    Visual.SetActive(false);
                    break;
            }
        }
    }
}