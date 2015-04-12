using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float screenLimitY;
	public float screenLimitX;
	public float masterSpeed;

	// Use this for initialization
	void Start () {
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

}
