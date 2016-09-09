using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    public int MaxEnergy = 20;
    public int StartingEnergy = 10;
    public int EnergyRegen = 1;

    public int CurrentEnergy;

	// Use this for initialization
	void Start () {
        CurrentEnergy = StartingEnergy;
        InvokeRepeating("Regen", 1f, 1f);
	}
	
	// Update is called once per frame

    void Regen()
    {
        Debug.Log("Regen");
        ModifyEnergy(EnergyRegen);
    }

    void ModifyEnergy(int energy)
    {
        CurrentEnergy += energy;
        if (CurrentEnergy > MaxEnergy)
            CurrentEnergy = MaxEnergy;
        if (CurrentEnergy < 0)
            CurrentEnergy = 0;
    }
}
