using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ẽample : MonoBehaviour
{
    public GameObject myOb;
    public float mySpeed = 5f;
    private MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = myOb.GetComponent<MeshRenderer>();
        myOb = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        MoveObject();
        myRenderer = myOb.GetComponent<MeshRenderer>();

    }
    void RotateObject()
    {

        transform.Rotate(new Vector3(1, 5, 1));
    }

    void MoveObject()
    {
        myOb.transform.position = new Vector3(myOb.transform.position.x + mySpeed * Time.deltaTime, myOb.transform.position.y, myOb.transform.position.z);
    }
}
