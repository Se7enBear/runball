using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move :Single<move>
{
	public Rigidbody rd;
    public int score = 0;
    public Text scoreText;
    public GameObject vitoryText;
    public int jumpcount = 0;
    public Transform Camera;
    private Vector3 offset;
    bool iswin;
    private float time;
    private float j = 5f;
    bool isjump;
    private Vector3 startpoint;
    public int foodcount;
    private float SliderPercent;
    private int life;

    protected override void Awake()
    {
        startpoint = transform.position;
        vitoryText.SetActive(false);
        iswin = false;
        SceneController.Instance.SaveScence();
        foodcount = GameObject.FindGameObjectsWithTag("food").Length;
        SliderPercent = 1f;
        life = 10;
    }
    private void Update()
    {
       offset = (transform.position - Camera.position).normalized;
        Win();
      StartCoroutine(JumpandOffset());
        restart();
    }

    private void restart()
    {
        if (life < 0)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    private void jump()
    {
        if(isjump)
        {
            rd.AddForce(new Vector3(0,j,0),ForceMode.Impulse);
            jumpcount++;
            isjump=false;
        }
    }

    void FixedUpdate()
    {
        fuhuo();
        jump();
       Movement();
    }

    private void Win()
    {
        if (score>= foodcount*100/3*2 && iswin == false)
        {
            vitoryText.SetActive(true);
            iswin = true;
            time = 5f;
        }
        time -= Time.deltaTime;
        if (time < 1f)
        {
            vitoryText.SetActive(false);
        }
    }

    private void Movement()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");
        rd.AddForce(new Vector3(offset.x * V*10,0 , offset.z * V*10));
        rd.AddForce(new Vector3(offset.z * H*10, 0, -offset.x * H*10));
    }

    private void fuhuo()
    {
        if (transform.position.y < -20)
        {
           
            transform.position = startpoint;
            rd.velocity = Vector3.zero;
            life--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpcount = 0;
        j = 5f;

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            jumpcount = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("food"))
            {
            FoodAudio.audioSource.Play();
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false; 
            score+=100;
            scoreText.text = "score:" + score;
            jumpcount = 0;
            j = 8f;
        }
        if (other.gameObject.CompareTag("ci"))
        {
            transform.position = startpoint;
            life--;
        }
        if (other.gameObject.CompareTag("Final")&&score>=foodcount*100/3*2)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            transform.position = startpoint;
            life--;
        }

        if (other.gameObject.CompareTag("attack"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Image healthSlider = scoreText.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            SliderPercent = SliderPercent - 0.1f;
            healthSlider.fillAmount = SliderPercent;
        }
    }

    IEnumerator JumpandOffset()
    {
        bool down = Input.GetKeyDown(KeyCode.Space);
        if (down && jumpcount == 0)
        {
            isjump = true;
        };
        yield return isjump;
    }
}
