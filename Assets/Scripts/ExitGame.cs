using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // This method can be called to exit the game
    public void QuitGame()
    {
        // If we are in the editor, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If we are not in the editor, quit the application
        Application.Quit();
#endif
    }
}
