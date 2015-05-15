using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bodoviController_script : MonoBehaviour {

	public GameObject textBodovi;
	public GameObject background;

	// Use this for initialization
	void Start () {
		textBodovi.transform.position = new Vector2 (Screen.width * 0.9f, Screen.height * 0.10f);
	}
	
	// Update is called once per frame
	void Update () {

		Text t = textBodovi.GetComponent<Text> ();
		t.text = string.Concat ("Osvojenih bodova: ", backGroundController_script.getBodove ().ToString ());
	
	}
}
