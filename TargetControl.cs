using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TargetControl : MonoBehaviour {
	//public GameObject powerup;
	public GameObject[] pwrups;
	Transform tf;
	GameObject control;
	float spd;
	float posx;
	float posy;
	float posz;
	float chon;
	bool jumping;
	bool falling;
	// Use this for initialization
	void Start () {
		Invoke ("Throw", 0.5f);
		control = GameObject.Find ("LevelControl");
		tf = GetComponent<Transform> ();
		posx = tf.position.x;
		posy = tf.position.y;
		posz = tf.position.z;
		chon = tf.position.y;
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Behaviour ();
		Status ();
		Hop ();
	
	}
	void Status() {
		if (tf.position.x > 8.0f) {
			SceneManager.LoadScene ("GameOver");
		}
		if (tf.position.x < -6.5f) {
			Win ();
		}
	}

	void Win() {
		LevelControl lc = control.GetComponent<LevelControl> ();
		int score = (int)lc.tempo;
		PlayerPrefs.SetInt ("lastscore", score);
		Debug.Log ("score "+score+ " last below");
		Debug.Log(PlayerPrefs.GetInt("lastscore", 0));
		StoreNewHighScore (score);
		SceneManager.LoadScene ("YouWin");
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Jump") {
			Debug.Log ("Jump!");
			jumping = true;
			falling = false;
		}
	}
	void Hop() {
		posx = tf.position.x;
		posy = tf.position.y;
		posz = tf.position.z;
		//Debug.Log (tf.position.y+" "+ (chon+2f));
		//negative values here...
		if (jumping && (tf.position.y < (chon + 1f))) {
			posy += 0.03f;
			tf.position = new Vector3 (posx, posy, posz);
			//Debug.Log ("<");
		}
		if (tf.position.y >= chon + 1) {
			//Debug.Log ("--");
			jumping = false;
			falling = true;
		}
		if (falling && tf.position.y > chon) {
			//Debug.Log (">");
			posy -= 0.03f;
			tf.position = new Vector3 (posx, posy, posz);
		}
	}

	void Behaviour(){
		LevelControl lc = control.GetComponent<LevelControl> ();
		spd = lc.speed;
		posx += 0.01f*(5.0f-spd);
		tf.position = new Vector3 (posx, posy, posz);
	}
	void Throw() {
		float interval = Random.Range (2.0f, 4.0f);
		//Instantiate (powerup, tf.position, Quaternion.identity);
		Instantiate (pwrups[UnityEngine.Random.Range(0,pwrups.Length)], tf.position, Quaternion.identity);
		Invoke ("Throw", interval);

	}
	void StoreNewHighScore(int newHighScore) {
		//int oldHighScore = 9999;
		Debug.Log ("hiscore " + PlayerPrefs.GetInt ("highscore", 9998));
		int oldHighScore = PlayerPrefs.GetInt ("highscore", 9998);
		Debug.Log ("oldHighScore "+oldHighScore);
		Debug.Log ("newHighScore "+newHighScore);
		if (newHighScore < oldHighScore) {
			Debug.Log("Entered if");
			PlayerPrefs.SetInt ("highscore", newHighScore);
		}
	}
}
