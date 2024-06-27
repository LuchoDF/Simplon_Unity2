using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{   
    [SerializeField] private GameObject agent1;
    [SerializeField] private GameObject agent2;
    [SerializeField] private GameObject agent3;

    public float changeSpeed = 10;
    private static float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent1.transform.localScale = new Vector3 (2.0f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(agent1, changeSpeed = 5);

    }
}
