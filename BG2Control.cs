using UnityEngine;
using System.Collections;

public class BG2Control : MonoBehaviour {
	private Transform tf;
	GameObject control;
	float spd;
	float posx;
	float posy;
	float posz;
	// Use this for initialization
	void Start () {
		control = GameObject.Find ("LevelControl");
		tf = GetComponent<Transform> ();
		posx = tf.position.x;
		posy = tf.position.y;
		posz = tf.position.z;

	}

	// Update is called once per frame
	void Update () {
		LevelControl lc = control.GetComponent<LevelControl> ();
		spd = lc.speed;
		posx -= spd * 0.1f * Time.deltaTime;
		tf.position = new Vector3 (posx, posy, posz);

		if (posx < -70) {
			posx = 70;
		}

	}
}