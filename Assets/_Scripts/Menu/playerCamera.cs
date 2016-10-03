using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCamera : MonoBehaviour
{
    public Toggle[] PlayerToggles;
    public GameObject[] PlayerCameras;

	// Use this for initialization
	void Start ()
	{
        foreach(GameObject playerCamera in PlayerCameras)
        {
            playerCamera.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
       // Debug.Log(playerToggle.isOn);
       PlayerCameras[0].SetActive(PlayerToggles[0].isOn);
        PlayerCameras[1].SetActive(PlayerToggles[1].isOn);
        PlayerCameras[2].SetActive(PlayerToggles[2].isOn);
        PlayerCameras[3].SetActive(PlayerToggles[3].isOn);

    }

}
