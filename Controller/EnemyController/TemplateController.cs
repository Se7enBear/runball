using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TemplateController : MonoBehaviour
{
    private GameObject template;
    private float time=-10f;
    private MeshRenderer mesh;
    private Collider collide;
    private void Awake()
    {
        template =this.gameObject;
        mesh = GetComponent<MeshRenderer>();
        collide = GetComponent<Collider>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        xiaoChu();
        fuYuan();
    }

    private void fuYuan()
    {
        if (collide.enabled == false &&time>-8f&&time<-7f)
        {
            collide.enabled = true;
            mesh.enabled = true;
            time = -10f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            time = 5f;
        }
    }
    private void xiaoChu()
    {
        if (time < 0f&&time>-1f)
        {
            collide.enabled = false;
            mesh.enabled = false;
            time = -2f;
        }
    }

}
