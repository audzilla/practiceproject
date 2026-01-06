using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using TMPro; // Required if using TextMeshPro

public class MenuManager : MonoBehaviour
{
    // Function to load the main game scene
    public void StartGame()
    {
        // Load the scene by name or build index
        // Make sure your game scene is added to Build Settings (index 1)
        SceneManager.LoadScene(1);
    }

    // Function to quit the application
    public void QuitGame()
    {
        Application.Quit();
        // The following line is for testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
