using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contol : MonoBehaviour {


	public GameObject[] humanbody;
	// Use this for initialization
	void Start () {
		// if (humanbody == null) {
			humanbody = GameObject.FindGameObjectsWithTag("BODY");
			Debug.Log(humanbody.ToString());
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
