using UnityEngine;
using UnityEngine.UI;

public class PullBtn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            FindObjectOfType<Ball>().Pull();
        });
    }
}
