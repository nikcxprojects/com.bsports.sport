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

    private int themeId;
    [Space(10)]
    [SerializeField] Image themeImg;
    [SerializeField] Image background;
    [SerializeField] Theme[] themes;

    private void Awake()
    {
        SetTheme(0);
        OpenMenu();
    }

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

    public void SetTheme(int dir)
    {
        themeId += dir;
        if(themeId > themes.Length - 1)
        {
            themeId = 0;
        }
        else if(themeId < 0)
        {
            themeId = themes.Length - 1;
        }

        background.color = themes[themeId].color;
        themeImg.sprite = themes[themeId].sprite;
    }
}
