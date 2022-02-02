using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //preferences untuk menggunakan scane manager

public class paused : MonoBehaviour {

	public GameObject popupPaused; //mengambil panel
	private bool aktifPaused = false; // mengaktifkan panel
	public string namaScene; //memanggil nama scene menu
	public AudioSource suaraButton;
	public int restartLevel;//mengambil scane 

	// Use this for initialization
	void Start(){
		restartLevel = SceneManager.GetActiveScene ().buildIndex;
	}
	public void aktifkanpopup () {
		klikbutton ();
		aktifPaused = !aktifPaused;
		popupPaused.SetActive (aktifPaused);
	}
// Update is called once per frame
	void Update () {
		if(aktifPaused){
			popupPaused.SetActive (true);
			Time.timeScale = 0;
		}	
		if(!aktifPaused){
			popupPaused.SetActive (false);
			Time.timeScale = 1;
		}
	}
	public void resume(){
		klikbutton ();
		aktifPaused = false;
	}
	public void kemenu(){
		//untuk  mengecek scene yg aktif
		klikbutton();
		Scene Sceneaktif = SceneManager.GetActiveScene();
		if(Sceneaktif.name != namaScene){
			SceneManager.LoadScene (namaScene);
		}

	} // untuk kembali ke menu

	public void keluargame(){
		klikbutton();
		Application.Quit ();

	}
	public void restart(){
		klikbutton ();
		Application.LoadLevel (restartLevel);
	}
	public void klikbutton(){
		AudioSource suara = suaraButton.GetComponent<AudioSource> ();
		suara.PlayOneShot (suara.clip);
	}
}
