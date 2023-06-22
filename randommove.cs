using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommove : MonoBehaviour
{
    public Rigidbody rd;
    private float time;
    private bool iscollider;

    private void FixedUpdate()
    {
        time = 1f;
        time -= Time.deltaTime;
        if (time > 0&&iscollider)
        {
            rd.AddForce(new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), ForceMode.Impulse);
            time = 5f;
            iscollider = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        iscollider=true;
    }
}
