using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed = 3.0f;
    public CharacterController cc;
    public float Gravity = -9.8f;
    public float JumpSpeed = 3f;
    public float verticalSpeed;
    public GameObject SprintCrys;
    public GameObject FlyCrys;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        // X/Z movement
        float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        verticalSpeed += (Gravity * Time.deltaTime);

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement) + (transform.up * verticalSpeed * Time.deltaTime);
        cc.Move(movement);

        if (SprintCrys.GetComponent<SprintCrystal>().AbilityAvailable == true)
        {
            Sprint();
        }

        if (FlyCrys.GetComponent<FlyCrystal>().AbilityAvailable == true)
        {
            Fly();
        }
    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 20f;
            Debug.Log("Sprinting");
        }
        else
        {
            MoveSpeed = 3.0f;
        }
    }

    public void Fly()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            verticalSpeed = JumpSpeed;
        } 

        movement += (transform.up * verticalSpeed * Time.deltaTime);

        cc.Move(movement);
    }
}
