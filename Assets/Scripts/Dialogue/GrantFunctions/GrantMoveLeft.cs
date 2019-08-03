using System.Collections;
using UnityEngine;

public class GrantMoveLeft : GrantPowerScript
{
    public GameObject Floor;
    public GameObject Explode;

    public override void GrantPower() => StartCoroutine(OpenFloor());

    private IEnumerator OpenFloor()
    {
        yield return new WaitForSeconds(2f);
        Floor.SetActive(false);
        Explode.SetActive(true);
        GlobalVariables.canWalkLeft = true;
    }
}