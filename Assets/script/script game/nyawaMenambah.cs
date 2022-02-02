using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyawaMenambah : MonoBehaviour {
	pemain komponenPemain; //mengambil komponen pemain
	public AudioSource suara;
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain> ();
	}
	

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			print ("nyawa bertambah");
			suaranyawa();
			komponenPemain.nyawa++;
			Destroy (gameObject);
		}
	}
	void suaranyawa(){
		AudioSource playsuara = suara.GetComponent<AudioSource> ();
		playsuara.Play ();
	}
}
