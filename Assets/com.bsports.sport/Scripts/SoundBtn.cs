using UnityEngine.UI;
using UnityEngine;

public class SoundBtn : MonoBehaviour
{
    private Text Text { get; set; }
    private Button Button { get; set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Text = Button.GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        Text.text = $"Sound: {(AudioListener.pause ? "off" : "on")}";
    }

    private void Start()
    {
        Button.onClick.AddListener(() =>
        {
            AudioListener.pause = !AudioListener.pause;
            Text.text = $"Sound: {(AudioListener.pause ? "off" : "on")}";
        });
    }
}
