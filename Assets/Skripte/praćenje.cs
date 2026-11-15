using UnityEngine;

public class praćenje : MonoBehaviour
{
    private GameObject player;
    public float movespeed = 10f;
    private Vector2 targetposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        targetposition = player.GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, movespeed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Invoke("destroy",0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("69");
        if (obj.gameObject.layer == LayerMask.NameToLayer("shield"))
        {
            Debug.Log("67");
            Invoke("destroy", 0.01f);
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }

}
