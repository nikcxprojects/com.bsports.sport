using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour
{
    private static float smoothTime = 0.1f;

    private Vector2 Velocity = Vector2.zero;
    private Vector2 TargetPosition;

    private bool IsEnable { get; set; }

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

        transform.position += Vector3.down * 3000.0f;
        Velocity = Vector2.zero;

        StartCoroutine(nameof(Delay));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Delay));
    }

    private void Update()
    {
        if(!IsEnable)
        {
            return;
        }

        transform.position = Vector2.SmoothDamp(transform.position, TargetPosition, ref Velocity, smoothTime);
    }
}
