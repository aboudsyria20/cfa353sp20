using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody rb;
  public Vector3 playerPosition;
  public float playerSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float horiMove = Input.GetAxis("Horizontal");
      float vertMove = Input.GetAxis("Vertical");

      Vector3 speedVect = new Vector3(horiMove, vertMove, 0);
    speedVect = speedVect.normalized * playerSpeed * Time.deltaTime;
    rb.MovePosition(rb.transform.position + speedVect);


        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //  rb.velocity = new Vector3 (0, playerSpeed, 0);
        //}
    }
}
