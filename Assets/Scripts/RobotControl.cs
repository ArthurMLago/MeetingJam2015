using UnityEngine;
using System.Collections;

public class RobotControl : MonoBehaviour {

	public GameObject Norte;
	public GameObject Sul;
	public GameObject Leste;
	public GameObject Oeste;

	public GameObject Cabeca;

	public GameObject bullet;
	public float bulletCD;

	public Sprite Still;
	public Sprite Moving;
	
	public GameObject Jogador;
	public float speed;

	public float StepCooldown;
	public float StepTime;

	float bulletNextCooldown;
	float stepNextCooldown;
	float stepWait;

	float RotationAmount;


	// Use this for initialization
	void Start () {
		bulletNextCooldown = Time.time + bulletCD;
		stepNextCooldown = Time.time + StepCooldown;
		stepWait = Time.time + StepCooldown + StepTime;
		RotationAmount = 45/bulletCD;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= stepNextCooldown){
			SpriteRenderer SR = GetComponent<SpriteRenderer>();
			SR.sprite = Moving;
			if (Time.time > stepWait){
				SR.sprite = Still;
				Vector2 caminho;
				caminho = Jogador.transform.position - transform.position;
				caminho.Normalize();
				transform.Translate (caminho * StepCooldown * speed);

				Cabeca.transform.position = transform.position;
				//Resetar cooldown:
				stepNextCooldown = Time.time + StepCooldown;
				//Resetar cooldown:
				stepWait = Time.time + StepCooldown + StepTime;

				Vector2 NewScale = transform.localScale;
				NewScale.y *= -1;
				transform.localScale = NewScale;
			}


		}

		Cabeca.transform.Rotate(0,0,RotationAmount*Time.deltaTime);


		if (Time.time >= bulletNextCooldown){
			bulletNextCooldown = Time.time + bulletCD;
			Instantiate(bullet, Norte.transform.position, Norte.transform.rotation);
			Instantiate(bullet, Sul.transform.position  , Sul.transform.rotation);
			Instantiate(bullet, Leste.transform.position, Leste.transform.rotation);
			Instantiate(bullet, Oeste.transform.position, Oeste.transform.rotation);
		}


	}
}