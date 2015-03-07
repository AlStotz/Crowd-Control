using UnityEngine;
using System.Collections;

public class Grenade : NadeProperties
{
    #region Fields
    private string _name; // Name of the Nade
    private string _description; // Description of the Nade
    private string _hudImage = "/Stock/Throwable/Grenade.png";

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

    public Grenade()
    {
        #region Temp

        _name = "Grenade";
        _description = "Default Hand Grenade";
        _throwSpeed = 1;
        _nadeCount = 5;
        _nadeMax = 5;
        _maxNadeDamage = 1;
        _maxNadeDamageRadious = 10;
        _minNadeDamage = 1;
        _minNadeDamageRadious = 5;

        #endregion Temp
    }

    #region Private Methods



    #endregion Private Methods

    #region Public Methods
    public bool CheckThrow() // Check to see if there are nades to throw
    {
        if (_nadeCount > 0)
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
