using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

  [Header("Inventory")]
  public GameObject inventoryPanel;
  public Text deliTicketText;
  public Text jarOfJamText;
  public Text RollingPinText;
  private bool inventoryIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {

        //dop = FindObjectOfType<DialogueOptions>();

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

        Inventory();

    }

    void Inventory()
    {
      if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == false)
      {
        inventoryPanel.gameObject.SetActive(true);
          if(deliTicketInInventory == true)
          {
              deliTicketText.gameObject.SetActive(true);
          }
          if(jarOfJamInventory == true)
          {
              jarOfJamText.gameObject.SetActive(true);
          }
          if(rollingPinInventory == true)
          {
              RollingPinText.gameObject.SetActive(true);
          }
          inventoryIsOpen = true;
      }

      if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == true)
      {
        inventoryPanel.gameObject.SetActive(false);
        deliTicketText.gameObject.SetActive(false);
        jarOfJamText.gameObject.SetActive(false);
        RollingPinText.gameObject.SetActive(false);
        inventoryIsOpen = false;
      }

    }

    void OnTriggerStay(Collider other)
    {
      if (other.tag == "Cleaver" && Input.GetKeyDown(KeyCode.Space))
      {
            Destroy(other.gameObject);
            deliTicketInInventory = true;
            Debug.Log("Picked up Ticket");
            //dop.MustHavePickedUpTicket = true;
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
