using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(First());
        Second();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator First()
    {
        Debug.Log("First");
        yield return new WaitForSeconds(5);
    }

    private void Second()
    {
        Debug.Log("Second");
    }
}
