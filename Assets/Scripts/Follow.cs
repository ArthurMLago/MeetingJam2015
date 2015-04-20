using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject Jogador;
	public float speed;

	public float ScreenLimitX;
	public float ScreenLimitY;

	public float LaserNecessario;
	private float LaserAtual = 0;
	private float LaserTime;
	bool velho = true;
	// Use this for initialization
	void Start () {
		LaserAtual = LaserNecessario;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 caminho;
		caminho = Jogador.transform.position - transform.position;
		caminho.Normalize();

		float angle = Vector2.Angle( Vector2.up, caminho);
		angle = caminho.x < 0.0 ? angle :-angle;
		
		transform.rotation = Quaternion.Euler(0,0,angle);
		if (velho){
			transform.Translate(Vector2.up * Time.deltaTime);
		}else{
			transform.Translate(-Vector2.up * Time.deltaTime);
		}

		Vector2 NewPosition = transform.position;
		if (transform.position.x > ScreenLimitX){
			NewPosition.x = ScreenLimitX;
		}
		if (transform.position.x < -ScreenLimitX){
			NewPosition.x = -ScreenLimitX;
		}
		if (transform.position.y > ScreenLimitY){
			NewPosition.y = ScreenLimitY;
		}
		if (transform.position.y < -ScreenLimitY){
			NewPosition.y = -ScreenLimitY;
		}
		transform.position = NewPosition;



	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Bala") {
			Destroy (coll.gameObject);
			velho = true;
		}
		if (coll.gameObject.tag == "Laser"){
			LaserTime = Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Laser") {
			LaserAtual -= (Time.time - LaserTime);
			
			if(LaserAtual <= 0){
				velho = false;
			}
		}
	}

}