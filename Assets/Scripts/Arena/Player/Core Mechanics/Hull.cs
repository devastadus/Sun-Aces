using UnityEngine;
using System.Collections;

public class Hull : MonoBehaviour {

    public int health = 10;
    public GameObject Death;

    public void modifyHealth(int _health)
    {
        health =+ _health;

        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(Death, transform.position, Quaternion.identity);
        }
    }
}
