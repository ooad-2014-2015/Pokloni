using UnityEngine;
using System.Collections;

public class paketicBasic_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody2D> ().velocity = backGroundController_script.getGiftSpeed ();
		GetComponent<Rigidbody2D> ().angularVelocity = Random.Range (-1000, 1000);
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody2D> ().velocity = backGroundController_script.getGiftSpeed ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {

			//ako smo pogodili objekat, unistavamo ga

			backGroundController_script.addBodove(1);

			Destroy (gameObject);			
		}
	}

	void OnBecameInvisible() {

		Destroy (gameObject);
	}
}
