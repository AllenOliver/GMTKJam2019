using System.Collections;
using UnityEngine;

public class TriggerInteractableUI : TriggerInteractable
{
    public string Message;
    public GrantPowerScript PowerToGrant;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HasBeenTriggered)
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    StartCoroutine(StartTriggerDialogue());
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (HasBeenTriggered)
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    FindObjectOfType<LevelUIManager>().ShowMessage(Message);
                    GetComponent<BoxCollider2D>().enabled = false;
                    break;
            }
        }
    }

    private IEnumerator StartTriggerDialogue()
    {
        GlobalVariables.canMove = false;
        FindObjectOfType<PlayerController>().PlayerStop();
        yield return new WaitForSeconds(1f);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        HasBeenTriggered = true;
        Visual.SetActive(false);
        PowerToGrant.GrantPower();
    }
}