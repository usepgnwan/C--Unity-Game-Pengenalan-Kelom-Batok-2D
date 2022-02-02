using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //mengakses komponen scane
public class pilihLevel : MonoBehaviour {


	public string namaScanelevel; //memanggil nama scene menu
	public AudioSource suara;
	// Use this for initialization

	public void pilihlevel(){
		suaralevel ();
		Scene Sceneaktif = SceneManager.GetActiveScene();
		if(Sceneaktif.name != namaScanelevel){
			SceneManager.LoadScene (namaScanelevel);
		}
	}

	public void suaralevel(){
		AudioSource playSuara = suara.GetComponent<AudioSource> ();
		playSuara.PlayOneShot (playSuara.clip);
	}
}
