using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirection : MonoBehaviour {
    public Transform CameraPivot;
    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Transform>().position = Player.position;

        if (Player.gameObject.GetComponent<PlayerMovement>().Moving == false)
        {
            gameObject.GetComponent<Transform>().rotation = CameraPivot.rotation;
        }
    }
}
