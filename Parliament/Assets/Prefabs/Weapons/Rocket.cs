using UnityEngine;
using System.Collections;
using UnityEditor;

public class Rocket : MonoBehaviour {

    public float RocketSpeed = 5.0f;
    private Rigidbody rb;
    private Vector3 Direction;

    public ParticleSystem psystem;

	// Use this for initialization
	void Start ()
	{
	    Direction = Cursor.GetGlobalMouseLocation();
	    rb = GetComponent<Rigidbody>();

        psystem.Emit(this.transform.position, this.transform.forward, 1.0f, 10.0f, Color32.Lerp(Color.black, Color.red, 1.0f));
	    psystem.enableEmission = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    rb.AddForce(Direction * RocketSpeed);
	}

    public void AddMoreForce()
    {
        
    }
}
