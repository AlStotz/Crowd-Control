using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBelt : MonoBehaviour
{	
	public List<Transform> throwablePrefabs;
	
	public List<int> maxThrowableObject;   			//Max amount of objects that can be held/thrown by player
	public List<int> currentThrowableObject;				//How many of each type available to be thrown
	
	
	#region MonoBehaviour	
	private void Awake()
	{
	}	
	#endregion MonoBehaviour

}



public enum ThrowableType : int { Grenade, Knife }
