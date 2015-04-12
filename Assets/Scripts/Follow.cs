using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject Jogador;
	public float speed;

	public float LaserNecessario;
	private float LaserAtual = 0;
	bool velho = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 caminho;
		caminho = Jogador.transform.position - transform.position;
		caminho.Normalize();

		float angle = Vector2.Angle( Vector2.up, caminho);
		angle = caminho.x < 0.0 ? angle :-angle;
		
		transform.rotation = Quaternion.Euler(0,0,angle);

		transform.Translate(Vector2.up * Time.deltaTime);



		if(velho){
			//Mudar aparencia fantasma velho
			transform.Translate (caminho * speed * Time.deltaTime);
		}
		else {
			//Mudar Aparencia Jovem
			transform.Translate (-1 * caminho * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Bala") {
			Destroy (coll.gameObject);
			velho = true;
		}
		if (coll.gameObject.tag == "Laser"){

		}
	}

}