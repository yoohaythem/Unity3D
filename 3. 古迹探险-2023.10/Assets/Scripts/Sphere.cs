using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Åö×²Æ÷¡¢´¥·¢Æ÷
    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter" + collision.collider.name);
        // print("OnCollisionEnter" + collision.collider.tag);

    }

    private void OnCollisionExit(Collision collision)
    {
        print("OnCollisionExit" + collision.collider.name);
        // print("OnCollisionExit" + collision.collider.tag);
    }

    private void OnCollisionStay(Collision collision)
    {
        print("OnCollisionStay" + collision.collider.name);
        // print("OnCollisionStay" + collision.collider.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter" + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        print("OnTriggerStay" + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit" + other.name);
    }
}
