using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public int SpawnYPoint;

    public void Spawn(GameObject obj)
    {
        Instantiate(obj, new Vector3(transform.position.x, transform.position.y + SpawnYPoint, 0f),
            Quaternion.identity);
    }
}