using Cinemachine;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelUIManager ui;

    public LevelData Data;

    public ParticleSystem AfterImage;

    public CinemachineVirtualCamera Camera;

    // Start is called before the first frame update
    private void Start()
    {
        GlobalVariables.canMove = true;
        ui = FindObjectOfType<LevelUIManager>();
        ui.UpdateLevelName(Data.LevelName);
        if (!GlobalVariables.audioOn)
            StopAllSound();
        var ps = AfterImage.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = Data.AfterImageColor;
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