using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [HideInInspector]
    public Controller controller;    

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void LateUpdate () {
        //if (controller != null)
        //{
        //    this.transform.position = controller.transform.position;
        //    this.transform.rotation = controller.transform.rotation;
        //}
		
	}
}
