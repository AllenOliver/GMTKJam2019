using UnityEngine;
using UnityEngine.Events;

public class CollideWithTag : MonoBehaviour
{
    public UnityEvent OnHit = new UnityEvent();
    public string TagToSearchFor = "Player";

    [Header("On uses OnCollision; Off uses OnTrigger")]
    public bool CollideorTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CollideorTrigger)
        {
            if (collision.gameObject.CompareTag(TagToSearchFor))
                OnHit?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollideorTrigger)
        {
            if (collision.gameObject.CompareTag(TagToSearchFor))
                OnHit?.Invoke();
        }
    }
}