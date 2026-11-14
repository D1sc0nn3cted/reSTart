using UnityEngine;
using UnityEngine.SceneManagement;
public class health : MonoBehaviour
{
    public int maxHealth=3;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }









}

