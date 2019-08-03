using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    [Header("Name UI Element")]
    public TextMeshProUGUI NameText;

    [Header("Dialogue UI Element")]
    public TextMeshProUGUI DialogueText;

    [Header("Whole UI Panel")]
    public GameObject DialogueCanvas;

    [Header("Continur Text")]
    public GameObject Continue;

    [Header("Sound For Typing")]
    public AudioSource textSound;

    private bool talking;
    public Queue<string> sentences;

    #endregion Variables

    private bool canAdvance = false;

    // Use this for initialization
    private void Start()
    {
        //create Queue
        sentences = new Queue<string>();
        textSound = GetComponent<AudioSource>();
        NameText.text = "";
        DialogueText.text = "";
        talking = false;
        DialogueCanvas.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (talking)
        {
            if (Input.GetButtonDown("Attack") && canAdvance)
            {
                DisplaySentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialog)
    {
        canAdvance = false;
        talking = true;
        GlobalVariables.canMove = false;
        GlobalVariables.canPause = false;
        FindObjectOfType<PlayerController>().PlayerStop();
        //empty Queue
        sentences.Clear();

        //Add sentences to Queue
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DialogueCanvas.gameObject.SetActive(true);

        NameText.text = dialog.SpeakerName;
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        //check for empty queue and return
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Continue.gameObject.SetActive(false);

        //pull sentences from Queue
        string output = sentences.Dequeue();
        StopCoroutine(TypeSentence(output));
        StartCoroutine(TypeSentence(output));
    }

    public void EndDialogue()
    {
        DialogueCanvas.gameObject.SetActive(false);
        talking = false;
        GlobalVariables.canMove = true;
        GlobalVariables.canPause = true;
    }

    private IEnumerator TypeSentence(string sentence)
    {
        canAdvance = false;
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            textSound.pitch = Random.Range(1.1f, 1.3f);
            textSound.Play();
            yield return new WaitForSeconds(textSound.clip.length - .2f);
        }
        Continue.gameObject.SetActive(true);
        canAdvance = true;
    }
}