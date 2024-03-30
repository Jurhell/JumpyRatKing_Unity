using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrownBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _pickupEffect;
    [SerializeField]
    private TextMeshProUGUI _objectiveText;

    private PlayerTagBehavior _playerTagBehavior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Pickup(other);
    }

    void Pickup(Collider player)
    {
        Instantiate(_pickupEffect, transform.position, transform.rotation);

        //Getting player tag behavior
        _playerTagBehavior = player.GetComponent<PlayerTagBehavior>();

        //Tagging the player
        _playerTagBehavior.Tag();

        //Disabling the text
        _objectiveText.enabled = !enabled;

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0f, -1f, 0f, Space.Self);
    }
}
