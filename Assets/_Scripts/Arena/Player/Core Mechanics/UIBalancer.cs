using UnityEngine;
using System.Collections;

public class UIBalancer : MonoBehaviour {

	public float yOffset = 0.5f;
	public bool m_UseRelativeRotation = true;  
	Vector3 pos;

	private Quaternion m_RelativeRotation;     

	private void Start()
	{
		m_RelativeRotation = transform.parent.localRotation;
	}

	private void Update()
	{
		if (m_UseRelativeRotation)
			transform.rotation = m_RelativeRotation;
		transform.position = transform.parent.parent.localPosition + new Vector3(0,yOffset,0);
	}
}
