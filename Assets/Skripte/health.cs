using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class health : MonoBehaviour
{
    public int maxHealth=3;
    public int currentHealth;
    public Transform start;
    public Transform playertrans;

    void Start()
    {
        currentHealth = maxHealth;
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
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("šteta");
        playertrans.position = start.position;


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("smrt");
    }









}

