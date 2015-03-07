using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	public GameObject OnScreenCursor;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckMouse();
	}
	
	private void CheckMouse()
	{
		this.transform.LookAt(OnScreenCursor.transform);
	}
}
