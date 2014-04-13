using UnityEngine;
using System.Collections;

public class AsteroidDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Hola");
		Destroy(other.gameObject);
	}

}
