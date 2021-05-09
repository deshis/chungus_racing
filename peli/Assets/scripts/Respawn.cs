using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{

    private laps laps;
    private Rigidbody rb;
    private bool isRespawning;

    public void OnReset(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isRespawning = true;
        }
        if (ctx.canceled)
        {
            isRespawning = false;
        }
    }

    void Start()
    {
        laps = GetComponent<laps>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isRespawning)
        {
            transform.rotation = laps.GetCPValue().rotation;
            if (gameObject.name == "DaCar2")
            {
                transform.position = laps.GetCPValue().position;
                transform.Translate(Vector3.right * 4f);
            }
            else
            {
                transform.position = laps.GetCPValue().position;
            }
            rb.velocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
        }
    }
}