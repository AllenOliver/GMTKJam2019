using System.Collections;
using UnityEngine;

public class SkeletonClickDeathTest : MonoBehaviour
{
    public GameObject Particles;

    private void OnMouseDown() => StartCoroutine(KillSkeleton());

    private IEnumerator KillSkeleton()
    {
        Particles.SetActive(true);
        yield return new WaitForSeconds(.15f);
        FindObjectOfType<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Particles.SetActive(false);
    }
}