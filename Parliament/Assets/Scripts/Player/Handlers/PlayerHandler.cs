using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour 
{
	#region Fields

    private static Vector3 _position;
    private static Quaternion _rotation;
    private static float _direction;

	private string _name;
	private float _health;
	private float _maxHealth;
	
	#endregion Fields
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        _position = this.transform.position;
        _rotation = this.transform.rotation;
        _direction = this.transform.eulerAngles.y;
	}

    public static float GetPlayerDirection ()
    {
        return _direction;
    }

    public static Vector3 GetPlayerPosition()
    {
        return _position;
    }

    public static Quaternion GetPlayerRotation()
    {
        return _rotation;
    }
}
