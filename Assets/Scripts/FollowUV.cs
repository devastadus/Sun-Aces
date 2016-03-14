using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

    public float offsetSpeed = 10f;
    private MeshRenderer mr;
    public float parralax = 2f;

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
	    offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mat.mainTextureOffset = offset;
	}
}
