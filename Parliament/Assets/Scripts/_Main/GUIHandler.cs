using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour
{
    public bool gui_ShowMenu = false;

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
	    Messenger.AddListener("ToggleMenu", ToggleMenu);
    }

    private void ToggleMenu()
    {
        Debug.Log("Toggle Menu Hit");

        if (gui_ShowMenu == false)
        {
            gui_ShowMenu = true;
            Debug.Log("Opening Menu");
        }
        else
        {
            gui_ShowMenu = false;
            Debug.Log("Closing Menu");
        }
    }

    // Update is called once per frame
	void Update ()
    {
	    
	}


    // GUI Override
    void OnGUI()
    {
        if (gui_ShowMenu)
        {
            GUILayout.BeginArea(new Rect(10, 10, 100, 300));

            //GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();

            //GUILayout.Label("Player Position: " + Player.transform.position.normalized);
            //GUILayout.Label("Player Rotation: " + Mathf.RoundToInt(Player.transform.rotation.eulerAngles.x) + ", " + Mathf.RoundToInt(Player.transform.rotation.eulerAngles.y) + ", " + Mathf.RoundToInt(Player.transform.rotation.eulerAngles.z));

            GUILayout.EndVertical();

            GUILayout.EndArea();
        }
    }
}