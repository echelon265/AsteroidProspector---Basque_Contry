using UnityEngine;
using System.Collections;

public class MovimientoAsteroide : MonoBehaviour
{
	public float speed;
	public float tilt;
	
	void Update ()
	{
	}
	
	void FixedUpdate ()
	{
		rigidbody.position = new Vector3
			(
			rigidbody.position.x+5,
			0.0f
			);
		
		/*Funciona pero se sale de la pantalla
		 * rigidbody.position = new Vector3
			(
				rigidbody.position.x, 
				rigidbody.position.y,
				0.0f
			);*/
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}