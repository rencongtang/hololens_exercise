using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManager : MonoBehaviour {

    public 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("u"))
        {
            this.BroadcastMessage("ShowBody");
        }
        else
        if (Input.GetKeyDown("i"))
        {
            this.BroadcastMessage("ShowBone");
            
        }
        else
            if (Input.GetKeyDown("p"))
        {
            this.BroadcastMessage("ShowOrgan");
            
        }
        else
            if (Input.GetKeyDown("r"))
        {
            this.BroadcastMessage("Amplify");
        }
        else
            if (Input.GetKeyDown("t"))
        {
            this.BroadcastMessage("Shrink");
        }
        else
            if (Input.GetKeyDown("b"))
        {
            this.BroadcastMessage("Back");
        }
        else
            if (Input.GetKeyDown("x"))
        {
            this.BroadcastMessage("Focus");
        }
        else
            if (Input.GetKeyDown("c"))
        {
            this.BroadcastMessage("FocusBack");
        }
		else
			if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			this.BroadcastMessage("OneClick");
		}
		else
		    if (Input.GetKeyDown(KeyCode.Backspace))
		{
			this.BroadcastMessage("AllBack");
		}								
    }
}
