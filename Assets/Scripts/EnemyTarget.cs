
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 50f;
    public void takeDamage(float amount) {

        health -= amount;
        if (health <= 0) {
            DIE();
        }
    
    }

    void DIE() {
        
        Destroy(gameObject);
    }
}
