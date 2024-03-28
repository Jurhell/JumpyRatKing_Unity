using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _pickupEffect;
    private PlayerTagBehavior _playerTagBehavior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Pickup(other);
    }

    void Pickup(Collider player)
    {
        Instantiate(_pickupEffect, transform.position, transform.rotation);

        _playerTagBehavior = player.GetComponent<PlayerTagBehavior>();

        _playerTagBehavior.Tag();

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0f, -1f, 0f, Space.Self);
    }
}
