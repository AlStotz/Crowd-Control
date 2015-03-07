using UnityEngine;
using System.Collections;

public class NadeHandler : MonoBehaviour
{
	#region Fields

    private bool _showGUI = false;

	private const float MAX_COOK = 5; // Max amount of seconds player can cook Nade
	private const float TIMER_MODIFIER = 60;
	private const float DISTANCE_MODIFIER = 10; // Modifies the distance
	
	public Grenade _primaryNade; // private NadeProperties _primaryNade
	
	private bool _isThrowing = false;
	private float _throwTimer = 0.0f;
	private bool _isCooking = false;
	private float _cookTimer = 0.0f;
	
	private float _throwDistance;
	
	#endregion Fields
	
	// Use this for initialization
	void Start ()
	{

        _primaryNade = new Grenade(); // For Testing

		Messenger.AddListener("NadeCook", StartCook);
		Messenger.AddListener("NadeThrow", StartThrow);
        Messenger.AddListener("CancelCook", CancelCook);
	}
	
	// Update is called once per frame
	void Update ()
	{
        CheckCookTimer();
		CheckThrowTimer();
	}
	
	#region Private Methods
	private void StartCook()
	{
		if(!_isThrowing)
		{
			_isCooking = _primaryNade.CheckThrow();
		}
	}
	
	private void StartThrow()
	{
        Debug.Log("Start Throw!");
        if (_isCooking)
        {
            _isThrowing = true;
            _isCooking = false;
            _throwDistance = (_cookTimer * DISTANCE_MODIFIER); // Grab the throw distance, given how long the Nade was cooked
            _cookTimer = 0.0f; // Reset the cook timer
        }
	}

    private void CancelCook()
    {
        if (_isCooking)
        {
            _isCooking = false;
            _cookTimer = 0.0f;
        }
    }
	
	private void CheckCookTimer()
	{
		if(_isCooking)
		{
			if(_cookTimer < (MAX_COOK * TIMER_MODIFIER))
			{
				_cookTimer++;
			}
			else
			{
				StartThrow();
			}
		}
	}
	private void CheckThrowTimer() // Checks the timer for the Nade's Throw
	{
		if(_isThrowing) // Check to see if the Nade is currently being Thrown
		{
			if(_throwTimer < (_primaryNade.GetThrowSpeed() * TIMER_MODIFIER)) // Check to see if the Nade is still throwing
			{
				_throwTimer++;
			}
			else // Nade is done throwing
			{
				_isThrowing = false;
				_throwTimer = 0.0f;
				_primaryNade.Throw();
			}
		}
	}	
	#endregion Private Methods

    #region GUI

    void ToggleGUI(bool b)
    {
        
    }

    void OnGUI()
    {

        string str = "";

        str += "Grenades: " + _primaryNade.GetNadeCount() + "\n\n";

        if (_isCooking)
            str += "Cooking: " + _cookTimer + " | " + MAX_COOK * TIMER_MODIFIER + "\n";
        else
            str += "\n";
        if (_isThrowing)
            str += "Throwing: " + _throwTimer + " | " + _primaryNade.GetThrowSpeed() * TIMER_MODIFIER + "\n";
        else
            str += "\n";

        GUI.Box(new Rect(5, 5, 150, 100), str);

    }

    #endregion GUI
}
