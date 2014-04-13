using UnityEngine;
using System.Collections;

public class clickHelp : MonoBehaviour {
	SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
			Application.LoadLevel(1);
	}

}
