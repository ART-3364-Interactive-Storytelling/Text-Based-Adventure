using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    [Header("UI References")]
    public Image backgroundImage;
    public TextMeshProUGUI storyText;
    public Button choiceButton1;
    public Button choiceButton2;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;

    [Header("Scene Data")]
    public Sprite backgroundSprite;
    [TextArea(3,10)]
    public string story;
    public string choice1Text;
    public string choice1Scene;
    public string choice2Text;
    public string choice2Scene;

    public void QuitApplication()
    {   Debug.Log("Application Quit!"); 
        Application.Quit();
    }

    void Start()
    {
        // Set background and story
        if (backgroundImage && backgroundSprite)
            backgroundImage.sprite = backgroundSprite;
        if (storyText)
            storyText.text = story;

        // Setup Choice 1
        if (!string.IsNullOrEmpty(choice1Text) )
        {
            button1Text.text = choice1Text;
            choiceButton1.onClick.AddListener(() => SceneManager.LoadScene(choice1Scene));
            choiceButton1.gameObject.SetActive(true);
        }
        else
        {
            choiceButton1.gameObject.SetActive(false);
        }

        // Quit the game for choice two
        if (!string.IsNullOrEmpty(choice2Text))
        {
            button2Text.text = choice2Text;
            choiceButton2.onClick.AddListener(() => QuitApplication());
            choiceButton2.gameObject.SetActive(true);
        }
        else
        {
            choiceButton2.gameObject.SetActive(false);
        }
    }
}