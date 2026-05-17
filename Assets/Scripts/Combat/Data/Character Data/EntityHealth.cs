using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamagable
{

    //public int health { get; private set; } = 100;
    public int health = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void IDamage(int _damage)
    {
        health -= _damage;

        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            health = 0;
            return true;
        }

        return false;
    }
}
