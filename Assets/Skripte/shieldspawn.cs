using UnityEngine;

public class shieldspawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    void Start()
    {
        
        animator = GetComponent<Animator>();
        animator.Play("Shield animation");
    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
