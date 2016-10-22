using UnityEngine;
using System.Collections;

public class BeeMove : MonoBehaviour
{

    Vector3 velocity = Vector3.zero;
    float flapSpeed = 300f;
    float forwardSpeed = 0.5f;
    float maxSpeed = 2f;
    bool Flap = false;
    bool dead = false;
    bool dzwiek = false;
    AudioSource saw;
    float delay = 0;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        saw = GameObject.FindObjectOfType<AudioSource>();

    }


    /// Grafika 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap = true;

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
    }


    // Fizyka
    void FixedUpdate()
    {
        if (dead == false)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

            if (GetComponent<Rigidbody2D>().velocity.x > maxSpeed)

            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Flap)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
                Flap = false;
            }

            if (GetComponent<Rigidbody2D>().velocity.y >= 0.25)
            {
                transform.rotation = Quaternion.Euler(0, 0, 1);
            }
            else
            {
                float angle = Mathf.Lerp(0, -30, -GetComponent<Rigidbody2D>().velocity.y / 2f);
                transform.rotation = Quaternion.Euler(0, 0, angle);

            }
        }
        else
        {
            Debug.Log("dasdaA");
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);





        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (dzwiek == false)
        {
            saw.Play();
            dzwiek = true;
        }
        animator.SetTrigger("smierc");
        Debug.Log("AAAAAAAAAAAA");
        dead = true;
        if (coll.gameObject.tag == "ziemia" || coll.gameObject.tag == "miodekdol")
        {
            GetComponent<Rigidbody2D>().MoveRotation(180);
        }
    }
}
