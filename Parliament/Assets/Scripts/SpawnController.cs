using UnityEngine;
using System.Collections;
using System.Linq;

public class SpawnController : MonoBehaviour
{

    private GameObject Player;
    public GameObject Enemy;

    public int MaxEnemies = 20;

    public GameObject[] Spawners;
    public float spawnTimer = 120;
    private float spawnCounter = 0;

	// Use this for initialization
	void Start ()
	{
	    Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.position = Player.transform.position;

	    SpawnEnemies();
	}

    private void SpawnEnemies()
    {
        if (spawnCounter >= spawnTimer)
        {
            foreach (GameObject spawner in Spawners)
            {
                GameObject z = Instantiate(Enemy, spawner.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
            }

            spawnCounter = 0;
        }
        else
        {
            spawnCounter++;
        }
    }

    void OnGUI()
    {
        string str = "";
        string debugStr = "";

        debugStr += "Enemies: " + GameObject.FindGameObjectsWithTag("Enemy").Count().ToString() + "/" +
                    MaxEnemies.ToString() + "\n\n";

        GUI.Box(new Rect(Screen.width - (Screen.width - 155), 5, 150, 300), debugStr);

    }
}
