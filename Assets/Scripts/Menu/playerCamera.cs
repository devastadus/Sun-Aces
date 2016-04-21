using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCamera : MonoBehaviour
{
    public Toggle playerToggle;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log(playerToggle.isOn);
        gameObject.SetActive(playerToggle.isOn);
	}
}
