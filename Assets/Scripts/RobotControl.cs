using UnityEngine;
using System.Collections;

public class RobotControl : MonoBehaviour {
	public  float MaxHP;
	public  float HPRegen;
	public  GameObject Norte;
	public  GameObject Sul;
	public  GameObject Leste;
	public  GameObject Oeste;
	public  GameObject Cabeca;

	public  GameObject bullet;
	public  float bulletCD;

	public  Sprite Still;
	public  Sprite Moving;
	
	public  GameObject Jogador;
	public  float speed;

	public  float StepCooldown;
	public  float StepTime;

	private float bulletNextCooldown;
	private float stepNextCooldown;
	private float stepWait;

	private float RotationAmount;

	private float LaserTime;

	private float HP;


	// Use this for initialization
	void Start () {
		bulletNextCooldown = Time.time + bulletCD;
		stepNextCooldown = Time.time + StepCooldown;
		stepWait = Time.time + StepCooldown + StepTime;
		RotationAmount = 45/bulletCD;

		HP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
		HP += HPRegen * Time.deltaTime;
		if (HP >= MaxHP){
			HP = MaxHP;
		}
		float RedIntensity =( 255.0f * (HP/MaxHP));
		Color myColor = new Vector4(255.0f,RedIntensity,RedIntensity,255.0f);
		GetComponent<SpriteRenderer>().color = myColor;

		if (Time.time >= stepNextCooldown){
			SpriteRenderer SR = GetComponent<SpriteRenderer>();
			SR.sprite = Moving;
			if (Time.time > stepWait) {
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

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Laser") {
			LaserTime = Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Laser") {
			HP -= (Time.time - LaserTime);

			if(HP <= 0){
				Destroy(Cabeca);
				Destroy(gameObject);
			}
		}
	}
}