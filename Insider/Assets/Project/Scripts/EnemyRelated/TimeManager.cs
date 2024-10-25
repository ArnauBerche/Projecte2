using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]float levelTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;
    }
}
