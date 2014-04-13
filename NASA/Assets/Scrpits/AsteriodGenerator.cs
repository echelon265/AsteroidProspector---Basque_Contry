using UnityEngine;
using System.Collections;

public class AsteriodGenerator : MonoBehaviour {

	public GameObject asteroid;
	public float posYInicial, posYFinal;
	public int x, y, z;

	void Start () {
		Debug.Log((int)Time.time - Time.deltaTime);
		//if ((int)(Time.time - Time.deltaTime)%2 == 0){
		for(int i = 0; i< 50; i++)
			generar();
		//}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

			
	}

	void generar(){
		//yield WaitForSeconds(1.0);
		Vector3 pos = new Vector3(x,  y, z);
		Quaternion rotation = Quaternion.identity;
		asteroid  = (GameObject)Instantiate(asteroid, pos, rotation);
	}
}
