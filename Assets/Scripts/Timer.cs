using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public string sceneToSwitchTo; // Name of the scene to switch to
    public float switchTime = 5f;   // Time in seconds before switching

    private float timer; // Timer to track time elapsed

    void Start()
    {
        timer = switchTime; // Initialize the timer
    }

    void Update()
    {
        // Count down the timer
        timer -= Time.deltaTime;

        // Check if the timer has reached zero
        if (timer <= 0)
        {
            SwitchScene(); // Call the function to switch scenes
        }
    }

    void SwitchScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}