using System.Collections;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public Sprite[] sprites;

    private bool activated = false;

    private void Start() => SetSprite();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Attack":
                if (!activated)
                    Toggle();
                SwapSprite();
                activated = true;
                break;
        }
    }

    private void Toggle() => StartCoroutine(ToggleRoutine());

    public virtual IEnumerator ToggleRoutine()
    {
        yield return null;
    }

    protected void SetSprite() => GetComponent<SpriteRenderer>().sprite = sprites[0];

    protected void SwapSprite() => GetComponent<SpriteRenderer>().sprite = sprites[1];
}