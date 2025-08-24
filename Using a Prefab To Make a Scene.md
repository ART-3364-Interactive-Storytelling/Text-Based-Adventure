# Using the UI Prefab to Make a Scene

This guide explains how to use your UI prefab to quickly set up a new scene for your text-based adventure in Unity.

---

## 1. Create a New Scene

1. In Unity, go to **File > New Scene**. Choose Basic-2D (Built-In) 
2. Save the scene in your `Assets/Scenes/` folder with an appropriate name (e.g., `OutsideHole.unity`).

---

## 2. Add the UI Prefab

1. In the **Project** window, locate your prefab (e.g., `Assets/Prefabs/Canvas.prefab`).
2. **Drag the prefab** into the Hierarchy window of your new scene.

---

## 3. Add the UI EventSystem

 1. Click in the **hierachy** and add ```UI -> EventSystem```

## 4. Assign Scene-Specific Content

1. **Select the Canvas** (or the GameObject with your `SceneController` script).
2. In the **Inspector**, you’ll see fields for:
    - Background Image
    - Story Text
    - Choice Button 1 Text and Target Scene
    - Choice Button 2 Text and Target Scene
3. **Assign the background image** (drag your PNG Sprite to the `backgroundSprite` field).
4. **Enter your story text** in the `story` field.
5. **Set up the choices:**
    - For each button, enter the button text and the name of the scene it should load.
    - If a choice is not needed, leave its text and scene fields empty to hide the button.

> [!IMPORTANT]
> Your buttons won't show if they don't have button text and a button scene. You can use a temporaty placeholder name for a scene if you haven't created it yet.

---

## 4. Test the Scene

1. Press **Play** in the Unity Editor.
2. Click the choice buttons to ensure they load the correct scenes.

---

## 5. Repeat for Each Scene

- Repeat these steps for all 13 scenes in your adventure.
- Each scene can have its own background, story, and choices, but all use the same prefab for consistency.

---

## Example Setup for "Crossroads" Scene

- **Background Sprite:** `crossroads.png`
- **Story:** "You arrive at a crossroads. Where do you go?"
- **Choice 1 Text:** "Happy Field"
- **Choice 1 Scene:** `HappyField`
- **Choice 2 Text:** "Ominous Forest"
- **Choice 2 Scene:** `OminousForest`

---

> [!TIP]
>  If you update and item in the prefab, all scenes using it will have the same update applied. If you update the item in a scene it will onkly apply to that scene.
