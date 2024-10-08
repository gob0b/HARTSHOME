using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudioManager : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the Audio Source component
    public string stopSceneName; // Name of the scene where the audio should stop
    public AudioClip audioClip; // The audio clip to play

    private void Awake()
    {
        // Ensure this GameObject is not destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Check if the AudioSource component already exists, if not, add it
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource if not present
        }

        // Set the audio clip to the AudioSource and play it
        if (audioClip != null)
        {
            audioSource.clip = audioClip; // Assign the audio clip
            audioSource.loop = true; // Set to loop if desired
            audioSource.Play(); // Start playing the audio
        }
    }

    private void Update()
    {
        // Check if the current scene is the stop scene
        if (SceneManager.GetActiveScene().name == stopSceneName)
        {
            StopAudio(); // Stop the audio if we're in the specified scene
        }
        else if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the audio if it's not playing and we're not in the stop scene
        }
    }

    // Method to stop the audio
    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}