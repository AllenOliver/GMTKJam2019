using UnityEngine;
using UnityEngine.Events;

public class TriggerExit : MonoBehaviour
{
    public UnityEvent OnExit = new UnityEvent();
    public string TagToSearchFor = "Player";

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagToSearchFor))
            OnExit?.Invoke();
    }
}