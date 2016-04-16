using UnityEngine;
using System.Collections;

public class WallDeflection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D i_collision){
		if (i_collision.gameObject.tag.Equals ("Player")) {
			
		}
	
	}

}
