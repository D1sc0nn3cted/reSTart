using UnityEngine;

public class song : MonoBehaviour
{
    private static song instance;
    private AudioSource audioSource;

    void Awake()
    {
        // If a music player already exists, destroy this new duplicate
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, set this as the active instance and keep it across scenes
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Enable looping through code
        audioSource.loop = true;

        // Play the track
        audioSource.Play();
    }
}