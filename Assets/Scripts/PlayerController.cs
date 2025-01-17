﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float ScreenLimitX;
	public float ScreenLimitY;
	public int HP;
	public float Strenght;
	public float Dumping;
	public float StopThreshold;
	public int tiros;
	public GameObject LaserPrefab;
	public GameController gameController;


	private GameObject LaserObject;


	
	Vector2 velocity;
	bool changed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Movimento:
		changed = false;
		velocity -= Dumping * velocity;
		
		
		if (Input.GetKey(KeyCode.RightArrow)){
			velocity.x += Strenght * Time.deltaTime;
			changed = true;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			velocity.x -= Strenght * Time.deltaTime;
			changed = true;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			velocity.y += Strenght * Time.deltaTime;
			changed = true;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			velocity.y -= Strenght * Time.deltaTime;
			changed = true;
		}

		float angle = Vector2.Angle( Vector2.up, velocity);
		angle = velocity.x < 0.0 ? angle :-angle;

		transform.rotation = Quaternion.Euler(0,0,angle);


		if (!((Mathf.Abs(velocity.x) < StopThreshold) && (Mathf.Abs(velocity.y) < StopThreshold))){
			transform.Translate(Vector2.up * velocity.magnitude);
		}
 		
		//Limites da tela:
		Vector2 CorrectPosition = new Vector2(transform.position.x,transform.position.y);

		if (transform.position.x > ScreenLimitX){
			CorrectPosition.x = ScreenLimitX;
			velocity.x = 0;
		}
		if (transform.position.x < -ScreenLimitX){
			CorrectPosition.x = -ScreenLimitX;
			velocity.x = 0;
		}
		if (transform.position.y > ScreenLimitY){
			CorrectPosition.y = ScreenLimitY;
			velocity.y = 0;
		}
		if (transform.position.y < -ScreenLimitY){
			CorrectPosition.y = -ScreenLimitY;
			velocity.y = 0;
		}
		transform.position = CorrectPosition;

		//Atirando:
		bool pressed = false;
		if(tiros>=0){
		if (Input.GetKey(KeyCode.W)){
			pressed = true;
			if (LaserObject == null){
				LaserObject = (GameObject)Object.Instantiate(LaserPrefab,transform.position,Quaternion.Euler(0,0,90));
			}
		}
		if (Input.GetKey(KeyCode.A)){
			pressed = true;
			if (LaserObject == null){
				LaserObject = (GameObject)Object.Instantiate(LaserPrefab,transform.position,Quaternion.Euler(0,0,180));
			}
		}
		if (Input.GetKey(KeyCode.D)){
			pressed = true;
			if (LaserObject == null){
				LaserObject = (GameObject)Object.Instantiate(LaserPrefab,transform.position,Quaternion.Euler(0,0,0));
			}
		}
		if (Input.GetKey(KeyCode.S)){
			pressed = true;
			if (LaserObject == null){
				LaserObject = (GameObject)Object.Instantiate(LaserPrefab,transform.position,Quaternion.Euler(0,0,270));
			}
		}
			tiros-=1;
		}

		if ((pressed == false) && (LaserObject != null)){
			Destroy(LaserObject);
		}

		if (LaserObject != null){
			LaserObject.transform.position = transform.position;
		}
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Velho") {
			gameController.DestruirPersonagem();
			Destroy (coll.gameObject);
			Destroy (gameObject);

		}
		else 
		if (coll.gameObject.tag == "Nave") {
			gameController.DestruirPersonagem();
			Destroy (gameObject);
		}

		else 
		if (coll.gameObject.tag == "Bala") {
			HP -= 1;
			Destroy (coll.gameObject);
			if(HP == 0){
				gameController.DestruirPersonagem();
				Destroy (gameObject);
			}
		}
		else 
		if (coll.gameObject.tag == "SucoRoxo") {
			HP += 1;
			Destroy (coll.gameObject);
		}
		else 
		if (coll.gameObject.tag == "SucoAzul") {
			tiros += 300;
			Destroy (coll.gameObject);
		}
		else 
		if (coll.gameObject.tag == "SucoDub") {
			//MUDAR APARENCIA E MUDAR TEMPORARIAMENTE O TEMPO DE MEDO DOS VELHOS
			Destroy (coll.gameObject);
		}
	}
}
