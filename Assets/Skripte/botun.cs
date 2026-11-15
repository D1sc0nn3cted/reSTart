using UnityEditor.Build;
using UnityEngine;
public class botun : MonoBehaviour
{
    public Transform trans;
    public Transform playertrans;
    public GameObject dooropen;
    private Animator openanim;
    public GameObject doorclose;
    private Animator closeanim;
    private BoxCollider2D opencolider;
    private BoxCollider2D closecolider;
    private Animator butonan;
    private bool activated = false;

    void Start()
    {
        openanim = dooropen.GetComponent<Animator>();
        closeanim = doorclose.GetComponent<Animator>();
        opencolider = dooropen.GetComponent<BoxCollider2D>();
        closecolider = doorclose.GetComponent<BoxCollider2D>();
        butonan = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            Debug.Log("telep");
            playertrans.position = trans.position;
            butonan.Play("Press");
            openanim.Play("Open");
            opencolider.enabled = false;
            closeanim.Play("Close");
            closecolider.enabled = true;
            activated = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
