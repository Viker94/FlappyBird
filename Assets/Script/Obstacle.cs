using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    // Use this for initialization

    public Vector2 velocity = new Vector2(-4, 0);
    public float range = 0.5F;
    bool wasVisible = false;

	void Start () {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.velocity = velocity;
        float random = transform.position.y - range * Random.value;
        while (random < -1)
        {
            random = transform.position.y - range * Random.value;
        }
        transform.position = new Vector3(transform.position.x, random, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
