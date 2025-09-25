using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [Header("UI References")]
    public Image backgroundImage;
    public TextMeshProUGUI storyText;
    public Button choiceButton1;
    public Button choiceButton2;
    public Button choiceButton3;
    public Button exitButton;
    //public Button nextButton; //(Extended) This is used when you don't have any choices to show, typically a unified graphic so I'm not going to ask for text too
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI button3Text;
    public TextMeshProUGUI exitButtonText;

    [Header("Scene Data")]
    public Sprite backgroundSprite;
    public float textSpeed = 0.25f; //(Extended) Speed of the Text, in Characters per Frame (in Floats so you can go slower than 1/frame)
    public float textEndWaitTime = 0.5f; //(Extended) How long to wait before showing any buttons, in seconds
    [TextArea(3,10)]
    public string story;
    public string choice1Text;
    public string choice1Scene;
    public string choice2Text;
    public string choice2Scene;
    public string choice3Text;
    public string choice3Scene;
    public string exitText;
    public string exitScene;
    //public string nextScene; //(Extended) Use this when you don't have any choices to show

    /* Floofs' Update to include the TMPro 'Typewriter Effect' Example w/ some Extended code */
    private bool hasTextChanged;
    private bool buttonsEnabled = false;

    void Start()
    {
        // Set background and story
        if (backgroundImage && backgroundSprite) {
            backgroundImage.sprite = backgroundSprite;
        }

        resetButtons();
        if (storyText) {
            storyText.text = story;
            StartCoroutine(RevealCharacters(storyText));
        }
        else EnableButtons();
    }

    void resetButtons() {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton3.gameObject.SetActive(false);
       // nextButton.gameObject.SetActive(false);

        // Setup the Top-Left Button (Usually "Restart" or "Exit")
        if (!string.IsNullOrEmpty(exitText) && !string.IsNullOrEmpty(exitScene))
        {
            exitButtonText.text = exitText;
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(exitScene));
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            exitButton.gameObject.SetActive(false);
        }
    }
    
    void EnableButtons() {
        buttonsEnabled = true;

         // Setup Choice 1
        if (!string.IsNullOrEmpty(choice1Text) && !string.IsNullOrEmpty(choice1Scene))
        {
            button1Text.text = choice1Text;
            choiceButton1.onClick.AddListener(() => SceneManager.LoadScene(choice1Scene));
            choiceButton1.gameObject.SetActive(true);
        }
        else
        {
            choiceButton1.gameObject.SetActive(false);
        }

        // Setup Choice 2
        if (!string.IsNullOrEmpty(choice2Text) && !string.IsNullOrEmpty(choice2Scene))
        {
            button2Text.text = choice2Text;
            choiceButton2.onClick.AddListener(() => SceneManager.LoadScene(choice2Scene));
            choiceButton2.gameObject.SetActive(true);
        }
        else
        {
            choiceButton2.gameObject.SetActive(false);
        }
        // Setup Choice 3
        if (!string.IsNullOrEmpty(choice3Text) && !string.IsNullOrEmpty(choice3Scene))
        {
            button3Text.text = choice3Text;
            choiceButton3.onClick.AddListener(() => SceneManager.LoadScene(choice3Scene));
            choiceButton3.gameObject.SetActive(true);
        }
        else
        {
            choiceButton3.gameObject.SetActive(false);
        }
        // Setup the Top-Left Button (Usually "Restart" or "Exit")
        if (!string.IsNullOrEmpty(exitText) && !string.IsNullOrEmpty(exitScene))
        {
            exitButtonText.text = exitText;
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(exitScene));
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            exitButton.gameObject.SetActive(false);
        }
    }

    //TMPro Examples Code
    void ON_TEXT_CHANGED(Object obj)
    {
        hasTextChanged = true;
    }

    IEnumerator RevealCharacters(TMP_Text textComponent)
    {
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        float visibleCount = 0;

        while (true)
        {
            if (hasTextChanged)
            {
                totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
                hasTextChanged = false; 
            }

            if (visibleCount > totalVisibleCharacters)
            {
                yield return new WaitForSeconds(textEndWaitTime);
                if (!buttonsEnabled) { //Just a Copy-Paste of the ButtonsEnabled function, could be cleaned up
                    buttonsEnabled = true;
                    int buttonsShown = 0;
                     // Setup Choice 1
                    if (!string.IsNullOrEmpty(choice1Text) && !string.IsNullOrEmpty(choice1Scene))
                    {
                        button1Text.text = choice1Text;
                        choiceButton1.onClick.AddListener(() => SceneManager.LoadScene(choice1Scene));
                        choiceButton1.gameObject.SetActive(true);
                        buttonsShown++;
                    }
                    else
                    {
                        choiceButton1.gameObject.SetActive(false);
                    }

                    // Setup Choice 2
                    if (!string.IsNullOrEmpty(choice2Text) && !string.IsNullOrEmpty(choice2Scene))
                    {
                        button2Text.text = choice2Text;
                        choiceButton2.onClick.AddListener(() => SceneManager.LoadScene(choice2Scene));
                        choiceButton2.gameObject.SetActive(true);
                        buttonsShown++;
                    }
                    else
                    {
                        choiceButton2.gameObject.SetActive(false);
                    }
                    // Setup Choice 3
                    if (!string.IsNullOrEmpty(choice3Text) && !string.IsNullOrEmpty(choice3Scene))
                    {
                        button3Text.text = choice3Text;
                        choiceButton3.onClick.AddListener(() => SceneManager.LoadScene(choice3Scene));
                        choiceButton3.gameObject.SetActive(true);
                        buttonsShown++;
                    }
                    else
                    {
                        choiceButton3.gameObject.SetActive(false);
                    }

                    //No Choices? Use the normal Next button
                    /*
                    if (buttonsShown == 0) {
                        if (!string.IsNullOrEmpty(nextScene)) {
                            nextButton.onClick.AddListener(() => SceneManager.LoadScene(nextScene));
                            nextButton.gameObject.SetActive(true);
                        }
                        */
                        /*
                            Below is left in as a "backwards compatibility" thing for those who already wrote scenes with single 'answers'
                            and didn't want them. You'll still need to delete the text in the scenes with those single answers, but if you
                            forget to move the scene text, this'll double-check that for you. Feel free to delete this in future versions.
                        */
                        /*
                        else if (!string.IsNullOrEmpty(choice1Scene)) {
                            nextButton.onClick.AddListener(() => SceneManager.LoadScene(choice1Scene));
                            nextButton.gameObject.SetActive(true);
                        }
                    }
                    */
                }
                yield break;
            }

            // How many characters should TextMeshPro display?
            textComponent.maxVisibleCharacters = (int) Mathf.Floor(visibleCount); //The Flooring probably isn't necessary but I wanted to make sure since we have to cast to an int anyway
            
            visibleCount += textSpeed;

            yield return null;
        }
    }

}
