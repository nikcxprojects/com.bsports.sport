using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float offsetX = 0.8f;
    private const float speed = 1.5f;

    private Vector2 target;

    private void Awake()
    {
        target = new Vector2(0, transform.position.y);
    }

    private IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
            target = new Vector2(Random.Range(-offsetX, offsetX), transform.position.y);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
