using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhBergerak : MonoBehaviour {
	public float speed; //untuk kecepatan musuh bergerak
	public bool moveRight; // indikator batas gerak
	public bool balik; // indikator flip badan musuh
	public int pindah; // batasan untuk bisa flib badan


	pemain komponenPemain; //mengambil fungsi script pemain untuk destroy pemain
	public AudioSource suara;
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain>();

	}
	
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.Translate (2 * Time.deltaTime * speed, 0,0); // membuat musuh bergerak kekanan
			pindah = 1; //
		} else {
			transform.Translate (-2 * Time.deltaTime * speed, 0,0); // // membuat musuh bergerak kekiri
			pindah = -1; //
		}
		if( pindah> 0 && !balik){
			balikbadan();
		}else if (pindah <0 && balik){
			balikbadan();
		} //flip badan
	}
	void balikbadan(){
		balik = !balik;
		Vector3 musuh = transform.localScale; //mengambil scale x 
		musuh.x *= -1;
		transform.localScale = musuh;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "batas"){
	
				if (moveRight) {
					moveRight = false;
					balik = true;
				} else {
					moveRight = true;
				balik = false;
				}
		} //batas musuhh gerak

		if(other.transform.tag == "Player"){
		//	print ("kurangi nyawa");
			suaramusuh (); // mengambil fungsi suara
			komponenPemain.ulangi = true; // untuk kembali ke posisi awal
			komponenPemain.nyawa--;
		}//untuk mengurangi darah player dari mengambil tag player ketika peluru bersentuhan dengan objek
		if(other.transform.tag == "peluru"){
		//	print ("berhasil");
			Destroy (gameObject);
			suaramusuh ();
		}

	}

	void suaramusuh(){
		AudioSource playsuara = suara.GetComponent<AudioSource> ();
		playsuara.Play ();
	} // suara untuk musuh
}
