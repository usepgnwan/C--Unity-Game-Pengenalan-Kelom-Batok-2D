using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class load : MonoBehaviour {

	public Transform loadingBar;
	public string pindah;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;

	void Update(){
		if (currentAmount < 100) {
			currentAmount += speed * Time.deltaTime;
			Debug.Log ((int)currentAmount);
		} else {
		
			SceneManager.LoadScene (pindah);
		}
		loadingBar.GetComponent<Image> ().fillAmount = currentAmount / 100;
	}
}
