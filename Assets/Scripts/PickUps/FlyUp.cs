using UnityEngine;

public class FlyUp : MonoBehaviour
{
    [Range(1, 10)]
    public float Power;

    public void Impulse()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * Power, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(-.1f, .1f), ForceMode2D.Impulse);
    }
}