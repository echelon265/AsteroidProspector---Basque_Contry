using UnityEngine;
using System.Collections;

public class PlayAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")){
			//ray();
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				ray (hit.collider.gameObject);
			}

		}
	}

	void ray(GameObject o){
		if (o.tag == "play"){
			PlayerPrefs.SetInt("score",0);
			PlayerPrefs.SetInt("health",100);
			PlayerPrefs.SetInt("fuel",100);
			Application.LoadLevel("landed");
		}
		else if(o.tag == "help"){
			Application.LoadLevel("help");
		}
		else if(o.tag == "about"){
			Application.LoadLevel("about");
		}
	}
}
