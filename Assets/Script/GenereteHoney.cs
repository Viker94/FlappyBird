using UnityEngine;
using System.Collections;

public class GenereteHoney : MonoBehaviour {

    public GameObject honey;
    GameObject instance;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateObstacle", 0.5F, 1.5F);
	}
	
	void CreateObstacle()
    {
        instance = (GameObject) Instantiate(honey);
        Destroy(instance, 10);
    }


}
