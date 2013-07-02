using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 posDiff = transform.position - player.transform.position;
		if (posDiff.magnitude < .5f) {
			player.GetComponent<PlayerScript>().getKey();
			DestroyImmediate(gameObject);
		}
	}
}
