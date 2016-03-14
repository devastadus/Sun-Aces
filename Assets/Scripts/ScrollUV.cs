using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {

    public float offsetSpeed = 10f;
    private MeshRenderer mr;

	// Use this for initialization
	void Start ()
	{
	    mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Material mat = mr.material;
	    Vector2 offset = mat.mainTextureOffset;
	    offset.x += Time.deltaTime /10f;
	    mat.mainTextureOffset = offset;
	}
}
