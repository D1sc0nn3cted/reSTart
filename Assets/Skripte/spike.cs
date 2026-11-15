using Unity.VisualScripting;
using UnityEngine;

public class spike : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            animator.Play("spike rise");
            
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
