using UnityEngine;
using System.Collections;

public class MovimientoPerforadora : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public Texture2D healthImage;
	public int maxHealth = 100;
	public int curHealth = 1; 
	public float healthBarlenght; 
	public int quantity = 0;
	public bool mineAllowed = false;

	// Use this for initialization
	void Start () {
		healthBarlenght = Screen.width/2;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustcurHealth(-1); 

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
				rigidbody.position.z
			);
		
		if(moveHorizontal<0){
			//Code for action on mouse moving left
			mineAllowed=true;
			print("Mouse moved left");
			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
		if(moveHorizontal>0){
			mineAllowed=true;
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

		if(Input.GetKeyDown("space")){
			if(mineAllowed){
				Debug.Log("Espacio");
				moverPerforadora();
				AdjustcurHealth(+15);
			}

			
		}
	}
	void OnGUI () {
		GUI.Label(new Rect(10, 0, healthImage.width, healthImage.height), healthImage);
		GUI.Label(new Rect(10, 40, healthImage.width+20, healthImage.height), "Content: "+quantity+"/3");
		GUI.Box(new Rect(50, 10, healthBarlenght/2, 20), curHealth +"/"+ maxHealth);
	} 

	public void AdjustcurHealth (int adj){
		curHealth += adj;
		
		if(curHealth < 0){
			curHealth = 0;
			//Application.LoadLevel(1);
		}
		
		
		if(curHealth > maxHealth){
			curHealth = 0;
			// Hay premio???
			if(quantity != 2){
				quantity++;
				mineAllowed=false;
				PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+10);
			}else{
				PlayerPrefs.SetInt("health",PlayerPrefs.GetInt("health")+10);
				PlayerPrefs.SetInt("fuel",PlayerPrefs.GetInt("fuel")+5);
				Application.LoadLevel(2);
			}

		}
		
		if(maxHealth < 1){
			maxHealth = 1;
		}
			
		
		healthBarlenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
		
	}

	public void moverPerforadora(){
		Vector3 movement = new Vector3 (0, transform.position.y+2, 0.0f);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
				rigidbody.position.z
				);
	}
}
