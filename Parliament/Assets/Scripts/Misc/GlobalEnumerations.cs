public enum KeyState : int 
{
	Pressed = 0, 
	Released = 1, 
	Held = 2
}

public enum PlayerMoveDirection : int 
{ 
	None = 0, 
	Forward = 1, 
	Back = -1 
} 
public enum PlayerStrafeDirection : int 
{ 
	None = 0, 
	Right = 1, 
	Left = -1 
}
public enum RateOfFire : int
{
	Single = 0,
	Burst = 1,
	Auto = 2
}