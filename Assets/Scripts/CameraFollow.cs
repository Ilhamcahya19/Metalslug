using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeReference]
    private float followSpeed = 2f;
    [SerializeReference]
    private float yOffset = 1f;
    [SerializeReference]
    private float xOffset = 1f;
    public Transform target;


    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position,  newPos, followSpeed * Time.deltaTime);
    }
}
