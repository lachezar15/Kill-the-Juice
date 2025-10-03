using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(int damage)
    { 
        health -= damage;
    }
}
