using UnityEngine;
using UnityEngine.Events;

public class PickUpSpawn : MonoBehaviour
{
    public UnityEvent OnSpawn = new UnityEvent();

    private void Start()
    {
        OnSpawn?.Invoke(); //call starting logic
    }
}