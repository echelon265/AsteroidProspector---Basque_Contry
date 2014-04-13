using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class MovimientoNave : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject vida;

	void Update ()
	{
		/*if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//audio.Play ();
		}*/
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
				-2.0f
			);

		//Funciona pero se sale de la pantalla
		 /*rigidbody.position = new Vector3
			(
				rigidbody.position.x, 
				rigidbody.position.y,
				0.0f
			);*/

		if(moveHorizontal<0){
			//Code for action on mouse moving left
			print("Mouse moved left");
			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
		if(moveHorizontal>0){
			//Code for action on mouse moving right
			print("Mouse moved right");
			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
		if(moveVertical<0){
			//Code for action on mouse moving down
			print("Mouse moved down");
			//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt*2);
		}
		if(moveVertical>0){
			//Code for action on mouse moving up
			print("Mouse moved up");
			//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
	}
	void OnCollisionEnter(Collision collision) {
		if((Time.time - Time.deltaTime)>4){
			if(collision.gameObject.name.Contains("Deimos") && collision.relativeVelocity.magnitude > 2){
				Debug.Log("Hemos chocado con un asteroide");
				BarraVida barra = vida.GetComponent<BarraVida>();
				barra.AdjustcurHealth(-10);
				PlayerPrefs.SetInt("health",PlayerPrefs.GetInt("health")-10);
				PlayerPrefs.SetInt("fuel",PlayerPrefs.GetInt("fuel")-1);
				BarraCombustible barraC = vida.GetComponent<BarraCombustible>();
				barraC.AdjustcurHealth(-1);
			} else {
				BarraCombustible barra = vida.GetComponent<BarraCombustible>();
				barra.AdjustcurHealth(-10);
				PlayerPrefs.SetInt("health",PlayerPrefs.GetInt("health")-10);
				Application.LoadLevel(4);
			}
		}

	}
}