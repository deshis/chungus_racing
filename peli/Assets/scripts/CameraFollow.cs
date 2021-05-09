using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;
    [SerializeField] private float rotationSpeed;


    private void FixedUpdate(){
        HandleFollow();
        HandleRotation();
    }

    private void HandleFollow(){
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    private void HandleRotation(){
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    public void setTarget(GameObject auto)
    {
        target = auto.transform;
    }


}
