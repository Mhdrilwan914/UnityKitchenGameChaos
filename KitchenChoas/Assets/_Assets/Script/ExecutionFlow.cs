using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionFlow : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("On Enable is Called");
    }

    private void Awake()
    {
        Debug.Log("Awake is Called");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start is Called");
    }

    private int halfSecond = 30;
    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > halfSecond)
        {
            halfSecond += 30;
            Debug.Log("Update is Called");
        }
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > halfSecond) 
        {
            halfSecond += 30;
            Debug.Log("Fixed Update is Called");
        }
    }

    private void LateUpdate()
    {
        if (Time.realtimeSinceStartup > halfSecond)
        {
            halfSecond += 30;
            Debug.Log("Late Update is Called");
        }
    }

    private void OnDestroy() 
    {
        Debug.Log("On Destroy is Called");
    }

    private void OnDisable()
    {
        Debug.Log("On Disable is Called");
    }

}
