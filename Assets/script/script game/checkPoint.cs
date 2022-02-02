using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {
	public Vector2 posisiCheckpoint; //mengambil vector2d
	pemain komponenPemain;
	public AudioSource suara; //ambil suara
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain> ();
		posisiCheckpoint = transform.position;//menyimpan posisi checkpoint

	}

	// Update is called once per frame
	void Update () {
		transform.position = posisiCheckpoint; // menyimpan posisi check point ketika variable checkpoint true
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			//print("checkpoint");
			Suaracheckpoint ();
			komponenPemain.checkpoint = true;

		}
	}
	public void Suaracheckpoint(){
		AudioSource playsuara = suara.GetComponent<AudioSource> ();
		playsuara.Play ();
	}
}
