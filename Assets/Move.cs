using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Start()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    void Update()
    {
        transform.Translate(0, 0, 0.03f);
        //transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Wall North")
        {
            transform.eulerAngles = new Vector3(0, Random.Range(200f, 340f), 0);
        } else if (other.gameObject.name == "Wall East")
        {
            transform.eulerAngles = new Vector3(0, Random.Range(-70f, 70f), 0);
        } else if (other.gameObject.name == "Wall South")
        {
            transform.eulerAngles = new Vector3(0, Random.Range(20f, 160f), 0);
        } else if (other.gameObject.name == "Wall West")
        {
            transform.eulerAngles = new Vector3(0, Random.Range(110f, 250f), 0);
        }
    }

}
