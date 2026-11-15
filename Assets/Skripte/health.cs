using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class health : MonoBehaviour
{
    public int maxHealth=3;
    public int currentHealth;
    public Transform start;
    public Transform playertrans;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    private AudioSource audioSource;


    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckForDamage(collision.gameObject);
    }
    void CheckForDamage(GameObject obj)
    {
        if (obj.layer == LayerMask.NameToLayer("Damage"))
        {
            TakeDamage(1);
            if(currentHealth >= 1)
                audioSource.PlayOneShot(hurtClip);
        }
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Debug.Log("šteta");
        Invoke("tp", 0.01f);
        if (currentHealth <= 0)
        {
            Die();
        }


    }

    void Die()
    {
        Debug.Log("smrt");
        
        audioSource.PlayOneShot(deathClip);
    }
    void tp()
    {
        playertrans.position = start.position;
    }








}

