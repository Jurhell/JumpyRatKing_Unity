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
    [SerializeField] private float _countDown = 120.00f;

    private string _stored;

    void Start()
    {
        Debug.Assert(_tagBehavior);
        Debug.Assert(_playerTimer);

        _stored = _playerTimer.text;
    }

    void Update()
    {
        if (!_tagBehavior || !_playerTimer || !_tagBehavior.IsTagged)
            return;

        _countDown -= Time.deltaTime;

        _playerTimer.text = _stored + _countDown;

        if (_countDown <= 0.0f)
        {
            //Win Condition
        }
    }
}
