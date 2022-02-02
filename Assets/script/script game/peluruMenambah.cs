using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluruMenambah : MonoBehaviour {
	pemain komponenPemain;
	public AudioSource suara;
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain> ();
	}
	
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag =="Player"){
			print ("peluuru bertambah");
			suaratambahpeluru ();
			komponenPemain.peluru++;
			Destroy (gameObject);
		}
	}

	void suaratambahpeluru(){
		AudioSource playSuara = suara.GetComponent<AudioSource> ();
		playSuara.Play ();
	}
}
