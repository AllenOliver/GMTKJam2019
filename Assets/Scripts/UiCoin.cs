using UnityEngine;

public class UiCoin : MonoBehaviour
{
    public void Spin()
    {
        var anim = GetComponent<Animator>();
        anim.SetTrigger("Spin");
    }
}