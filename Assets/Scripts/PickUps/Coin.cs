using Assets.Scripts.Globals;
using System.Collections;
using TMPro;
using UnityEngine;
using SpriteRenderer = UnityEngine.SpriteRenderer;

public class Coin : MonoBehaviour
{
    private bool canPickUp = true;

    public void PickUp() => StartCoroutine(PickUpRoutine());

    private IEnumerator PickUpRoutine()
    {
        if (canPickUp)
        {
            using (new DisposableObject(this.gameObject))
            {
                canPickUp = false;
                GetComponent<BoxCollider2D>().Off();
                GlobalVariables.CoinCount++;
                GetComponent<SpriteRenderer>().enabled = false;
                FindObjectOfType<UiCoin>().Spin();
                UpdateCoinUI();
                ///Play Paricles?
                yield return new WaitForSeconds(.15f);
            }
        }
    }

    public void UpdateCoinUI() => GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>().text = $"x {GlobalVariables.CoinCount}";
}