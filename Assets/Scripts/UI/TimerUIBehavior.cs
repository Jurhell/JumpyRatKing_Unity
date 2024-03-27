using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerUIBehavior : MonoBehaviour
{
    [SerializeField] private PlayerTagBehavior _tagBehavior;
    [SerializeField] private TextMeshProUGUI _playerTimer;
    [SerializeField] private TextMeshProUGUI _victoryScreen;
    [SerializeField] private float _countDown = 120.00f;

    private string _stored;
    private bool _victorDecided;

    void DisableTimer()
    {
        _victorDecided = true;
        _playerTimer.enabled = !enabled;
    }

    void Start()
    {
        Debug.Assert(_tagBehavior);
        Debug.Assert(_playerTimer);
        Debug.Assert(_victoryScreen);

        _victoryScreen.enabled = !enabled;

        _stored = _playerTimer.text;
    }

    void Update()
    {
        if (_victorDecided)
            _playerTimer.enabled = !enabled;

        if (!_tagBehavior || !_playerTimer || !_tagBehavior.IsTagged)
            return;

        if (_countDown > 0.0f)
            _countDown -= Time.deltaTime;

        _playerTimer.text = _stored + _countDown;
        
        if (_countDown <= 0.0f)
        {
            //Victory Screen
            DisableTimer();
            _victoryScreen.enabled = enabled;
        }
    }
}
