using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	bool alive = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		if (alive == false) {
		if(Input.GetKey(KeyCode.R)) {
			Application.LoadLevel("Jogo");
		}
//		}
	}

	public void DestruirPersonagem() {
		alive = false;
	}
}
