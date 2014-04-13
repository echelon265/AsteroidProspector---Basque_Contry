using UnityEngine;
using System.Collections;

public class Labels : MonoBehaviour {

	public Texture2D dollar;
	public int points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		GUI.Label(new Rect(50, 70, 100, 20), "Points: "+PlayerPrefs.GetInt("score"));
		GUI.Label(new Rect(10, 60, dollar.width, dollar.height), dollar);
	}
}
