using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Vector2 jumpForce = new Vector2(0, 300);
    Rigidbody2D rg;
    AudioSource saw;
    Animation animator;
    public static int score = 0;
    public Sprite deathSprite;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animation>();
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
            StartCoroutine(Die());
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(Die());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        score++;
    }

    IEnumerator Die()
    {
        saw.Play();
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        GetComponent<Animator>().Stop();
        GetComponent<Rigidbody2D>().MoveRotation(180);
        yield return new WaitForSeconds(0.25f);
        EndGame.zgon = true;
        Time.timeScale = 0;
    }
}
