using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;

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
    }

    public void OpenMenu()
    {
        game.SetActive(false);
        menu.SetActive(true);
    }
}
