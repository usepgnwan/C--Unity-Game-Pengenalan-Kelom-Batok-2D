using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pemain : MonoBehaviour {
	public int kecepatan; //kecepatan jalan
	public int pindah; // indikator untuk berputar badan
	public bool balik; //untuk untuk berputar badan true false

	//bagian var lompat
	public int kekuatanLompat; // kecepatan lompat
	public bool tanah; // mengetahui karakter menginjak tanah atau tidak
	public LayerMask targetLayer; // menentukan target layer
	public Transform deteksiTanah; // menentukan keberadaan karakter
	public float jangkaun; // jangkaun loncat
	Rigidbody2D lompat;//mengambil rigidbody
	Animator anim;//untuk animasi

	//untuk touchscreen
	public bool tombolKiri,tombolKanan;

	//untuk nyawa
	public int nyawa; //menampung nyawa
	Text infoNyawa; //untuk ui nyawa
	//untuk koin
	public int koin;//menampung koin
	Text infoKoin;//akses ui koin
	public int totalScore; //score 

	//posisi awal
	public bool ulangi; // untuk indikator mengulangi karakter mengenai musuh pada awal
	Vector2 posisiAwalstart;//posisi awal karakter ketika awal main
	public bool checkpoint;
	checkPoint komponenCheckpoint;

	//tembak
	public GameObject posPeluru; //posisi peluru pada saat ditembak sesuai pos peluru gameobject
	public GameObject peluruBatok; //mengambil objek peluru prefabs
	public bool menembak; //untuk indikator true false animmasi menembak
	public int peluru; //indikator jumlah peluru
	public GameObject buttonTembak; //mengambil button tembak
	public GameObject buttonPeluruhabis; // indikator ketika button tembak hilang
	Text infoPeluru;

	//bagian popup gagal
	gagal komponenGagal; //var ngambil skrip gagal

	// Use this for initialization
	void Start () {
		lompat = GetComponent<Rigidbody2D> (); //mengambil rigidbodi objek untuk lompat
		anim = GetComponent<Animator> (); // mengambil komponen animasi
		infoNyawa = GameObject.Find("UInyawa").GetComponent<Text>(); // mengambil text uinyawa
		infoKoin = GameObject.Find ("UIkoin").GetComponent<Text> (); // mengambil text uikoin
		infoPeluru = GameObject.Find("UIbatok").GetComponent<Text>();//mengambil text uibatok
		komponenGagal = GameObject.Find("Main Camera").GetComponent<gagal>();
		komponenCheckpoint = GameObject.Find("Img_checkpoint").GetComponent<checkPoint>();
	

		posisiAwalstart = transform.position; // posisi awal karakter saat start d mulai
	}
	
	// Update is called once per frame
	void Update () {
		infoNyawa.text = nyawa.ToString(); //menyimpan variable nyawa kedalam ui
		infoKoin.text = koin.ToString();  //menyimpan variable nyawa kedalam ui
		infoPeluru.text = peluru.ToString(); //menyimpan variable peluru
		if (Input.GetKey (KeyCode.D) || tombolKanan==true) {
			transform.Translate (Vector2.right * Time.deltaTime * kecepatan); // bergerak kekanan
			anim.SetBool ("jalan", true);
			pindah = 1;
		} else if (Input.GetKey (KeyCode.A) || tombolKiri == true) {
			transform.Translate (Vector2.left * Time.deltaTime * kecepatan); // bergerak kekiri
			anim.SetBool ("jalan", true);
			pindah = -1;
		} else {
			anim.SetBool ("jalan", false);
		}
		if(Input.GetKey (KeyCode.W)){
			if(tanah == true){
				lompat.AddForce (new Vector2(0, kekuatanLompat));// mengambil scale 2 x,y
			}//lompat
		}

		if(pindah>0 && !balik){
			balikbadan ();
		}else if(pindah<0 && balik){
			balikbadan ();
		} // fungsi untuk flip badan

		tanah = Physics2D.OverlapCircle (deteksiTanah.position, jangkaun, targetLayer); // menentukan loncat ketika ada pada tanah
		if(tanah == false){
			anim.SetBool ("lompat", true);
		}else{
			anim.SetBool ("lompat", false);	
		}//animasi lompat


		//posisi awal untuk karakter ketika kena musuh
		if(ulangi == true){
			if (checkpoint == true) {
				transform.position = komponenCheckpoint.posisiCheckpoint;
				ulangi = false; // posisi karakter ketika sudah kena kepada check point
			} else {
				transform.position = posisiAwalstart;
				ulangi = false; // posisi awal karakter sebelum kena checkpoint
			}

		}//posisii ketika kena musuh


		//posisi ketika game over
		if(nyawa<=0){
			komponenGagal.aktifpopupgagal ();
			gameObject.SetActive (false); //menonaktifkan karakter
		} // fungsi game over


		if (peluru <= 0) {
			buttonTembak.SetActive (false);
			buttonPeluruhabis.SetActive (true);
			lepastembak ();
		} else if (peluru >=1 ) {
			buttonTembak.SetActive (true);
			buttonPeluruhabis.SetActive (false);
		} //mengontrol batasan tembak


	}

	//method untuk flip badan
	void balikbadan(){
		balik = !balik;
		Vector3 pemain = transform.localScale;
		pemain.x *= -1;
		transform.localScale = pemain;

	}

	//untuk tombol kiri untuk maju karakter
	public void tekankiri(){
		tombolKiri = true;
	}
	public void lepaskiri(){
		tombolKiri = false;
	}
	public void tekankanan(){
		tombolKanan = true;
	}
	public void lepaskanan(){
		tombolKanan = false;
	}
	//untuk lompat
	public void tekanlompat(){
		if(tanah == true){
			lompat.AddForce (new Vector2(0, kekuatanLompat));// mengambil scale 2 x,y
		}//lompat
	}
	//untuk menembak
	public void tekantembak(){
		menembak = true;
			anim.SetBool ("tendang", true); //animasi tendang
			Instantiate (peluruBatok, posPeluru.transform.position, peluruBatok.transform.rotation);//fungsi kloning peluru
			peluru--;
	}
	public void lepastembak(){
		menembak = false;
		anim.SetBool ("tendang", false);
	}


	//batas

}
