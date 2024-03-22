using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestAIBehavior : MonoBehaviour
{
    private EState _currentState = EState.IDLE;
    private State[] _states;
    private int iter;

    //Gonna have to delete enum
    enum EState
    {
        IDLE,
        SEEK,
        WANDER,
        END
    };

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case EState.IDLE:
                //Check transition
                if (_currentState != EState.IDLE)
                    break;

                TransitionTo(EState.WANDER);
                break;

            case EState.SEEK:
                //Check transition
                if (_currentState != EState.SEEK)
                    break;

                //Run seek behavior
                _states[((int)_currentState)].Seek();

                break;

            case EState.WANDER:
                //Check transition
                if (_currentState != EState.WANDER)
                    break;

                //Run wander behavior
                _states[((int)_currentState)].Wander();

                break;

            case EState.END:
                //Check transition
                if (_currentState != EState.END)
                    break;

                //Insert ai behavior
                break;

            default:
                break;
        }
    }

    private void TransitionTo(EState state)
    {
        //Guard clause
        if (state == EState.END || state == _currentState)
            return;

        //Update current state to new state
        _currentState = state;
    }

    public struct State
    {
        public void Seek()
        {
            //Convert seek update to Unity C#
        }

        public void Wander()
        {
            //Convert wander update to Unity C#
        }
    }
}
