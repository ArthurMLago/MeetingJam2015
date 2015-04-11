using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float screenLimitY;
	public float screenLimitX;
	public float masterSpeed;
	float tempo;

	// Use this for initialization
	void Start () {
		tempo = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, masterSpeed * Time.deltaTime, 0);
		if (transform.position.x > screenLimitX){
			Destroy(gameObject);
		}
		if (transform.position.x < -screenLimitX){
			Destroy(gameObject);
		}
		if (transform.position.y > screenLimitY){
			Destroy(gameObject);
		}
		if (transform.position.y < -screenLimitY){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Velho") {
			Destroy (gameObject);//se o tiro fordestruido antes do asteroid, o programa nao chega a destruir o astero
		}
	}
}
