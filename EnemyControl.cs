using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	Transform tf;
	//public GameObject obstacle;
	public GameObject[] obstcls;
	float tfx;
	float tfy;
	float tfz;
	int direction;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		Invoke ("Throw", 2.0f);
		direction = +1;
		tf = GetComponent<Transform> ();
		tf.localScale = new Vector3 (0.7f, 0.7f, 1);
		tfy = tf.position.y;
		tfz = tf.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	void Move() {
		tfx = tf.position.x;
		if (tfx > 6) {
			direction = -1;
		}
		if (tfx < -5) {
			direction = 1;
		}
		tf.localScale = new Vector2 (direction, 1f);
		tfx = tfx + 0.05f * direction;
		tf.position = new Vector3 (tfx, tfy, tfz);

				
	}
	void StopAnim() {
		animator.SetBool ("throwing", false);
	}

	void Throw() {
		animator.SetBool ("throwing", true);
		Debug.Log ("Throw!");
		Invoke ("Drop", 0.3f);
		//Instantiate (obstacle, tf.position - offset, Quaternion.identity);
		//float interval = Random.Range (1.5f, 3.0f);
		//Invoke ("Throw", interval);

	}
	void Drop() {
		Debug.Log ("Drop!");
		Vector3 offset = new Vector3(-0.1f + direction*0.3f,0,0);
		//Instantiate (obstacle, (tf.position - offset), Quaternion.identity);
		Instantiate (obstcls[UnityEngine.Random.Range(0,obstcls.Length)], tf.position-offset, Quaternion.identity);
		Invoke("StopAnim", 0.2f);
		float interval = Random.Range (1.0f, 3.0f);
		Invoke ("Throw", interval);
	}
}
