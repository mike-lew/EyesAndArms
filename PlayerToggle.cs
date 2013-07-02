using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerToggle : MonoBehaviour {
	public float onIntensity_ = .3f;
	public bool isEyes_ = false;
	
	private List<GameObject> gos_;

	void Start () {
		//create pitch blackness for blind player
		RenderSettings.ambientLight = Color.black;
		//remove floor colliders on traps
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Floor")) {
			GameObject p = null;
			for(int i = 0; i < go.transform.parent.GetChildCount(); i++) {
			   Transform child = go.transform.parent.GetChild(i);
				if (Mathf.RoundToInt(child.position.x) == Mathf.RoundToInt(go.transform.position.x) &&
					Mathf.RoundToInt(child.position.z) == Mathf.RoundToInt(go.transform.position.z) &&
					child.gameObject.name == "Trap") {
					p = child.gameObject;
					break;
				}
			}
			if (p != null) {
				go.collider.enabled = false;
				p.collider.enabled = false;
			}
		}
		//create particle go list
		gos_ = new List<GameObject>();
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Particle")) {
			Destroy(go.GetComponent<ParticleSystem>());
			gos_.Add(go);
		}
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (isEyes_) {
				Light eyes = transform.Find("Eyes").gameObject.GetComponent<Light>() as Light;
				eyes.intensity = onIntensity_;
				foreach (GameObject go in gos_) {
					Destroy(go.GetComponent<ParticleSystem>());
					setupGO(go);
				}
				isEyes_ = false;
			}
			else {
				Light eyes = transform.Find("Eyes").gameObject.gameObject.GetComponent<Light>() as Light;
				eyes.intensity = 0;
				foreach (GameObject go in gos_) {
					ParticleSystem ps = go.AddComponent<ParticleSystem>();
					setupPS(ps);
					setupGO(go);
					ps.Play();
				}
				isEyes_ = true;
			}
		}
	
	}
	
	private ParticleSystem setupPS(ParticleSystem ps) {
		switch (ps.gameObject.name) {
		case "Particle":
			ps.startColor = new Color(0, 191, 255, 255);
			break;
		case "Trap":
			ps.startColor = Color.red;
			break;
		case "Door":
			ps.startColor = Color.yellow;
			break;
		case "InvisiWall":
			ps.startColor = Color.green;
			break;
		}
		ps.startLifetime = .5f;
		ps.startSpeed = .5f;
		ps.startSize = .1f;
		ps.emissionRate = 10;
		
		return ps;
	}
	
	private void setupGO(GameObject go) {
		switch (go.name) {
		case "InvisiWall":
			if (!isEyes_)
				go.transform.parent.GetChild(0).gameObject.renderer.enabled = false;
			else
				go.transform.parent.GetChild(0).gameObject.renderer.enabled = true;
			break;
		}
	}
	
	public void removePartobsticle(GameObject go) {
		gos_.Remove(go);
	}
}
