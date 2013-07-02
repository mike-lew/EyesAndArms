using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Texture deathTex;
	public Texture keyTex;
	
	private int keys = 0;
	private int deaths = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.transform.position.y < -10) {
			GameObject start = GameObject.FindGameObjectWithTag("Respawn");
			gameObject.transform.position = start.transform.position;
			gameObject.transform.rotation = start.transform.rotation;
			deaths++;
		}
	}
	
	void OnGUI() {
		for(int i = 0; i < deaths; i++) {
			GUI.DrawTexture(new Rect(20 + i * 80, 20, 73, 99), deathTex);
		}
		for(int i = 0; i < keys; i++) {
			GUI.DrawTexture(new Rect(20 + i * 110, Screen.height - 100, 100, 86), keyTex);
		}
	}
	
	public void getKey() {
		keys++;
		Debug.Log(keys + " keys");
	}
	
	public bool useKey() {
		if (keys == 0) return false;
		keys--;
		Debug.Log(keys + " keys");
		return true;
	}
}
