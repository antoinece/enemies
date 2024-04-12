using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private Rigidbody2D rbe;

    private float force = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 positionPlayer = player.transform.position;
        Vector3 positionBullet = rbe.transform.position;
        Vector3 direction = positionPlayer - positionBullet;
        rbe.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+90);
    } 
    

    // Update is called once per frame
    void Update()
    {
        //rbe.velocityY = 2;
    }
}
