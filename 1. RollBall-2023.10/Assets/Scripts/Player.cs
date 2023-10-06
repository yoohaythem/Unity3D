using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public int score = 0;
    public Text scoreText;
    public GameObject VictoryText;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("��Ϸ��ʼ"); 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("��Ϸ��������");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Debug.Log(h);
        rb.AddForce(new Vector3(h,0,v));
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "������" + score;
            
            if (score >= 12)
            {
                VictoryText.SetActive(true);
            }
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Debug.Log("������ײ");
    //    // collision.collider.tag
    //    if (collision.gameObject.tag == "Food")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
        
    //}

    //private void OnCollisionStay(Collision collision)
    //{
        
    //}
}
