using UnityEngine;
using System.Collections;

public class BarraCombustible : MonoBehaviour {

	public Texture2D fuel;
	public int maxHealth = 100;
	public int curHealth = 100; 
	public float healthBarlenght; 
	
	// Use this for initialization
	void Start () {
		healthBarlenght = Screen.width/2; 
	}
	
	// Update is called once per frame
	void Update () {
		AdjustcurHealth(0); 
	}
	
	void OnGUI () {
		GUI.Label(new Rect(10, 35, fuel.width, fuel.height), fuel);
		GUI.Box(new Rect(50, 40, healthBarlenght/2, 20), curHealth +"/"+ maxHealth);
	} 
	
	public void AdjustcurHealth (int adj){
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		//healthBarlenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
		
	} 
}
