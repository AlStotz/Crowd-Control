using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	private float default_ZoomLevel = 25;
	private float default_MinZoom = 10;
	private float default_MaxZoom = 50;
	
	public GameObject Player;
	public float ZoomLevel;
	public float MinZoomLevel;
	public float MaxZoomLevel;
	
	// Use this for initialization
	void Start ()
	{
		//Messengers
		Messenger<float>.AddListener("SetZoom", SetZoom);

		ZoomLevel = this.ZoomLevel;
		MinZoomLevel = this.default_MinZoom;
		MaxZoomLevel = this.default_MaxZoom;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);
		this.transform.position = new Vector3(Player.transform.position.x, ZoomLevel, Player.transform.position.z);
	}

	private void SetZoom(float zoom)
	{
		ZoomLevel += zoom;
	}

}
