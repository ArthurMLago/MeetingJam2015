﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float CharacterSpeed;

	public float ScreenLimitX;
	public float ScreenLimitY;

	public float Strenght;
	public float Dumping;
	public float StopThreshold;
	
	Vector2 velocity;
	bool changed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


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
		transform.Translate(velocity);

		transform.Translate(velocity);
		
		if (changed == false){
			if (Mathf.Abs(velocity.x) < StopThreshold){
				velocity.x = 0;
			}
			if (Mathf.Abs(velocity.y) < StopThreshold){
				velocity.y = 0;
			}
		}
//////////////////

		Vector2 CorrectPosition = new Vector2(transform.position.x,transform.position.y);

		if (transform.position.x > ScreenLimitX){
			CorrectPosition.x = ScreenLimitX;
		}
		if (transform.position.x < -ScreenLimitX){
			CorrectPosition.x = -ScreenLimitX;
		}
		if (transform.position.y > ScreenLimitY){
			CorrectPosition.y = ScreenLimitY;
		}
		if (transform.position.y < -ScreenLimitY){
			CorrectPosition.y = -ScreenLimitY;
		}
		transform.position = CorrectPosition;



	}
}