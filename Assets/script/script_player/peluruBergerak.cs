using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluruBergerak : MonoBehaviour {
	public float jarakPeluru; //mengatur jarak peluru
	float scaleKarakter;//variable untuk menembak berbalik
	// Use this for initialization

	void Start () {
		scaleKarakter = GameObject.Find ("karakter").transform.localScale.x;
		
	}//method yang pertama kali d proses
	
	// Update is called once per frame
	void Update () {
		if(scaleKarakter == 1f){
			GetComponent<Rigidbody2D>().velocity = new Vector2 (12f, GetComponent<Rigidbody2D>().velocity.y);//menggerakan peluru
			Destroy (gameObject, jarakPeluru);//membatasi jarak peluru
		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-12f, GetComponent<Rigidbody2D>().velocity.y);
			Destroy (gameObject, jarakPeluru);
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "musuh"){
			//	print ("berhasil");
			print("peluru hancur");
			Destroy (gameObject);

		}

	}



}
