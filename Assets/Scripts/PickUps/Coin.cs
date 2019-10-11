using Assets.Scripts.Globals;
using System.Collections;
using UnityEngine;
using SpriteRenderer = UnityEngine.SpriteRenderer;

public class Coin : MonoBehaviour
{
    public void PickUp() => StartCoroutine(PickUpRoutine());

    private IEnumerator PickUpRoutine()
    {
        using (new DisposableObject(this.gameObject))
        {
            GetComponent<BoxCollider2D>().Off();
            GlobalVariables.CoinCount++;
            GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<UiCoin>().Spin();
            ///Play Paricles?
            yield return new WaitForSeconds(.75f);
        }
    }
}