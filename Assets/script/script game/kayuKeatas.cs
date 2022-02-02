using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kayuKeatas : MonoBehaviour {
	public bool moveUp;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (moveUp) {
			transform.Translate (0,2 * Time.deltaTime * speed,0); // membuat musuh bergerak kekanan

		} else {
			transform.Translate (0,-2 * Time.deltaTime * speed,0); // // membuat musuh bergerak kekiri

		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "batas"){

			if (moveUp) {
				moveUp = false;

			} else {
				moveUp = true;

			}
		} //batas musuhh gerak
	}
}
