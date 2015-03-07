using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	#region Fields	
	private PlayerMoveDirection _moveDirection = PlayerMoveDirection.None;
	private PlayerStrafeDirection _strafeDirection = PlayerStrafeDirection.None;
	
	public float walkSpeed = 30.00f;
	public float strafeSpeedModifier = 10.00f;
	public float sprintSpeedModifier = 17.50f;
	
	private bool _isSprinting;
	private float _movementSpeed;
	
	
	private bool _isInputAllowed = true;
	#endregion Fields
	
	#region Properties

	#endregion Properties
	
	
	#region MonoBehaviour
	private void Awake()
	{
		Debug.Log("Mornin'");
	}
	// Use this for initialization
	private void Start ()
	{
		Messenger<bool>.AddListener("PlayerSprint", SetSprinting);
		Messenger<PlayerMoveDirection>.AddListener("MovePlayerDirection", SetMoveDirection );
		Messenger<PlayerStrafeDirection>.AddListener("StrafePlayerDirection", SetStrafeDirection );
	}
	
	// Update is called once per frame
	private void Update ()
	{
		MovePlayer();
	}
	#endregion MonoBehaviour
	
	#region Private Methods
	private void SetSprinting(bool isSprinting)
	{
		this._isSprinting = isSprinting;
	}
	private void SetMoveDirection(PlayerMoveDirection moveDirection)
	{
		this._moveDirection = moveDirection;
	}
	
	private void SetStrafeDirection(PlayerStrafeDirection strafeDirection)
	{
		this._strafeDirection = strafeDirection;	
	}
	
	private void MovePlayer()
	{
		var strafeSpeed = 0.0f;
			
		if(_isSprinting)			
			this._movementSpeed = walkSpeed * sprintSpeedModifier;
		else
			this._movementSpeed = walkSpeed;	
		
		strafeSpeed = _movementSpeed * strafeSpeedModifier;
			
		var moveDirection = (int)_moveDirection  * _movementSpeed  * Time.deltaTime;
		var strafeDirection = (int)_strafeDirection * strafeSpeed * Time.deltaTime;
			
		this.transform.Translate(new Vector3(strafeDirection, 0, moveDirection));			// Move the Player in the direction they're supposed to go in
	}
	#endregion Private Methods
	
	
}
