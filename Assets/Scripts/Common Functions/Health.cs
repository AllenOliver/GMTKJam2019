using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    private int CurrentHealth;
    private bool hasDied;
    public UnityEvent OnDie = new UnityEvent();

    private void Start()
    {
        #region Define Player Logic

        if (GetComponent<PlayerController>())
        {
            if (GlobalVariables.PlayerCurrentHealth > 0)
            {
                CurrentHealth = GlobalVariables.PlayerCurrentHealth;
            }
            if (GlobalVariables.PlayerMaxHealth > 0)
            {
                MaxHealth = GlobalVariables.PlayerMaxHealth;
            }
        }

        #endregion Define Player Logic

        #region Define Enemy Logic

        else if (GetComponent<Enemy>())
        {
            MaxHealth = GetComponent<Enemy>().data.MaxHealth;
            CurrentHealth = MaxHealth;
        }

        #endregion Define Enemy Logic

        #region Fallout case for destructables ect.

        else
        {
            CurrentHealth = MaxHealth;
        }

        #endregion Fallout case for destructables ect.
    }

    public void SubtractHealth(int amountToRemove)
    {
        var result = CurrentHealth - amountToRemove;

        if (result <= 0)
        {
            CurrentHealth = 0;
            if (!hasDied)
            {
                hasDied = true;
                OnDie?.Invoke();
            }
        }
        else
            CurrentHealth = result;
    }

    public void AddHealth(int amountToAdd)
    {
        var result = CurrentHealth + amountToAdd;

        CurrentHealth = (result > MaxHealth) ? MaxHealth : result;
    }
}