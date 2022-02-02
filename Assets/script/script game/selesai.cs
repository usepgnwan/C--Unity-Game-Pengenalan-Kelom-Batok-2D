using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //preferences untuk menggunakan scane manager

public class selesai : MonoBehaviour {
	public GameObject popupMenang;//mengambil panel menang
	pemain komponenPemain;
	paused komponenPaused;
	public int sceneSelanjutnya; //wadah untuk menyimpan scene selanjutnya

	public GameObject bintang1;
	public GameObject bintang2;
	public GameObject bintang3;

	public bool finish = false;
	 Text score; //score untuk popup
	// Use this for initialization
	void Start () {
		komponenPemain = GameObject.Find ("karakter").GetComponent<pemain> ();//mengambil script pemain
		komponenPaused = GameObject.Find ("Main Camera").GetComponent<paused> ();//mengambil script pemain
		score = GameObject.Find ("UIscore").GetComponent<Text> ();//menyimpan score ke ui UIscore yg ada di panel finish
		sceneSelanjutnya = SceneManager.GetActiveScene ().buildIndex + 1; // menambah no scene aktif ke scene selanjutnya
	}
	
	// Update is called once per frame
	void Update () {
		if(!finish){
			popupMenang.SetActive (false);
		}

		PlayerPrefs.SetInt ("score", komponenPemain.koin * 10); // save koin menjadi prefabe dgn nama score
	}
	public void aktifpopupmenang(){
		finish = !finish;
		popupMenang.SetActive (finish); 
		score.text = "Score : "+ PlayerPrefs.GetInt ("score").ToString(); //menampilkan score pada ui popup
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player"){
			print ("finish");

			if (SceneManager.GetActiveScene ().buildIndex == 6) {
				SceneManager.LoadScene (sceneSelanjutnya); // ketika sudah menyelesaikan level akhir
			} else {
				aktifpopupmenang ();
				menentukanbintang ();
				if(sceneSelanjutnya > PlayerPrefs.GetInt("aktifLevel")){
					PlayerPrefs.SetInt ("aktifLevel", sceneSelanjutnya); // membuka level selanjutnya menggunakan prefab di script unlock level
				}
			} // untuk membuka level

		}
	}//untuk player menyentuh finish

	public void levelselanjutnya(){
		komponenPaused.klikbutton();
		Application.LoadLevel (sceneSelanjutnya);
	}
	public void menentukanbintang(){
		
		if (komponenPemain.totalScore >= 450) {
			bintang1.SetActive (false);
			bintang2.SetActive (false);
			bintang3.SetActive (true);
		} else if (komponenPemain.totalScore >= 250) {
			bintang1.SetActive (false);
			bintang2.SetActive (true);
			bintang3.SetActive (false);
		} else if (komponenPemain.totalScore >= 100) {
			bintang1.SetActive (true);
			bintang2.SetActive (false);
			bintang3.SetActive (false);
		} else {
			bintang1.SetActive (false);
			bintang2.SetActive (false);
			bintang3.SetActive (false);
		}//fungsi untuk menentukan bintang
			
	}

	public void kemenu(){
		komponenPaused.kemenu ();//mengambil fungsi kembali kehalaman menu
	}


}
