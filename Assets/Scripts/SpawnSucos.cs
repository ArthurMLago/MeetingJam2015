using UnityEngine;
using System.Collections;

public class SpawnSucos : MonoBehaviour {

	public GameObject SucoAzul;
	public GameObject SucoRoxo;
	public GameObject SucoDub;
	public GameObject spawnPoint;
	public float CD;
	float nxtSpawn;
	// Use this for initialization
	void Start () {
		nxtSpawn = Time.time + CD;
	}
	
	// Update is called once per frame
	void Update () {
		int i;
		if(Time.time >= nxtSpawn){
			nxtSpawn = Time.time + CD;
			i = Random.Range(1,3);
			if(i == 1) Instantiate(SucoAzul, spawnPoint.transform.position + new Vector3(Random.Range(-10,10),Random.Range(-10,10),0) , Quaternion.identity);
			else if(i == 2) Instantiate(SucoRoxo, spawnPoint.transform.position + new Vector3(Random.Range(-10,10),Random.Range(-10,10),0) , Quaternion.identity);
			else if(i == 3) Instantiate(SucoDub, spawnPoint.transform.position + new Vector3(Random.Range(-10,10),Random.Range(-10,10),0) , Quaternion.identity);
		}
	}
}