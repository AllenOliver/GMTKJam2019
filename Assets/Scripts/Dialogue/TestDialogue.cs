using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public Dialogue objects;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(objects);
        }
    }
}