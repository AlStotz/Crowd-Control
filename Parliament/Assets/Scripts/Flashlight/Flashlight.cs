using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {
	
	public bool _isOn = false;
	
	// Use this for initialization
	void Start () 
	{
		GetComponent<Light>().enabled = _isOn;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckKeys();
	}
	
	void CheckKeys()
	{
		if(Input.GetKeyUp(KeyCode.L))
		{
			if(_isOn)
				_isOn = false;
			else
				_isOn = true;
			
			GetComponent<Light>().enabled = _isOn;
		}
	}
}
