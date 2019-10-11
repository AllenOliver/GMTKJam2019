using UnityEngine;
using UnityEngine.Events;

public class CollideWithTag : MonoBehaviour
{
    public UnityEvent OnHit = new UnityEvent();
    public string TagToSearchFor = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagToSearchFor))
            OnHit?.Invoke();
    }
}