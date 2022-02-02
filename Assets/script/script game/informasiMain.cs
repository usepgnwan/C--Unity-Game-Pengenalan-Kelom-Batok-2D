using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informasiMain : MonoBehaviour {
	public GameObject popupInfo;
	public AudioSource suara;


	public void tutuppopupinfo(){
		suarapopupinfo ();
		popupInfo.SetActive(false);
		Destroy (gameObject);
	}
	void suarapopupinfo(){
		AudioSource playSuara = suara.GetComponent<AudioSource>(); //mengambil komponen audiosource
		playSuara.Play ();
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			//print("tdhnf");
			popupInfo.SetActive (true);
		}
	}
}
