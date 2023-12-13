using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
enum TargetEnum
{
    topLeft,
    topRight,
    botRight,
    botLeft,
}
public class MoveCar : MonoBehaviour
{
    public float carSpeed = 2f;
    public Transform transformTopLeft;
    public Transform transformTopRight;
    public Transform transformBottomLeft;
    public Transform transformBottomRight;

    // private Transform curCar; // tọa độ bắt đầu của xe 
    private Transform nextCar; // tọa độ điểm muốn đến của xe
    private Transform startCar; // tọa độ điểm bắt đầu của xe 
    private TargetEnum curTarget; // trạng thái hiện tại của xe 
    // Start is called before the first frame update
    void Start()
    {
        curTarget = TargetEnum.topLeft;
        startCar = transformTopLeft;
        transform.position = startCar.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
        Vector3 vectoMove = nextCar.position - transform.position; // vecto di chuyển của xe
        float len = vectoMove.magnitude; // độ dài vecto di chuyển của xe
        if (len > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextCar.position, carSpeed * Time.deltaTime);
        }
        else
        {
            SetNextTarget();
        }
    }
    void SetNextTarget()
    {
        if (curTarget == TargetEnum.topLeft)
        {
            curTarget = TargetEnum.topRight;
        }
        else if (curTarget == TargetEnum.topRight)
        {
            curTarget = TargetEnum.botRight;
        }
        else if (curTarget == TargetEnum.botRight)
        {
            curTarget = TargetEnum.botLeft;
        }
        else if (curTarget == TargetEnum.botLeft)
        {

            curTarget = TargetEnum.topLeft;
        }
    }
    void CheckTarget() // hàm check trạng thái vị trí của ô tô 
    {
        if (curTarget == TargetEnum.topLeft)
        {
            nextCar = transformTopRight;
        }
        else if (curTarget == TargetEnum.topRight)
        {
            nextCar = transformBottomRight;
        }
        else if (curTarget == TargetEnum.botRight)
        {
            nextCar = transformBottomLeft;
        }
        else if (curTarget == TargetEnum.botLeft)
        {
            nextCar = transformTopLeft;
        }
    }
}
