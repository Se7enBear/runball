using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private float time;
    private MeshRenderer mesh;
    private Collider collide;
    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        collide = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        if (!mesh.enabled&&time < 0) 
        {
            fuYuan();
        }
    }

    private void fuYuan()
    {
       mesh.enabled = true;
        collide.enabled = true;
        time = 30f;
    }
}
