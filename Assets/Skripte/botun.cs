using UnityEditor.Build;
using UnityEngine;
public class botun : MonoBehaviour
{
    public Transform trans;
    public Transform playertrans;
    
    void Start()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("telep");
            playertrans.position = trans.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
