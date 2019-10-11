using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject AttackObject;

    [Range(0f, 2f)]
    public float AttackAnimLength;

    public void DoAttack() => StartCoroutine(AttackRoutine());

    private IEnumerator AttackRoutine()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        using (new DisposableObject(AttackObject))
        {
            yield return new WaitForSeconds(AttackAnimLength);
        }
    }
}