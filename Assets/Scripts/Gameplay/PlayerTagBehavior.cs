using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTagBehavior : MonoBehaviour
{
    [SerializeField]
    private bool _isTagged = false;

    [SerializeField]
    private ParticleSystem _taggedParticles;

    [SerializeField]
    private GameObject _crown;

    public UnityEvent OnTagged;

    private bool _canBeTagged = true;

    public bool IsTagged { get => _isTagged; }

    public bool Tag()
    {
        // If cannot be tagged, return false
        if (!_canBeTagged) return false;

        // Set that we're tagged
        _isTagged = true;
        _canBeTagged = false;

        //Activating the crown
        _crown.SetActive(true);

        // Turn our trail renderer on
        TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
        if (trailRenderer != null)
            trailRenderer.enabled = true;

        if (_taggedParticles != null)
        {
            _taggedParticles.enableEmission = true;
            _taggedParticles.Play();
        }

        OnTagged.Invoke();
        return true;
    }

    void SetCanBeTagged() => _canBeTagged = true;

    void Start()
    {
        OnTagged.AddListener(SetCanBeTagged);

        // Get my trail renderer
        TrailRenderer trail = GetComponent<TrailRenderer>();
        if (trail == null) { return; }

        // If I am tagged, then turn trail on, otherwise off
        if (IsTagged)
            trail.enabled = true;
        else
            trail.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // If we are not it, do nothing
        if (!IsTagged) return;

        // Attempt to get the PlayerTagBehavior from what we hit
        PlayerTagBehavior tagBehavior = collision.gameObject.GetComponent<PlayerTagBehavior>();

        // If it didn't have one, return
        if (tagBehavior == null) return;

        // Tag the other player
        if (!tagBehavior.Tag()) return;

        // Set ourselves as not it
        _isTagged = false;
        _canBeTagged = false;

        //Making sure player crown is not active
        _crown.SetActive(false);

        // Turn off our tail renderer
        TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
        if (trailRenderer != null)
            trailRenderer.enabled = false;

        // Is the same as above lines
        //if (TryGetComponent(out TrailRenderer trail))
        //    trail.enabled = false;

        // Tag the other player
        tagBehavior.Tag();
    }

    void OnCollisionExit(Collision collision) => Invoke("SetCanBeTagged", 0.5f);
}
