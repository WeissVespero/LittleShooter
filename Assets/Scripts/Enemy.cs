using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float Health = 50f;
    public float DamageLevel = 10f;

    private Transform _player;

    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }

    void Update()
    {
        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, MoveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("collision");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(DamageLevel);
            Destroy(gameObject);
        }
    }
}
