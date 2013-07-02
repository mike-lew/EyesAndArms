using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	private int step = 0;
	private Vector3 loc_move = new Vector3(2, 1, 2);
	private Vector3 loc_echo = new Vector3(0, 1, -6);
	private Vector3 loc_trap = new Vector3(-4, 1, -4);
	private Vector3 loc_door = new Vector3(-4, 1, 6);
	private Vector3 loc_wall = new Vector3(4, 1, 6);
	private Vector3 loc_flag = new Vector3(4, 1, 0);
	
	public Texture tut_move;
	public Texture tut_echo;
	public Texture tut_trap;
	public Texture tut_door;
	public Texture tut_wall;
	public Texture tut_flag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 player = gameObject.transform.position;
		if ((loc_move - player).magnitude < 1.5f) {
			step = 0;
		}
		else if ((loc_echo - player).magnitude < 1.5f) {
			step = 1;
		}
		else if ((loc_trap - player).magnitude < 1.5f) {
			step = 2;
		}
		else if ((loc_door - player).magnitude < 1.5f) {
			step = 3;
		}
		else if ((loc_wall - player).magnitude < 1.5f) {
			step = 4;
		}
		else if ((loc_flag - player).magnitude < 1.5f) {
			step = 5;
		}
	}
	
	void OnGUI() {
		switch (step) {
		case 0:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 229, Screen.height / 2 - 80, 458, 161), tut_move);
			break;
		case 1:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 229, Screen.height / 2 - 80, 458, 161), tut_echo);
			break;
		case 2:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 253, Screen.height / 2 - 80, 506, 162), tut_trap);
			break;
		case 3:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 257, Screen.height / 2 - 120, 514, 240), tut_door);
			break;
		case 4:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 260, Screen.height / 2 - 80, 521, 162), tut_wall);
			break;
		case 5:
			GUI.DrawTexture(new Rect(Screen.width / 2 - 260, Screen.height / 2 - 80, 521, 162), tut_flag);
			break;
		}
	}
}
