using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour 
{	

	public float _ZoomSensitivity = 1;

	#region Fields

	private static InputManager _instance;		//cached instance of manaager
	private GameObject _gameObj;				//cached gameObject

	#endregion Fields
	
	#region Properties	
		
	public static InputManager Instance
	{
		get { return _instance;	}
	}
	
	public GameObject GameObj
	{
		get { return _instance._gameObj; }
	}
	
	#endregion Properties
	
	#region MonoBehaviour
	private void Awake()
	{
		_instance = this;
		this._gameObj = this.gameObject;		
	}
	
	private void Update()
	{
		this.CheckMovementInput();
        this.CheckActionInput();
	    this.CheckOtherInput(); // Used for everything else (IE: Menu and such)
	}
	#endregion MonoBehaviour
	
	#region Private Methods
	private void CheckMovementInput()
	{
		// Check Sprint
		if(Input.GetKey(KeyCode.LeftShift))
			Messenger<bool>.Broadcast("PlayerSprint", true, MessengerMode.DONT_REQUIRE_LISTENER);	
		else
			Messenger<bool>.Broadcast("PlayerSprint", false, MessengerMode.DONT_REQUIRE_LISTENER);
		
		// Check Movement
		if(Input.GetKey(KeyCode.W))
			Messenger<PlayerMoveDirection>.Broadcast("MovePlayerDirection", PlayerMoveDirection.Forward, MessengerMode.DONT_REQUIRE_LISTENER);
		else if (Input.GetKey (KeyCode.S))
			Messenger<PlayerMoveDirection>.Broadcast("MovePlayerDirection", PlayerMoveDirection.Back, MessengerMode.DONT_REQUIRE_LISTENER);
		else
			Messenger<PlayerMoveDirection>.Broadcast("MovePlayerDirection", PlayerMoveDirection.None, MessengerMode.DONT_REQUIRE_LISTENER);
		
		// Check Strafe
		if(Input.GetKey(KeyCode.A))
			Messenger<PlayerStrafeDirection>.Broadcast("StrafePlayerDirection", PlayerStrafeDirection.Left, MessengerMode.DONT_REQUIRE_LISTENER);
		else if (Input.GetKey (KeyCode.D))
			Messenger<PlayerStrafeDirection>.Broadcast("StrafePlayerDirection", PlayerStrafeDirection.Right, MessengerMode.DONT_REQUIRE_LISTENER);
		else
			Messenger<PlayerStrafeDirection>.Broadcast("StrafePlayerDirection", PlayerStrafeDirection.None, MessengerMode.DONT_REQUIRE_LISTENER);		
	}
	
	private void CheckActionInput()
	{
        // Messenger.Broadcast("CancelCook", MessengerMode.DONT_REQUIRE_LISTENER);
        if (Input.GetKey(KeyCode.R)) // Action: Weapon Reload or Cancel Grenade
        {
            if (Input.GetMouseButton(1))
                Messenger.Broadcast("CancelCook", MessengerMode.DONT_REQUIRE_LISTENER);
            else
                Messenger.Broadcast("WeaponReload", MessengerMode.DONT_REQUIRE_LISTENER);
        }

        if (Input.GetMouseButtonDown(0)) // Action: Weapon Fire
			Messenger.Broadcast("WeaponStartFire", MessengerMode.DONT_REQUIRE_LISTENER);
		if (Input.GetMouseButtonUp(0)) // Stop Firing
			Messenger.Broadcast("WeaponStopFire", MessengerMode.DONT_REQUIRE_LISTENER);
		
		if(Input.GetMouseButtonDown(1)) // Action: Cook Nade Throw
			Messenger.Broadcast("NadeCook", MessengerMode.DONT_REQUIRE_LISTENER);
		if (Input.GetMouseButtonUp(1)) // Stop Cooking
			Messenger.Broadcast("NadeThrow", MessengerMode.DONT_REQUIRE_LISTENER);

		// Check for mouse scrool (zoom)
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
			Messenger<float>.Broadcast("SetZoom", _ZoomSensitivity);
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
			Messenger<float>.Broadcast("SetZoom", -_ZoomSensitivity);

        // Check for rate of fire change
	    if (Input.GetKeyUp(KeyCode.F))
	    {
	        Messenger.Broadcast("ChangeRateOfFire", MessengerMode.DONT_REQUIRE_LISTENER);
	    }
	}

    private void CheckOtherInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Messenger.Broadcast("ToggleMenu",MessengerMode.DONT_REQUIRE_LISTENER);
        }
    }

	#endregion Private Methods
	
	#region Public Methods

	#endregion Public Methods
	
	
	
}