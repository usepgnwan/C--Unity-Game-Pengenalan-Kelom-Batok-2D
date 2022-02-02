using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class unlockLevel : MonoBehaviour {
	public GameObject[] levelButton;

	// Use this for initialization
	void Start () {
		int levelAt = PlayerPrefs.GetInt ("aktifLevel", 2);
		for(int i=0; i<levelButton.Length; i++){
			if(i+2 > levelAt){
				levelButton [i].SetActive(false);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
