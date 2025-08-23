## Scene Layout (for each scene)
Each scene should have:

* A Canvas (set to Screen Space - Overlay)
* An Image for the background PNG
* A Panel/Text area for the story text
* Buttons for choices. This tutorial assumes 2

## Suggested Hierarchy Example
Canvas  
├── Background (Image)  
├── StoryPanel (Panel)  
│   └── StoryText (TextMeshProUGUI or Text)  
├── ChoiceButton1 (Button)  
│   └── ButtonText1 (TextMeshProUGUI or Text)  
└── ChoiceButton2 (Button)  
    └── ButtonText2 (TextMeshProUGUI or Text)  

## Navigation Logic
* Each button should load the next scene using `SceneManager.LoadScene("SceneName")`.
* For terminal scenes (Credits, Exit), you can disable or hide the buttons.

## Setting up a Prefab

### 1. Create the UI

1. **Open any scene** in your project.
2. **Right-click in the Hierarchy** and select:  
   `UI > Canvas` (if you don’t already have one).
3. With the Canvas selected, add:
   - `UI > Image` (rename to `Background`)
   - `UI > Panel` (rename to `StoryPanel`)
   - `UI > Button` (rename to `ChoiceButton1`)
   - `UI > Button` (rename to `ChoiceButton2`)
4. Inside `StoryPanel`, add:
   - `UI > Text - TextMeshPro` (rename to `StoryText`)
5. Inside each button, add:
   - `UI > Text - TextMeshPro` (rename to `ButtonText1` and `ButtonText2`)

### 2. Arrange and Anchor the UI

- **Background:**  
  Select the Background image, then in the Rect Transform component,  
  click the Anchor Presets (the square icon).  
  **Hold `Alt` (Windows) or `Option` (Mac)** and click the "stretch both" preset (bottom right) to fill the Canvas.

- **StoryPanel:**  
  Move and resize the StoryPanel to the bottom of the screen.  
  For responsive layout, set its anchor to bottom stretch.

- **Buttons:**  
  Place the buttons below or beside the StoryPanel as desired.

### 3. Make the Prefab

1. **Select the Canvas** in the Hierarchy.
2. **Drag the Canvas** into your Project window (e.g., into `Assets/Prefabs/`).
3. This creates a prefab you can reuse in every scene.

### 4. Using the Prefab

- In each new scene, drag the prefab from your Project window into the Hierarchy.
- Set the background image, story text, and button choices in the Inspector for each scene.

---

## Example Script for Scene Navigation
Create a script (e.g., `SceneController.cs`) and attach it to the Canvas or a child GameObject:

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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

    void Start()
    {
        // Set background and story
        if (backgroundImage && backgroundSprite)
            backgroundImage.sprite = backgroundSprite;
        if (storyText)
            storyText.text = story;

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
    }
}
```
* Assign the scene fields in the Inspector to the appropriate scene names.
* Set the button’s OnClick event to call the appropriate method.

---

## Scene Creation
1. Create 13 scenes in your Scenes folder with the names listed above.
2. Set up the UI as described for each.
3. Assign the correct background PNG and story text per scene.
4. Configure the buttons to point to the correct next scene(s) as per your map.

### Example: MainMenu Scene
* Background: main_menu.png
* StoryText: "Welcome! Choose an option:"
* Button 1: "Start Adventure" → OutsideHole
* Button 2: "Credits" → Credits

---

**Tip:**  
You can update the prefab later—changes will propagate to all scenes