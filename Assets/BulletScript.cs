using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject effect;

    void Start()
    {
        Destroy(gameObject, 10);
        GetComponent<Rigidbody>().AddForce(transform.forward * 15000);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().TakeDamage();
            Instantiate(effect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}