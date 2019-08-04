using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private AudioSource sound;

    public GameObject FadePanel;

    // Start is called before the first frame update
    private void Start() => sound = GetComponent<AudioSource>();

    public void StartGame() => StartCoroutine(LoadLevel());

    public void ToggleSound()
    {
        if (GlobalVariables.audioOn)
        {
            GlobalVariables.audioOn = false;
            var sounds = FindObjectsOfType<AudioSource>().ToList();
            sounds.ForEach(x => x.enabled = false);
        }
        else
        {
            GlobalVariables.audioOn = true;
            var sounds = FindObjectsOfType<AudioSource>().ToList();
            sounds.ForEach(x => x.enabled = true);
        }
    }

    private IEnumerator LoadLevel()
    {
        FadeScreen();
        yield return new WaitUntil(() => FadePanel.GetComponent<Image>().color.a == 1f);
        SceneManager.LoadScene(1);
    }

    public void FadeScreen() => FadePanel.GetComponent<Animator>().SetTrigger("Fade");

    private void PlaySound() => sound.Play();
}