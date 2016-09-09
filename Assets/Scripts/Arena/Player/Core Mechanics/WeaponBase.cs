using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {

    Energy energy;

	// Use this for initialization
	void Start () {
        energy = GetComponent<Energy>();
	}
	
    public void UseEnergy(int requiredEnergy)
    {
        int currentEnergy = energy.CurrentEnergy;
        //if()

    }
}
