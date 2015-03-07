using UnityEngine;
using System.Collections;

public class NadeProperties
{	
	#region Fields
	private string _name; // Name of the Nade
	private string _description; // Description of the Nade
    private Texture2D _hudImage;
	
	private float _throwSpeed; // Throws per Second
	
	private int _nadeCount; // Current amount of Nades
	private int _nadeMax; // Maximum amount of Nades
	
	private float _maxNadeDamage; // Minimum Damage dealt
	private float _maxNadeDamageRadious; // Radious of the Max Damage (Meters)
	private float _minNadeDamage; // Maximum Damage dealt
	private float _minNadeDamageRadious; // Radious of the Min Damage (Meters)
	
	#endregion Fields
	
	#region Properties
	#endregion Properties
	
	public NadeProperties()
	{

	}
	
	#region Private Methods
	
	
	
	#endregion Private Methods
	
	#region Public Methods	
	public bool CheckThrow() // Check to see if there are nades to throw
	{
		if(_nadeCount > 0)
			return true;
		else
			return false;
	}
	public void Throw()
	{
		_nadeCount -= 1;
	}
	
	public float GetThrowSpeed() { return this._throwSpeed; }
    public int GetNadeCount() { return _nadeCount; }
	
	
	#endregion Public Methods
	
}
