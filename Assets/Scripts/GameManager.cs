using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelUIManager ui;

    // Start is called before the first frame update
    private void Start()
    {
        ui = FindObjectOfType<LevelUIManager>();
        if (!GlobalVariables.audioOn)
            StopAllSound();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ui.PauseGame();
        }
    }

    public void StopAllSound()
    {
        GlobalVariables.audioOn = false;
        var sounds = FindObjectsOfType<AudioSource>().ToList();
        sounds.ForEach(x => x.enabled = false);
    }

    public void EnableSound()
    {
        GlobalVariables.audioOn = true;
        var sounds = FindObjectsOfType<AudioSource>().ToList();
        sounds.ForEach(x => x.enabled = true);
    }
}