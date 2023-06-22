using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rd;
    private float time;
    private Renderer material;
    public Image image;
    private bool isattack;
    public Vector3 offset;
    float randomPoint;
    private Transform transfom;
    public Text text;
    private bool isGO;

    private void Awake()
    {
        rd=player.GetComponent<Rigidbody>();
        time = 5f;
        material =gameObject.GetComponent<Renderer>();
        transfom = gameObject.GetComponent<Transform>();
        isattack = false;
        randomPoint = 0.5f;
        
    }
    private void Update()
    {
        offset = (transform.position - player.transform.position).normalized;
        transform.LookAt(player.transform.position);
        time-=Time.deltaTime;
        IsAttack();
        if (isGO == false&&time<0)
        {
            transfom.position = Vector3.MoveTowards(transfom.position, new Vector3(transfom.position.x, transfom.position.y, 120), 0.1f);
        }
        if (isGO)
        {
            transfom.position = Vector3.MoveTowards(transfom.position, new Vector3(transfom.position.x, transfom.position.y, 0), 0.1f);
            if (transfom.position.z == 0)
            {
                isGO=false;
                time = 5f;
            }
        }
        if (time < 0 && isattack)
        {
            Attack();
        }

        Dead();

    }

    private void Attack()
    {
            material.material.color = Color.red;
            if (randomPoint < 0.7)
            {
                if (randomPoint < 0.4)
                {
                    if (time < -1f)
                    {
                    rd.AddForce(offset * 10, ForceMode.Impulse);
                    material.material.color = Color.green;
                        time = 5f;
                        isattack = false;
                    GetNewRandom();
                    }
                }
                
                else
                {
                    if (time < -1f)
                    {
                        isGO=true;
                        material.material.color = Color.green;
                        time = 5f;
                        isattack = false;
                    GetNewRandom();
                }
                }
            }
            else
            {
                if (time < -1f)
                {
                    rd.AddForce(-offset * 10,ForceMode.Impulse);
                    isattack = false;
                    material.material.color = Color.green;
                    time = 5f;
                GetNewRandom();
            }
            }
    }

    private void GetNewRandom()
    {
        randomPoint = Random.value;
    }

    private void Dead()
    {
        if (image.fillAmount <= 0)
        {
            Destroy(gameObject);
            text.enabled = true;
        }
    }

    private void IsAttack()
    {
        if (time < 0 &&!isattack)
        {
            material.material.color = Color.yellow;
            time = 5f;
            isattack = true;
        }
    }
}
