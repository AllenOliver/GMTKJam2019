using System.Collections;
using UnityEngine;

public class TriggerSkeleton : TriggerInteractable
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HasBeenTriggered)
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    StartCoroutine(KillSkeleton());
                    break;
            }
        }
    }

    private IEnumerator KillSkeleton()
    {
        HasBeenTriggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        yield return new WaitForSeconds(5f);
        GetComponent<Animator>().SetTrigger("Die");
    }
}