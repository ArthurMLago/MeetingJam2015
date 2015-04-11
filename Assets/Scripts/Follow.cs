using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject Jogador;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 caminho;
		caminho = Jogador.transform.position - transform.position;
		caminho.Normalize();
		transform.Translate (caminho * speed * Time.deltaTime);
	}


	}