using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Vector2 jumpForce = new Vector2(0, 300);
    Rigidbody2D rg;
    AudioSource saw;
    Animator animator;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = transform.GetComponentInChildren<Animator>();
        saw = GameObject.FindObjectOfType<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("space"))
        {
            rg.velocity = Vector2.zero;
            rg.AddForce(jumpForce);
        }
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Die();
    }

    void Die()
    {
        saw.Play();
        animator.SetTrigger("smierc");
        GetComponent<Rigidbody2D>().MoveRotation(180);
    }
}
