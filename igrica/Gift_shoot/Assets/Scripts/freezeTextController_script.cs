using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class freezeTextController_script : MonoBehaviour {

	public GameObject textFreeze;

	// Use this for initialization
	void Start () {
		textFreeze.transform.position = new Vector2 (Screen.width * 0.9f, Screen.height * 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		
		Text t = textFreeze.GetComponent<Text> ();

		if (backGroundController_script.getFreezeDuration () > 0) {
			t.text = string.Format("Preostalo vremena: {0}", backGroundController_script.getFreezeDuration());
		}
		else {
			t.text = "";
		}
	}
}
