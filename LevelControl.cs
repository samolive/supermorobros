using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using GoogleMobileAds.Api;

public class LevelControl : MonoBehaviour {
	public GameObject[] ground;
	public Transform target;
	public float speed = 5;
	public float tempo = 0;
	void Start () {
		Instantiate (ground[UnityEngine.Random.Range(0,3)], new Vector3(0,-1.5f,0), Quaternion.identity);
		Instantiate (ground[UnityEngine.Random.Range(0,3)], new Vector3(22.8f,-1.5f,0), Quaternion.identity);
		Instantiate (ground[UnityEngine.Random.Range(0,3)], new Vector3(45.6f,-1.5f,0), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			SceneManager.LoadScene ("GameOver");
		}
	}
}
