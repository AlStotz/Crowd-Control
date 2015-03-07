using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Cursor : MonoBehaviour 
{
	private const float PLAYER_HEIGHT = 2;
	private static Vector3 globalMousePos;

	// Use this for initialization
	void Start () 
    {
		UnityEngine.Cursor.visible = false;

        //Messenger.AddListener("GetMousePosition", GetMousePosition);
	}

	// Update is called once per frame
	void Update () 
	{
        Vector3 pZero = new Vector3(0, PLAYER_HEIGHT, 0);
		// Get Global Mouse Coordinates rlative to (0,0,0)
        Plane zeroPlane = new Plane(Vector3.up, pZero);
    	Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition);
		float distance;
		
		if( zeroPlane.Raycast( ray, out distance ) )
		{
            globalMousePos = ray.origin + ray.direction * distance;
		}

        //globalMousePos.y += PLAYER_HEIGHT;
		
		// Set the Cursor to the mouse position
        transform.position = new Vector3(globalMousePos.x, transform.position.y, globalMousePos.z);
	}
	
	public static Vector3 GetGlobalMouseLocation()
	{
        return globalMousePos;
	}

    public static Vector3 GetLocalMouseLocationRelativeTo(Vector3 Obj)
    {
        Vector3 localMousePos = Obj;

        Obj.x += globalMousePos.x;
        Obj.z += globalMousePos.z;

        return (Obj);
    }
}
