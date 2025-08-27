using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    public float Damage = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
