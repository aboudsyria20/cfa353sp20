using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    // pawn shop owner dialogue
   public bool hadDonutConvo = false;
    public bool psoInitalConvo;
    // cheif dialogue
    public bool talkedToChief = false;
    // butcher dialogue
    public bool butchCrying = false;
    public bool butchCurious = false;
    public bool hadButchConvoTwo = false;
    //Baker dialogue
    public bool tellNoOne;
    public bool hadInitialDialogue;
    public bool hadRollingPinConvo;
    //Barber convo
    public bool hadBarberConvo;


  [Header("Player Stats")]
  public Rigidbody2D rb2d;
  public Animator anim;
  private Vector3 playerPosition;
  private bool canMove = true;
  public float playerSpeed = 10;

  //[Header("Get Other Scripts")]
 // DialogueOption dop;

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

  [Header("Got Evidence")]
  public GameObject moleUI;
  public GameObject glow1;
  public GameObject glow2;
  public GameObject glow3;
  public Text gotDeliTicketText;
  public Text gotJarOfJamText;
  public Text gotRollingPinText;

  [Header("Evidence in Inventory")]
  public bool keyInInventory = false;
  public bool rollingPinInInventory = false;
  public bool diamondNecklaceInInventory = false;
  public bool jarOfJamInInventory = false;
  public bool footprintsInInventory = false;
  public bool frozenFishInInventory = false;
  public bool butchersKnifeInInventory = false;
  public bool deliTicketInInventory = false;
  public bool jellyDonutInInventory = false;

  [Header("Can Get Specific Evidence")]
  private bool canGetJellyDonut = false;
  private bool canGetPawnInformation = false;
  private bool canGetBarberInformation = false;
  public bool canOpenBoat = false;
  private bool canDigKey = false;
  private bool canOpenChest = false;

  [Header("Inventory")]
  public GameObject inventoryPanel;
  public GameObject inventoryKey;
  public GameObject inventoryRollingPin;
  public GameObject inventoryDiamondNecklace;
  public GameObject inventoryJarOfJam;
  public GameObject inventoryFootprints;
  public GameObject inventoryFrozenFish;
  public GameObject inventoryButchersKnife;
  public GameObject inventoryDeliTicket;
  public GameObject inventoryJellyDonut;
  public Text deliTicketText;
  public Text jarOfJamText;
  public Text RollingPinText;
  private bool inventoryIsOpen = false;

  [Header("Sounds")]
  public AudioClip collectEvidence;
  public AudioClip footsteps;
  private float playFootsteps = 0.0f;
  public AudioClip water;

  [Header("Win Lose States")]
  public GameObject winScreen;
  public GameObject loseScreen;
  public bool playerWin = false;
  public bool playerLose = false;

  [Header("Pause States")]
  public GameObject pauseScreen;
  private bool gameIsPaused = false;

  [Header("Screen Checks")]
  private bool isInDialog = false;

  [Header("UI")]
  public GameObject pauseButton;


  [SerializeField] private GameObject m_dialoguePanelObject;

    // Start is called before the first frame update
    void Start()
    {

       // dop = FindObjectOfType<DialogueOption>();

    }

    public void Footstep()
    {
      AudioSource.PlayClipAtPoint(footsteps, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

      if(jellyDonutInInventory)
      {
        inventoryJellyDonut.SetActive(true);
      }
      else
      {
        inventoryJellyDonut.SetActive(false);
      }

      if(canOpenBoat && !rollingPinInInventory)
      {
        rollingPin.gameObject.SetActive(true);
      }
      else
      {
        rollingPin.gameObject.SetActive(false);
      }

      float horiMove = Input.GetAxisRaw("Horizontal");
      float vertMove = Input.GetAxisRaw("Vertical");

      if(m_dialoguePanelObject.activeInHierarchy)
      {
        rb2d.velocity = new Vector2 (0, 0);
            anim.SetFloat("Speed", 0);
            anim.SetFloat("YSpeed", 0);
            // set animation speed to 0

            return;
      }

      if(canMove == true)
      {
        rb2d.velocity = new Vector2 (horiMove * playerSpeed, vertMove * playerSpeed);
        anim.SetFloat("Speed", horiMove);
        anim.SetFloat("YSpeed", vertMove);
        //playFootsteps += Time.deltaTime;
        //if(playFootsteps < 0.1f)
        //{
        //   AudioSource.PlayClipAtPoint(footsteps, transform.position);
        //   playFootsteps = 0.0f;
      }

      //Debug.Log(horiMove);


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
        HandleTriggers();
        //Inventory();
        winLoseStates();
        PauseGame();

    }

    void FixedUpdate()
    {

    }

    /* public void Inventory()
    {
      if(Input.GetKeyDown(KeyCode.I)  && inventoryIsOpen == false && gameIsPaused == false && isInDialog == false)
      {
        canMove = false;
        inventoryPanel.gameObject.SetActive(true);
          if(deliTicketInInventory == true)
          {
              //deliTicketText.gameObject.SetActive(true);
              inventoryDeliTicket.gameObject.SetActive(true);
          }
          if(jarOfJamInInventory == true)
          {
              //jarOfJamText.gameObject.SetActive(true);
              inventoryJarOfJam.gameObject.SetActive(true);
          }
          if(jellyDonutInInventory == true)
          {
              inventoryJellyDonut.gameObject.SetActive(true);
          }
          if(frozenFishInInventory == true)
          {
              inventoryFrozenFish.gameObject.SetActive(true);
          }
          if(rollingPinInInventory == true)
          {
              //RollingPinText.gameObject.SetActive(true);
              inventoryRollingPin.gameObject.SetActive(true);
          }
          if(keyInInventory == true)
          {
              inventoryKey.gameObject.SetActive(true);
          }
          if(diamondNecklaceInInventory == true)
          {
              inventoryDiamondNecklace.gameObject.SetActive(true);
          }
          inventoryIsOpen = true;
      }

      else if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == true)
      {
        inventoryPanel.gameObject.SetActive(false);
        //deliTicketText.gameObject.SetActive(false);
        //jarOfJamText.gameObject.SetActive(false);
        //RollingPinText.gameObject.SetActive(false);
        inventoryIsOpen = false;
        canMove = true;
      }

    } */

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
        canMove = false;
      }
      else if(Input.GetKeyDown(KeyCode.P) && gameIsPaused == true)
      {
          pauseScreen.gameObject.SetActive(false);
        gameIsPaused = false;
        canMove = true;
      }
    }

    IEnumerator GotDeliTicket()
    {
        gotDeliTicketText.gameObject.SetActive(true);
        moleUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        gotDeliTicketText.gameObject.SetActive(false);
        moleUI.gameObject.SetActive(false);
    }

    IEnumerator GotJarOfJam()
    {
        gotJarOfJamText.gameObject.SetActive(true);
        moleUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        gotJarOfJamText.gameObject.SetActive(false);
        moleUI.gameObject.SetActive(false);
    }

    IEnumerator GotRollingPin()
    {
        gotRollingPinText.gameObject.SetActive(true);
        moleUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        gotRollingPinText.gameObject.SetActive(false);
        moleUI.gameObject.SetActive(false);
    }

    List<GameObject>enteredColliderObjects = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
      enteredColliderObjects.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
      enteredColliderObjects.Remove(other.gameObject);
    }

    void HandleTriggers()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        for(int i=0; i<enteredColliderObjects.Count; i++)
        {
          GameObject other = enteredColliderObjects[i];
          Debug.Log(other.gameObject);
          if (other.tag == "Cleaver")
          {
                Destroy(other.gameObject);
                glow1.gameObject.SetActive(false);
                inventoryDeliTicket.gameObject.SetActive(true);
                deliTicketInInventory = true;
                AudioSource.PlayClipAtPoint(collectEvidence, transform.position);
                StartCoroutine(GotDeliTicket());
                //dop.MustHavePickedUpTicket = true;
                //Debug.Log("Picked up Ticket");
                enteredColliderObjects.Remove(other);
          }

          if (other.tag == "JamJar")
          {
                Destroy(other.gameObject);
                glow2.gameObject.SetActive(false);
                inventoryJarOfJam.gameObject.SetActive(true);
                jarOfJamInInventory = true;
                AudioSource.PlayClipAtPoint(collectEvidence, transform.position);
                StartCoroutine(GotJarOfJam());
                //dop.mustHavePickedUpJam = true;
                //Debug.Log("Picked up Jar of Jam");
                enteredColliderObjects.Remove(other);
          }

          if (other.tag == "Boat" && canOpenBoat == true)
          {
              rollingPinInInventory = true;
              other.gameObject.SetActive(false);
              AudioSource.PlayClipAtPoint(collectEvidence, transform.position);
              StartCoroutine(GotRollingPin());
              //Debug.Log("Picked up Rolling Pin");
              enteredColliderObjects.Remove(other);
          }
        }
      }
    }
}
