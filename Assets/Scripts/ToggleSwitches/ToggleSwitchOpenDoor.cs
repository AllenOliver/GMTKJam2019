using System.Collections;
using UnityEngine;

public class ToggleSwitchOpenDoor : ToggleSwitch
{
    public GameObject Floor;

    public GameObject Explosion;

    public override IEnumerator ToggleRoutine()
    {
        yield return new WaitForSeconds(.75f);
        base.SwapSprite();
        yield return new WaitForSeconds(1f);
        Floor.SetActive(false);
        Explosion.SetActive(true);
    }
}