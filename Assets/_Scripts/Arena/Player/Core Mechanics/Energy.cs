using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {

    public int maxEnergy = 20;
    public int StartingEnergy = 10;
    public int EnergyRegen = 1;
    public Slider slider;

    private int currentEnergy;

	// Use this for initialization
	void Start () {
        currentEnergy = StartingEnergy;
        InvokeRepeating("Regen", 1f, 1f);

        if (slider)
            slider.value = (float)currentEnergy / maxEnergy;
    }
	
	// Update is called once per frame

    void Regen()
    {
        //Debug.Log("Regen");
        modifyEnergy(EnergyRegen);
    }

    public void modifyEnergy(int energy)
    {
        currentEnergy += energy;
        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;
        if (currentEnergy < 0)
            currentEnergy = 0;
        if (slider)
            slider.value = (float)currentEnergy / maxEnergy;
    }

    public int getCurrentEnergy()
    {
        return currentEnergy;
    }
}
