using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour {
    public GameObject PlayerRoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(PlayerRoot.GetComponent<Renderer>().enabled == true)
        {
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
	}
}
