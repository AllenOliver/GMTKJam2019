using System.Collections;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public Transform[] EndPoints;

    public bool ShouldWalk;

    public float speed;
    public float Distance;
    private float step;
    private bool leftRight; //Left is false
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        step = speed * Time.deltaTime;
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (ShouldWalk)
        {
            if (!leftRight)
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
        }
    }

    public IEnumerator Move()
    {
        while (ShouldWalk)
        {
            leftRight = false;
            sprite.flipX = true;
            yield return new WaitForSeconds(Distance);
            leftRight = true;
            sprite.flipX = false;
            yield return new WaitForSeconds(Distance);
        }
    }

    public void Stop() => ShouldWalk = false;

    public void StartWalk() => StartCoroutine(Move());

    private void moveLeft() => transform.Translate(Vector2.left * step);//transform.position = Vector2.MoveTowards(transform.position, new Vector2(1f, transform.position.y), step);

    private void moveRight() => transform.Translate(Vector2.right * step);//transform.position = Vector2.MoveTowards(transform.position, new Vector2(-1f, transform.position.y), step);
}