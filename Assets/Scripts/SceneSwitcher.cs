using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Public variable to set the scene name in the Inspector
    public string sceneName;

    // Function to switch to the scene specified in the inspector
    public void SwitchScene()
    {
        // Check if the scene is available in the Build Settings
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " is not in the build settings.");
        }
    }
}
