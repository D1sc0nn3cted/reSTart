using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the current scene index and add 1 to load the next scene
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Make sure the next scene exists in your Build Settings before loading
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("You are on the last scene! No next scene to load.");
            }
        }
    }
}