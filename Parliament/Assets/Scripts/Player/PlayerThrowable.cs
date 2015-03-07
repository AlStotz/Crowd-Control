using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerThrowable
	: MonoBehaviour 
{
	#region Fields
	[SerializeField]
	private PlayerBelt _playerBelt;		
	public List<Transform> thrownObjects;
	
	[SerializeField]
	private bool _isCooking = false;					//bool tracking the holding of the player throwing an object
	[SerializeField]
	private bool _isReloading = false;					//bool to track if player is reloading another throwable item
	[SerializeField]
	private float _maxReloadTimer = 0.5f;				//max time it takes to reload a thrown weapon
	[SerializeField]
	private float _currentReloadTimer = 0.0f;			//current timer of reloading
	[SerializeField]
	private float _maxCookTimer = 5.0f;					//max time player is allowed to hold back thrown object
	[SerializeField]
	private float _currentCookTimer = 0.0f;				//current timer for holding back throwable object
	#endregion Fields
	
	#region MonoBehaviour
	private void Awake()
	{
		//this.thrownObject = new List<Transform>();
	}
	#endregion MonoBehaviour
	
	#region Private Methods
	private void CheckTimers()
	{
		if(_isCooking && (_currentCookTimer < (_maxCookTimer * 60)))
		{
			UpdateCook();
		}
		
		else if(_isReloading && (_currentReloadTimer < (_maxReloadTimer * 60)))
		{
			_currentReloadTimer++;
			if(_currentReloadTimer == (_maxReloadTimer * 60))
			{
				EndReload();
			}
		}
		else
		{
			_currentReloadTimer = 0.0f;
			_currentCookTimer = 0.0f;
			_isReloading = false;
			_isCooking = false;
		}
	}
	
	private void StartReload()
	{
		_isReloading = true;
	}
	
	private void EndReload()
	{
		_isReloading = false;
	}
	
	private void StartCook()
	{
		_isCooking = true;
		//Instantiate(Indicator, transform.parent.transform.position, transform.parent.transform.rotation);
	}
	
	private void UpdateCook()
	{
		_currentCookTimer++;
		if(_currentCookTimer == (_maxCookTimer * 60)) // Max Cook, Force Throw
		{
			EndCook();
		}
	}
	
	private void EndCook()
	{
		Throw();
	}
	
	private void Throw()
	{
		_isCooking = false;
		//_throwableCount--;
		StartReload();
	}
	#endregion Private Methods	
	
	#region Public Methods
	#endregion Public Methods
}
