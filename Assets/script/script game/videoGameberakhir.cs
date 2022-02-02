using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement; //preferences untuk menggunakan scane manager
public class videoGameberakhir : MonoBehaviour {
	public RawImage rawImage;//untuk rawimage
	public VideoPlayer videoPlayer;//untuk videonya

	// Use this for initialization
	void Start () {
		StartCoroutine (playervideo());//menjakan video 
		videoPlayer.loopPointReached += EndReached;//selsai video
	}
	void EndReached(UnityEngine.Video.VideoPlayer vp){
		Scene Sceneaktif = SceneManager.GetActiveScene();
		if(Sceneaktif.name != "S_menu_utama"){
			SceneManager.LoadScene ("S_menu_utama");
		}
	}// untuk video selesai pindah scene

	IEnumerator playervideo (){
		videoPlayer.Prepare ();
		WaitForSeconds tunggu = new WaitForSeconds (1);
		while(!videoPlayer.isPrepared){
			yield return tunggu;
			break;
		}
		rawImage.texture = videoPlayer.texture;
		videoPlayer.Play ();
	}//memutar video dengan jeda
	public void kemenu(){
		//untuk  mengecek scene yg aktif

		Scene Sceneaktif = SceneManager.GetActiveScene();
		if(Sceneaktif.name != "S_menu_utama"){
			SceneManager.LoadScene ("S_menu_utama");
		}

	}
}
