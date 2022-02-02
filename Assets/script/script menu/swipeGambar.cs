using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipeGambar : MonoBehaviour {
	public GameObject scrollbar; //mengambil objek scroll bar
	float scrollPos = 0;
	float [] pos; //menyimpan posisi dari swipe gambar slide
	int posisi = 0;
	// Use this for initialization

	public void next(){
		if(posisi<pos.Length-1){
			posisi += 1;
			scrollPos = pos [posisi];
		}
	}
	public void prev(){
		if(posisi>0){
			posisi -= 1;
			scrollPos = pos [posisi];
		}
	}
	// Update is called once per frame
	void Update () {
		pos = new float[transform.childCount];
		float jarak = 1f/(pos.Length - 1); //jarak antar objek
		for(int i=0; i<pos.Length; i++){
			pos [i] = jarak * i; //menympan jarak antar objek
		}

		if(Input.GetMouseButton(0)){
			scrollPos = scrollbar.GetComponent<Scrollbar> ().value; //mengambil objek scrollbar
		}else{
			for(int i=0; i<pos.Length; i++){
				if(scrollPos<pos[i]+(jarak/2) && scrollPos>pos[i]-(jarak/2)){
					scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (scrollbar.GetComponent<Scrollbar>().value,pos[i],0.15f);
					posisi = i;//agar posisi swipe update
				}
			}
		}//fungsi untuk drag objek

	}
}
