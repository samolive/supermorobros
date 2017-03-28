using UnityEngine;
using System.Collections;

public class ScrollUIBG : MonoBehaviour {
	public Transform img;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xpos = img.position.x - .5f;
		if (img.position.x < -450)
			xpos = 950;
		float ypos = img.position.y;
		float zpos = img.position.z;
		img.position = new Vector3 (xpos, ypos, zpos);

	
	}
}
