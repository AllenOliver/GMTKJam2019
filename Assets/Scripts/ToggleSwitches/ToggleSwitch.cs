using System.Collections;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public Sprite[] sprites;

    private bool activated = false;
    private SpriteRenderer Sprite;
    protected AudioSource sounds;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        sounds = GetComponent<AudioSource>();
        SetSprite();
    }

    public void Toggle() => StartCoroutine(ToggleRoutine());

    public virtual IEnumerator ToggleRoutine()
    {
        if (!activated)
            Toggle();
        SwapSprite();
        PlaySound();
        activated = true;
        yield return null;
    }

    protected void PlaySound() => sounds.Play();

    protected void SetSprite() => Sprite.sprite = sprites[0];

    protected void SwapSprite() => Sprite.sprite = sprites[1];
}