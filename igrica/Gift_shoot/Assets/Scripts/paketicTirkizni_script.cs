using UnityEngine;
using System.Collections;

public class paketicTirkizni_script : MonoBehaviour {

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
			// tirkizni paketic usporava sve ostale narednih 5 sekundi

			backGroundController_script.addFreezeTime(5);
			backGroundController_script.SetSpeed(-5, 0);
			
			Destroy (gameObject);			
		}
	}
}
