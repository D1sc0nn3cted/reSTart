using UnityEngine;
using UnityEngine.UI; 

public class HealthManager : MonoBehaviour
{
    public Sprite fullHeartSprite; 
    public Sprite emptyHeartSprite;
    private float currentHealth;
    public GameObject player;
    public int DesHealth;
    private Image heartimage;
    


    void Start()
    {
        
        heartimage = GetComponent<Image>();
    }
    private void Update()
    {
        currentHealth = player.GetComponent<health>().currentHealth;
        if (currentHealth < DesHealth)
            heartimage.sprite = emptyHeartSprite;
        else if (currentHealth >= DesHealth)
            heartimage.sprite = fullHeartSprite;



    }
    

}