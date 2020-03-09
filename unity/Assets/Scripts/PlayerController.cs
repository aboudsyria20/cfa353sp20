using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   public bool hadDonutConvo = false;

  [Header("Player Stats")]
  public Rigidbody2D rb2d;
  public Animator anim;
  private Vector3 playerPosition;
  public float playerSpeed = 10;

  [Header("Get Other Scripts")]
  DialogueOption dop;

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
  public bool keyInInventory = false;
  public bool rollingPinInventory = false;
  public bool diamondNecklaceInventory = false;
  public bool jarOfJamInventory = false;
  public bool footprintsInInventory = false;
  public bool frozenFishInInventory = false;
  public bool butchersKnifeInInventory = false;
  public bool deliTicketInInventory = false;
  public bool jellyDonutInInventory = false;

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

  [Header("Win Lose States")]
  public GameObject winScreen;
  public GameObject loseScreen;
  private bool playerWin = false;
  private bool playerLose = false;

  [Header("Pause States")]
  public GameObject pauseScreen;
  private bool gameIsPaused = false;

  [Header("Screen Checks")]
  private bool isInDialog = false;

    // Start is called before the first frame update
    void Start()
    {

       // dop = FindObjectOfType<DialogueOption>();

    }


    // Update is called once per frame
    void Update()
    {
      float horiMove = Input.GetAxisRaw("Horizontal");
      float vertMove = Input.GetAxisRaw("Vertical");

      rb2d.velocity = new Vector2 (horiMove * playerSpeed, vertMove * playerSpeed);
      Debug.Log(horiMove);

      anim.SetFloat("Speed", horiMove);
      anim.SetFloat("YSpeed", vertMove);
      //anim.SetFloat("Speed", Mathf.Abs(horiMove));

      //Vector3 speedVect = new Vector3(horiMove, vertMove, 0);
    //speedVect = speedVect.normalized * playerSpeed * Time.deltaTime;
    //rb.MovePosition(rb.transform.position + speedVect);

    //if(Input.GetKeyUp(KeyCode.W))
    //{
//
    //}

        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //  rb.velocity = new Vector3 (0, playerSpeed, 0);
        //}

        Inventory();
        winLoseStates();
        PauseGame();

    }

    void FixedUpdate()
    {

    }

    public void Inventory()
    {
      if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == false && gameIsPaused == false && isInDialog == false)
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

      else if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == true)
      {
        inventoryPanel.gameObject.SetActive(false);
        deliTicketText.gameObject.SetActive(false);
        jarOfJamText.gameObject.SetActive(false);
        RollingPinText.gameObject.SetActive(false);
        inventoryIsOpen = false;
      }

    }

    public void winLoseStates()
    {
       // if()
      if(playerWin == true)
      {
        winScreen.gameObject.SetActive(true);
      }

      else if(playerLose == true)
      {
        loseScreen.gameObject.SetActive(true);
      }
    }

    public void PauseGame()
    {
      if(Input.GetKeyDown(KeyCode.P) && gameIsPaused == false)
      {
        pauseScreen.gameObject.SetActive(true);
        gameIsPaused = true;
      }
      else if(Input.GetKeyDown(KeyCode.P) && gameIsPaused == true)
      {
          pauseScreen.gameObject.SetActive(false);
        gameIsPaused = false;
      }
    }

    void OnTriggerStay(Collider other)
    {
      if (other.tag == "Cleaver" && Input.GetKeyDown(KeyCode.Space))
      {
            Destroy(other.gameObject);
            deliTicketInInventory = true;
            //dop.MustHavePickedUpTicket = true;
            Debug.Log("Picked up Ticket");
      }

      if (other.tag == "JamJar" && Input.GetKeyDown(KeyCode.Space))
      {
            Destroy(other.gameObject);
            jarOfJamInventory = true;
            //dop.mustHavePickedUpJam = true;
            Debug.Log("Picked up Jar of Jam");
      }

        if (other.tag == "Boat" && canOpenBoat == true && Input.GetKeyDown(KeyCode.Space))
        {
            rollingPinInventory = true;
            Debug.Log("Picked up Rolling Pin");
        }
    }
}
