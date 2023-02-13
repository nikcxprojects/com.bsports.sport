using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour
{
    private static float smoothTime = 0.2f;
    private Vector2 TargetPosition;

    private bool IsEnable { get; set; }
    private bool IsDestinated { get; set; }

    IEnumerator Delay()
    {
        int id = transform.GetSiblingIndex();
        yield return new WaitForSeconds(id * smoothTime);
        IsEnable = true;
    }

    private void Awake()
    {
        TargetPosition = transform.position;
    }

    private void OnEnable()
    {
        IsEnable = false;
        IsDestinated = false;

        transform.position += Vector3.down * 2000;

        StartCoroutine(nameof(Delay));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Delay));
    }

    private void Update()
    {
        if(!IsEnable || IsDestinated)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, 3100 * Time.deltaTime);
        if((Vector2)transform.position == TargetPosition)
        {
            IsDestinated = true;
        }
    }
}
