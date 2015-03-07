using UnityEngine;
using System.Collections;

public class IndicatorProperties : MonoBehaviour
{	
	private Vector3 MousePos;
	
	public GameObject Player;
	public GameObject cCursor;
	
	public float Speed = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		//transform.position = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//UpdateMousePos();
		UpdatePosition();
		CheckMouse();
	}
	
	void UpdatePosition()
	{
		//transform.position = Player.transform.position;
		//gameObject.transform.rotation = Player.transform.rotation;
		//transform.Rotate(Vector3.up, Player.transform.rotation.y);
	}
	
	void CheckMouse()
	{
		if(Input.GetMouseButtonUp(1))
		{
			ApplyDestroy();
		}
	}
	
	public void ApplyDestroy()
	{
		Destroy(this.gameObject);
	}
	
	void OnGUI()
	{
		string str1 = "";
		
		str1 += "Player.transform.rotation.y: " + Player.transform.rotation.y.ToString();
		
		GUI.Box(new Rect(5, 260, 250, 250), str1);
	}
}
