using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{
    [Header("Scene Settings")]
    public int sceneIndex; // Type your Build Index here in the Inspector

    // Loads the scene automatically when the player walks into this trigger object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    // You can also call this method publicly from UI buttons or other scripts
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}