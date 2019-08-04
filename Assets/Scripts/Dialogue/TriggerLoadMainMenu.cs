using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerLoadMainMenu : TriggerInteractable
{
    public GameObject FadePanel;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                StartCoroutine(LoadMainMenu());
                break;
        }
    }

    private IEnumerator LoadMainMenu()
    {
        HasBeenTriggered = true;
        GlobalVariables.canMove = false;
        yield return new WaitForSeconds(3f);
        FadeScreen();
        yield return new WaitUntil(() => FadePanel.GetComponent<Image>().color.a == 1f);
        SceneManager.LoadScene(0);
    }

    public void FadeScreen() => FadePanel.GetComponent<Animator>().SetTrigger("Fade");
}