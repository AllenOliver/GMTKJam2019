using System.Collections;
using UnityEngine;

public class Skeleton_Attack : Interactable
{
    private Animator anim;

    /// <summary>
    /// Starts Dialogue from manager
    /// </summary>
    public override void TriggerDialogue() => StartCoroutine(talkEnumerator());

    private IEnumerator talkEnumerator()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
        yield return new WaitForSeconds(3f);
        anim = GetComponent<Animator>();
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(.5f);
        GetComponent<AudioSource>().Play();
    }
}