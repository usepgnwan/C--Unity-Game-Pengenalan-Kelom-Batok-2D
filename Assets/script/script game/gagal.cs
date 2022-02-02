using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //preferences untuk menggunakan scane manager

public class gagal : MonoBehaviour {
	public GameObject popupGagal; //ambil panel
	private bool gameOver = false; //variable untuk indikasi game over 
	public AudioSource suara; // variabel untuk audio
	paused komponenPaused; //mengambil komponen paused
	public int restartLevel;//mengambil scane 
	// Use this for initialization
	void Start () {
		komponenPaused = GameObject.Find ("Main Camera").GetComponent<paused> ();//mengambil komponen skrip paused pada main camera	
		restartLevel = SceneManager.GetActiveScene ().buildIndex; //mengambil no yang sedang aktifscene aktif

	}

	public void aktifpopupgagal(){
		suarapopupgagal ();
		gameOver = !gameOver;
		popupGagal.SetActive (gameOver);
	}//mengaktifkan popupp gagal 
	public void kemenu(){
		komponenPaused.kemenu (); //mengambil fungsi kembali kemenu dari paused
	}
	public void keluargame(){
		komponenPaused.keluargame (); //mengambil fungsi keluar dari paused
	}
	public void restart(){
		komponenPaused.klikbutton (); //mengambil fungsi suara klik
		Application.LoadLevel (restartLevel);
	}
	public void suarapopupgagal(){
		AudioSource playSuara = suara.GetComponent<AudioSource>(); //mengambil komponen audiosource
		playSuara.Play ();
	}
}
