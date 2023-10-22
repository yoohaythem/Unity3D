using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float moveSpeed = 10;

    public bool isPlayerBullect;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 第一个参数按照自身方向(transform.up)移动，第二个参数一定要指定坐标系，例如世界坐标系，否则会乱套
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    collision.SendMessage("Die");   // 触发调用Tank身上的Die方法
                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");   // 触发调用Heart身上的Die方法
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }

                break;
            case "Wall":
                Destroy(collision.gameObject);  // 销毁墙
                Destroy(gameObject);  // 销毁自身
                break;
            case "Barrier":
                if (isPlayerBullect)
                {
                    collision.SendMessage("PlayAudio");
                }
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
