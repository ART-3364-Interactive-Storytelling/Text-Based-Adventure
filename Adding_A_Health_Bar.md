# Adding a Health Bar

## Add the Health Bar UI
1. Open your **first scene** after your main menu, in the Hierarchy, right-click and select: ```UI > Slider``` (rename it to HealthBar).
2. Select the HealthBar object:
3. In the Inspector, uncheck Interactable (since players won’t drag it).
4. Optionally, remove the Handle child (for a simple bar look).
5. Adjust the ``Fill Area -> Fill -> Image -> Color``` and ```Background -> Image -> Color``` colors as desired.
6. Resize and position the HealthBar where you want it on the screen.

## Add a Script to Control the Health
1. Right click in the project pane and select ```Create -> MonoBehaviour Script```
2. Double click the script to open it in your editor and add the folowing code:
```csharp
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;

    // Call this to set health (0 to 1 for percent, or set max value for absolute)
    public void SetHealth(float value)
    {
        healthSlider.value = value;
    }

    public void SetMaxHealth(float max)
    {
        healthSlider.maxValue = max;
    }
}
```
3. Save the Script.
   
## Connnecting the Script and Assigning References
1. Attach HealthBarController to your HealthBar GameObject by dragging the script from the **Project** pane onto the HealthBar GameObject in the **Hierarchy**
2. Click on the HealthBar GameObject in the hierarchy.
3. Drag the HealthBar Slider GameObject from the **Hierarchy** onto the healthSlider field in the **Inspector**

## Generating a Singleton GameManager
To track health and make it persist across scene loads in Unity, we need to use a singleton GameManager with DontDestroyOnLoad. This GameManager will stay around even when we load and unload scenes so it will provide a place for all the data we don't want to lose, like current player health.

1. Right-click in the **Hierachy** and select ```Create -> Empty```
2. Name it ```GameManager``
3. Right click in the **Project** pane and ```Create -> MonoBehaviour Script`` and name it ```GameManager.cs```
4. Add the following code to the Game Manager script.
```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
        }
        else
        {
            Destroy(gameObject); // Only one instance allowed
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var healthBar = FindFirstObjectByType<HealthBarController>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        var healthBar = FindFirstObjectByType<HealthBarController>();
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}
```

5. Drag the GameManaget script from the **Project** pane onto the GameManager GameObject in the **Hierarchy**


   
