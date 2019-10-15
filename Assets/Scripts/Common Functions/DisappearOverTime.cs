using Assets.Scripts.Globals;
using System.Collections;
using UnityEngine;

public class DisappearOverTime : MonoBehaviour
{
    public float TimeTillDisappear;
    private bool startedFlash;
    public bool ShouldFlash;

    public void Trigger()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Flash()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator Fade()
    {
        var sprite = GetComponent<SpriteRenderer>();
        while (GetComponent<SpriteRenderer>().color.a > 0f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - .1f);
            yield return new WaitForSeconds(.15f);
        }
    }

    private IEnumerator Disappear()
    {
        if (ShouldFlash)
        {
            if (TimeTillDisappear < 3f)
            {
                StartCoroutine(Flash());
                yield return new WaitForSeconds(TimeTillDisappear);
                gameObject.Inactive();
            }
            else
            {
                var time = TimeTillDisappear - 2f;
                yield return new WaitForSeconds(time);
                StartCoroutine(Flash());
                yield return new WaitForSeconds(2f);
                gameObject.Inactive();
            }
        }
        else
        {
            yield return new WaitForSeconds(2.5f);

            StartCoroutine(Fade());
            yield return new WaitForSeconds(2.5f);
            gameObject.Inactive();
        }
    }
}