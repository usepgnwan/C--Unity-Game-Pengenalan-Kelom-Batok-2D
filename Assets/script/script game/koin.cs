using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour {
	pemain komponenPemain; //mengambil fungsi script pemain untuk destroy pemain
	public AudioSource suara; // mengambil audiosource
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain>();
	}
	

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			//print ("koin didapat");
			suarakoin ();
			komponenPemain.koin++;
			komponenPemain.totalScore = komponenPemain.koin * 10;
			Destroy (gameObject);
		}//untuk mengurangi darah player
	}



	public void suarakoin(){
		AudioSource playSuara = suara.GetComponent<AudioSource> ();
		playSuara.Play();
	}
}
