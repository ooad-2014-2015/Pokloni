using UnityEngine;
using System.Collections;

public class spawnController_script : MonoBehaviour {

	public GameObject giftBasic;
	public GameObject giftTirkizni;
	public GameObject giftLjubicasti;
	public GameObject giftZeleni;


	void spawnRandomGift() {

		// stvara poklon slucajnim uzorkom na svojoj lokaciji

		float test = Random.Range (0, 1.1f);

		if (test >= 0.8f)
			Instantiate (giftBasic, transform.position, Quaternion.identity);
		else if (test >= 0.6f)
			Instantiate (giftTirkizni, transform.position, Quaternion.identity);
		else if (test >= 0.4f)
			Instantiate (giftLjubicasti, transform.position, Quaternion.identity);
		else
			Instantiate (giftZeleni, transform.position, Quaternion.identity);
	}

	// Use this for initialization
	void Start () {

		InvokeRepeating ("spawnRandomGift", 1f, 0.5f);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
