using UnityEngine;

public class enemy : MonoBehaviour
{
    private bool isalive = true;
    public GameObject bulletspawner;
    private Animator animator;
    public float interval = 2f;
    private float timer;
    public GameObject metakPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Playermovement>().isDashing);
        animator.Play("Die");
        isalive = false;
    }
    // Update is called once per frame
    
    

    void Update()
    {
        if (isalive)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                PerformAction();
                timer = 0f;
            }
        }
        
    }

    void PerformAction()
    {
        Instantiate(metakPrefab, bulletspawner.GetComponent<Transform>().position, Quaternion.identity);
        Debug.Log("spawn");
    }
}   
