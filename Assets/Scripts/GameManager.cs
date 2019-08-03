using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelUIManager ui;

    // Start is called before the first frame update
    private void Start()
    {
        ui = FindObjectOfType<LevelUIManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ui.PauseGame();
        }
    }
}