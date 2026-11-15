using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class spike : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            animator.Play("spike rise");
            audioSource.Play();
            Debug.Log("sound");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            animator.Play("spike fall");
            



        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
