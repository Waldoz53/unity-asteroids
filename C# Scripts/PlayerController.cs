using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int rotation;

    public AudioClip crash;
    public AudioClip shoot;

    private Rigidbody2D rb2d;
    private Animator animator;
    public GameObject bullet;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, rotation));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -rotation));
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(transform.up * speed);
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);

        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            AudioSource.PlayClipAtPoint(crash, Camera.main.transform.position);

            transform.position = new Vector3(0, 0, 0);

            rb2d.velocity = new Vector3(0, 0, 0);

            gameController.decrementLives();
        }
    }
}
