using Assets.Scripts.Globals;
using System.Collections;
using UnityEngine;
using Animator = UnityEngine.Animator;

public class EnemyDie : MonoBehaviour
{
    private Animator anim;
    private bool hasDied;
    public GameObject Particles;

    [Range(0, 10)] public float ParticleSystemLifetime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        if (!hasDied)
        {
            hasDied = true;
            StartCoroutine(DieRoutine());
        }
    }

    private IEnumerator DieRoutine()
    {
        using (new DisposableObject(Particles))
        {
            anim.SetTrigger("Die");
            GetComponent<BoxCollider2D>().Off();
            yield return new WaitForSeconds(ParticleSystemLifetime);
        }
    }
}