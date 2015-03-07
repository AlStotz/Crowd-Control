using UnityEngine;
using System.Collections;

public class BulletProperties : MonoBehaviour {
	
	public int TravelSpeed = 100;
	public float LifeTime = 600;
	public float Damage = 25;
	
	private int timer = 0;
	
	// Use this for initialization
	void Start ()
	{
		//rigidbody.detectCollisions = false;
		GetComponent<Rigidbody>().AddForce((transform.up) * TravelSpeed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer++;
		if(timer >= LifeTime)
			ApplyDestroy();
	}
	
	void ApplyDestroy()
	{
		Destroy (this.gameObject);
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "")
		{
			collision.gameObject.SendMessage("OnHit", Damage);
			ApplyDestroy ();
		}
	}
	
	
}
