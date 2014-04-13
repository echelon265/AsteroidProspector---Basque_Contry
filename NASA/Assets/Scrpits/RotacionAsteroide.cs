using UnityEngine;
using System.Collections;

public class RotacionAsteroide : MonoBehaviour {

	public int tumble;
	// Use this for initialization
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
