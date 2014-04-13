using UnityEngine;
using System.Collections;

public class goBack : MonoBehaviour {

	public string ventanaAnterior;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")){
			//ray();
			Debug.Log("click");
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
				ray (hit.collider.gameObject);	
		}
	}
	
	void ray(GameObject o){
		if (o.tag == "back"){
			Application.LoadLevel("Principal");
		}
	}
}
