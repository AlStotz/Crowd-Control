using UnityEngine;
using System.Collections;

public class EnemyMovement : Entity
{
    private GameObject player;
    public float RunSpeed = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PlayerSpotted();
    }

    private void PlayerSpotted()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);

        //look at player
        this.transform.LookAt(playerPos);

        //move towards player
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, RunSpeed * Time.deltaTime);
    }

    public override void Die()
    {
        Debug.Log("DEDZ");
        //player.AddExperience(expOnDeath);
        base.Die();
    }
}
