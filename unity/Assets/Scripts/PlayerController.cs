using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [Header("Player Stats")]
  public Rigidbody rb;
  private Vector3 playerPosition;
  public float playerSpeed = 20;

  [Header("Get Other Scripts")]
  //DialogueOptions dop;

  [Header("Evidence")]
  public GameObject key;
  public GameObject rollingPin;
  public GameObject diamondNecklace;
  public GameObject jarOfJam;
  public GameObject footprints;
  public GameObject frozenFish;
  public GameObject butchersKnife;
  public GameObject deliTicket;
  public GameObject jellyDonut;

  [Header("Evidence in Inventory")]
  private bool keyInInventory = false;
  private bool rollingPinInventory = false;
  private bool diamondNecklaceInventory = false;
  private bool jarOfJamInventory = false;
  private bool footprintsInInventory = false;
  private bool frozenFishInInventory = false;
  private bool butchersKnifeInInventory = false;
  private bool deliTicketInInventory = false;
  private bool jellyDonutInInventory = false;

  [Header("Can Get Specific Evidence")]
  private bool canGetJellyDonut = false;
  private bool canGetPawnInformation = false;
  private bool canGetBarberInformation = false;
  private bool canOpenBoat = false;
  private bool canDigKey = false;
  private bool canOpenChest = false;

    // Start is called before the first frame update
    void Start()
    {

        dop = FindObjectOfType<DialogueOptions>();

    }

    // Update is called once per frame
    void Update()
    {
      float horiMove = Input.GetAxis("Horizontal");
      float vertMove = Input.GetAxis("Vertical");

      Vector3 speedVect = new Vector3(horiMove, vertMove, 0);
    speedVect = speedVect.normalized * playerSpeed * Time.deltaTime;
    rb.MovePosition(rb.transform.position + speedVect);

    //if(Input.GetKeyUp(KeyCode.W))
    //{
//
    //}

        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //  rb.velocity = new Vector3 (0, playerSpeed, 0);
        //}
    }

    void OnTriggerStay(Collider other)
    {
      if (other.tag == "Cleaver" && Input.GetKeyDown(KeyCode.Space))
      {
            Destroy(other.gameObject);
            deliTicketInInventory = true;


            Debug.Log("Picked up Ticket");
            dop.MustHavePickedUpTicket = true;
      }


      if (other.tag == "JamJar" && Input.GetKeyDown(KeyCode.Space))
      {
            Destroy(other.gameObject);
            deliTicketInInventory = true;
            //dop.mustHavePickedUpJam = true;
      }

        if (other.tag == "Boat" && canOpenBoat == true && Input.GetKeyDown(KeyCode.Space))
        {
            rollingPinInventory = true;
        }
    }
}
