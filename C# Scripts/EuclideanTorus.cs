using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 8.2)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.2)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.y > 4.2)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        else if (transform.position.y < -4.2)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
    }
}
