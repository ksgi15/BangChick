using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LiveObject : MonoBehaviour {

	public bool _isFilled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_isFilled) {
			gameObject.GetComponent<Image> ().color = Color.red;
		} else {
			gameObject.GetComponent<Image> ().color = Color.white;
		}
	}
}
