using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject settings;

    [Space(10)]
    [SerializeField] Text titleText;
    [SerializeField] ScrollRect scrollRect;

    private void Awake() => OpenMenu();

    public void OpenSection(RectTransform sectionRect)
    {
        scrollRect.content = sectionRect;

        menu.SetActive(false);
        game.SetActive(true);

        switch (sectionRect.GetSiblingIndex())
        {
            case 0: titleText.text = "Upcoming Events"; break;
            case 1: titleText.text = "Top Clubs"; break;
            case 2: titleText.text = "Top Scores"; break;
        }

        sectionRect.gameObject.SetActive(true);
        scrollRect.verticalNormalizedPosition = 1;

        Invoke(nameof(EnableRect), 1f);
    }

    public void OpenMenu()
    {
        scrollRect.enabled = false;

        settings.SetActive(false);
        game.SetActive(false);

        menu.SetActive(true);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    private void EnableRect()
    {
        scrollRect.enabled = true;
    }
}
