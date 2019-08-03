using System.Collections;
using TMPro;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    #region Show UI Message

    public TextMeshProUGUI MessageText;
    public GameObject MessagePanel;

    public void ShowMessage(string message) => StartCoroutine(ShowMessageRoutine(message));

    private IEnumerator ShowMessageRoutine(string message)
    {
        var player = FindObjectOfType<PlayerController>();
        GlobalVariables.canMove = false;
        MessageText.text = $"{message}";
        MessagePanel.SetActive(true);
        player.PlayerStop();
        yield return new WaitForSeconds(2f);
        MessagePanel.SetActive(false);
        GlobalVariables.canMove = true;
    }

    #endregion Show UI Message

    #region Pause

    private bool paused = false;
    public GameObject Left;
    public GameObject Jump;
    public GameObject Attack;
    public GameObject PausePanel;

    public void PauseGame()
    {
        if (!paused && GlobalVariables.canPause)
        {
            GlobalVariables.canMove = false;
            PausePanel.SetActive(true);
            Left.SetActive(GlobalVariables.canWalkLeft);
            Jump.SetActive(GlobalVariables.canJump);
            Attack.SetActive(GlobalVariables.canAttack);
            paused = true;
        }
        else
        {
            PausePanel.SetActive(false);
            GlobalVariables.canMove = true;
            paused = false;
        }
    }

    #endregion Pause
}