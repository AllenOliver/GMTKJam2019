using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private bool hasBeenDamaged;

    public void OnDamage()
    {
        if (!hasBeenDamaged)
        {
            hasBeenDamaged = true;
            var health = GetComponent<Health>();
            if (GetComponent<PlayerController>())
            {
                health.SubtractHealth(1);
                hasBeenDamaged = false;
            }
            else if (GetComponent<Enemy>())
            {
                health.SubtractHealth(GlobalVariables.PlayerAttackDamage);
                hasBeenDamaged = false;
            }
        }
    }
}