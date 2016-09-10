using System;
using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour
{
    public int requriedEnergy = -1;
    protected Energy energy;

	// Use this for initialization
	void Start () {
        energy = GetComponent<Energy>();
	}
	
    protected Boolean useEnergy(int _requiredEnergy)
    {
        int currentEnergy = energy.getCurrentEnergy();
        if (currentEnergy >= -_requiredEnergy)
        {
            energy.modifyEnergy(_requiredEnergy);
            return true;
        }
        return false;
    }
}
