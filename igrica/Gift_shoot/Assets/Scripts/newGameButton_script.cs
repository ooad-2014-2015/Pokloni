using UnityEngine;
using System.Collections;


//skripta koja opisuje ponasanje buttona za pocetak igrice

public class newGameButton_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {

			// funkcija koja se poziva kada je mis kliknut iznad "new game"

			Application.LoadLevel ("GameScreen");
		}
	}
}
