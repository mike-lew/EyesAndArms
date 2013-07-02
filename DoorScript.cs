using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 posDiff = transform.position - player.transform.position;
		if (posDiff.magnitude < .85f && player.GetComponent<PlayerScript>().useKey()) {
			for (int i = 0; i < gameObject.transform.childCount; i++) {
				GameObject child = gameObject.transform.GetChild(i).gameObject;
				if (child.tag == "Particle") player.GetComponent<PlayerToggle>().removePartobsticle(child);
			}
			DestroyImmediate(gameObject);
		}
	}
}
