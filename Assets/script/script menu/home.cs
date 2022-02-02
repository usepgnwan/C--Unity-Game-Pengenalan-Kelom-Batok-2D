using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour {
	public GameObject panelAwal;   //panel yang sedang aktif
	public GameObject panelTujuan;	//panel tujuan
	public AudioSource suaraButton; //audio klik
	// Use this for initialization
	public void pindah(){
		klikbutton ();
		panelAwal.SetActive (false);
		panelTujuan.SetActive (true);
	}
	public void keluargame(){
		klikbutton ();
		Application.Quit ();
	}
	public void klikbutton(){
		AudioSource suara = suaraButton.GetComponent<AudioSource> ();
		suara.PlayOneShot (suara.clip);
	}
}
