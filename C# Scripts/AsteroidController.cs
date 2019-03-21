using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject smallAsteroid;

    public AudioClip destroyed;

    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();

        GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-50f, 150f));

        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(0f, 90f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(destroyed, Camera.main.transform.position);

            Destroy(collision.gameObject);

            if (gameObject.tag == "Large Asteroid")
            {
                Instantiate(smallAsteroid, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 90));

                Instantiate(smallAsteroid, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

                Instantiate(smallAsteroid, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 270));

                gameController.splitAsteroids();
            }
            else
            {
                gameController.decrementAsteroids();
            }

            gameController.incrementScore();

            Destroy(gameObject);
        }
    }
}
