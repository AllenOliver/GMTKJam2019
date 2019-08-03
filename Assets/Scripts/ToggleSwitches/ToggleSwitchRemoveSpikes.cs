using System.Collections;
using UnityEngine;

public class ToggleSwitchRemoveSpikes : ToggleSwitch
{
    public GameObject Spikes;

    public override IEnumerator ToggleRoutine()
    {
        yield return new WaitForSeconds(.75f);
        base.SwapSprite();
        Spikes.SetActive(false);
    }
}