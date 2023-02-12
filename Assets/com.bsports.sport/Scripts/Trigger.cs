using UnityEngine;

public class Trigger : MonoBehaviour
{
    private AudioSource Source { get; set; }

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Source.Play();
        GameManager.Instance.UpdateScore(Random.Range(1, 10));
    }
}
