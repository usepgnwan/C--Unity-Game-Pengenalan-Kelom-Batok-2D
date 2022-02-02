using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jurang : MonoBehaviour {
	pemain komponenPemain;
	public AudioSource suara;
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find("karakter").GetComponent<pemain>(); ///mengambil komponen skrip pemain ParticleSystemCustomData karakter
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			print ("jatuh kejurang");
			suarajurang ();
			komponenPemain.nyawa--;
			komponenPemain.ulangi = true;
		}
	}

	void suarajurang(){
		AudioSource playSuara = suara.GetComponent<AudioSource> ();
		playSuara.Play ();
	}
}
