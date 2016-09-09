using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {

    public int damage = -1;

    void OnCollisionEnter2D(Collision2D coll)
    {
        Hull hull = coll.gameObject.GetComponent<Hull>();
        if (hull == null)
        {
            Debug.Log("ERROR: No hull founds");
            return;
        }
        hull.modifyHealth(damage);
    }
}
