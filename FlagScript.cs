using UnityEngine;
using System.Collections;

public class FlagScript : MonoBehaviour {
	public GameObject player;
	public string nextLevel;
	private bool isWin;
	private bool winScreen;
	public Texture winTex;

	// Use this for initialization
	void Start () {
		winScreen = false;
		isWin = false;
		if (nextLevel == "win") isWin = true;
	}
	
	void FixedUpdate () {
		Vector3 posDiff = transform.position - player.transform.position;
		if (posDiff.magnitude < .85f ) {
			if(!isWin) Application.LoadLevel(nextLevel);
			else winScreen = true;
		}
	}
	
	void OnGUI() {
		if (winScreen)
			GUI.DrawTexture(new Rect(Screen.width /2 - 256, Screen.height / 2 - 128, 512, 128), winTex);
	}
}
