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
    static bool _victorDecided;

    void DisableTimer()
    {
        //Tell that a player has won and and disable timer text
        _victorDecided = true;
        _playerTimer.enabled = false;
    }

    void Start()
    {
        Debug.Assert(_tagBehavior);
        Debug.Assert(_playerTimer);
        Debug.Assert(_victoryScreen);

        //Disable victory screen and timers before first loop
        _victoryScreen.enabled = false;
        _playerTimer.enabled = false;

        //Storing default text for later
        _stored = _playerTimer.text;
    }

    void Update()
    {
        //Removing timers after a player has won
        if (_victorDecided)
            _playerTimer.enabled = false;

        if (!_tagBehavior || !_playerTimer || !_tagBehavior.IsTagged)
            return;

        _playerTimer.enabled = true;

        //Only count down if the time is greater than 0
        if (_countDown > 0.0f)
            _countDown -= Time.deltaTime;

        //Storing time as minutes and seconds
        int minutes = Mathf.FloorToInt(_countDown / 60);
        int seconds = Mathf.FloorToInt(_countDown % 60);
        int milliseconds = seconds / 100;

        //Creating a format for the timer and displaying with stored text
        _playerTimer.text = _stored + string.Format("{0:00}:{1:00}", minutes, seconds);
        
        //If the count down is less than or equal to zero
        if (_countDown <= 0.0f)
        {
            //Remove timer and enable victory screen component
            DisableTimer();
            _victoryScreen.enabled = true;
        }
    }
}
