using UnityEngine;
using System.Collections;

public class backGroundController_script : MonoBehaviour {

	private static Vector2 speed;
	private static float freezeDuration;
	private static int brojBodova;

	// Use this for initialization
	void Start () {

		speed = new Vector2 (-10, 0);
		freezeDuration = 0;
		brojBodova = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("escape")) { // ako je korisnik pritisnuo esc na tastaturi, vracamo ga na pocetni meni
			brojBodova = 0;
			freezeDuration = 0;
			Application.LoadLevel("MainMenu");
		}
		if (freezeDuration > 0) {
			freezeDuration -= Time.deltaTime;
		}
		if (freezeDuration < 0) {
			freezeDuration = 0;
			speed.x = -10;
			speed.y = 0;
		}
	}

	public static Vector2 getGiftSpeed() {
		//funkcija vraca vektor koji definise brzinu po x i y osi
		return speed;
	}

	public static void SetSpeed(float x, float y) { 
		// bez parametara vraca default brzinu
		speed.x = x;
		speed.y = y;
	}

	public static float getFreezeDuration() {
		return freezeDuration;
	}

	public static void addFreezeTime(float f) {
		freezeDuration += f;
	}

	public static void addBodove(int b) {
		brojBodova += b;
	}
	public static int getBodove() {
		return brojBodova;
	}




}
