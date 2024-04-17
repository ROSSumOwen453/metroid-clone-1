using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    //float place holders for jump against gravity / speed/ fall height before death
    private float jumpForce = 7f;
    private float playerSpeed = 7f;
    private float deathHeight = -10;
    public float totalHealth = 99f;
    public float healthAmount = 99f; // was 99f
    public Image healthBarBar;
    public int larvaeKill;
    public int buildIndexInt;

    //rigid body place holders 
    private Rigidbody rb;
    public Vector3 checkpointPos;

    //plae holder starting lives/ and coin bank amount
    //public int lives = 3;
    //public int coinsHave = 0;

    //bool for player being stuned after shot with laser
    private bool playerStun = false;
    private bool doubleJump;
    private bool doubleJumpUnlocked;
    private bool damageDelay;
    public bool facingRight;
    //private bool healthIncrease = false;
    //private bool heavyBullets = false;
    //public bool heavyBulletsUnlock;

    public MeshRenderer playerMesh;

    //public GameObject basicBlasterPrefab;

    private void Awake()
    {
        playerMesh.enabled = true;
        //gets the ridgid body element at start
        rb = GetComponent<Rigidbody>();
        //registers the start position
        checkpointPos = transform.position;
        facingRight = true;
        doubleJumpUnlocked = false;
        damageDelay = true;
        //heavyBulletsUnlock = false;
    }

    private void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        int buildIndex = currentScene.buildIndex;
        buildIndexInt = buildIndex;


        if (buildIndexInt == 4)
        {
            doubleJumpUnlocked = true;
        }
        if (buildIndexInt == 5)
        {
            //healthIncrease = true;
            doubleJumpUnlocked = true;
            //heavyBullets = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //begins the player starting on the ground
        TouchOnGround();

        //when player is not stunned
        if (playerStun == false)
        {
            PlayerControlsJump();
        }

        //debug to see the vector raycast
        Debug.DrawLine(transform.position, transform.position - new Vector3(0, 1.01f, 0), Color.red);

        //if the player falls off the ledge
        if (transform.position.y < deathHeight)
        {
            Respawn();
        }

        //to game over screen
        //GameOver();

        Flip();
        //PlayerControlsShoot(); //on arm cannon

        //load game over screen!!!!!!!!!!!!!!!
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(2);
        }
        if (larvaeKill == 12)
        {
            SceneManager.LoadScene(6);
        }

        //if (healthIncrease)
        //{
        //    healthAmount = Mathf.Clamp(healthAmount, 0, totalHealth);

        //    totalHealth = 199f;
        //    healthAmount = 199f;

        //    healthBarBar.fillAmount = healthAmount / totalHealth;
        //}


    }


    void FixedUpdate()
    {
        //players controlls left/ right while not stunned
        if (playerStun == false)
        {
            PlayerControlsRun();
        }
    }

    public void TakeDamage(float Damage)
    {
        if (damageDelay == true)
        {
            healthAmount -= Damage;
            healthBarBar.fillAmount = healthAmount / totalHealth;
            //healthBarBar.fillAmount = healthAmount / 99;
            damageDelay = false;
            Invoke("EnableDamage", 5);

            InvokeRepeating("BlinkingOn", 0, 5 * Time.deltaTime);
            InvokeRepeating("BlinkingOff", 0, 5.9f * Time.deltaTime);
        }
    }

    private void EnableDamage()
    {
        damageDelay = true;
        CancelInvoke();
        playerMesh.enabled = true;

    }

    public void BlinkingOff()
    {
        playerMesh.enabled = false;
    }

    public void BlinkingOn()
    {
        playerMesh.enabled = true;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, totalHealth);

        healthBarBar.fillAmount = healthAmount / totalHealth;

        //healthAmount += healingAmount;
        //healthAmount = Mathf.Clamp(healthAmount, 0, 99);

        //healthBarBar.fillAmount = healthAmount / 99;
    }

    private void Flip()
    {
        if (!facingRight && Input.GetKey(KeyCode.RightArrow) || !facingRight && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }

        if (facingRight && Input.GetKey(KeyCode.LeftArrow) || facingRight && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }
    }

    public void UpdateScore(int kill)
    {
        larvaeKill += kill;
    }


    private void LaserHalt()
    {
        playerStun = false;
    }

    //private void GameOver()
    //{
    //    if (lives == 0)
    //    {
    //        //sends you to game over scene
    //        SceneManager.LoadScene(2);
    //    }
    //}


    public void Respawn()
    {
        //lives--;
        transform.position = checkpointPos;
    }

    private void PlayerControlsJump()
    {
        //while space bar is pressed player jumps once
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //no jump until player hits ground again
            if (TouchOnGround())
            {
                doubleJump = true;
                //jump force against the set gravity
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
            else
            {
                if (doubleJumpUnlocked)
                {
                    //DOUBLE JUMP code!               
                    if (Input.GetKeyDown(KeyCode.Space) && !TouchOnGround() && doubleJump == true)
                    {

                        rb.velocity = Vector3.zero;
                        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                        doubleJump = false;
                    }
                }
            }
        }
    }

    private void PlayerControlsRun()
    {
        //while the right arrow of D button is pressed

        if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.RightArrow)) ||
            Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.D)))
        {
            playerSpeed = 0;
        }
        else
        {
            //facingRight = true;
            playerSpeed = 7f;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            //transform.Rotate(0f, 0f, 0f);

            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        ////if left or A button is pressed
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            //transform.Rotate(0f, 180f, 0f);

            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            //facingRight = false;
        }
    }

    private bool TouchOnGround()
    {
        bool onGround = false;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            onGround = true;
        }
        return onGround;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Coins>())
        //{
        //    coinsHave += other.GetComponent<Coins>().value;
        //    Destroy(other.gameObject);
        //}

        //if (other.GetComponent<Enemy>())
        //{
        //    Respawn();
        //}

        //if (other.GetComponent<TBott>() && TouchOnGround())
        //{
        //    Respawn();
        //}

        //if (other.GetComponent<Bullet>())
        //{
        //    Respawn();
        //}

        //if (other.GetComponent<KoopaHurt>())
        //{
        //    Respawn();
        //}

        if (other.gameObject.tag == "regularEnemyTag" && damageDelay == true)
        {
            TakeDamage(15);
        }

        if (other.gameObject.tag == "hardEnemyTag" && damageDelay == true)
        {
            TakeDamage(35);
        }

        if (other.gameObject.tag == "Metroid1Tag" && damageDelay == true)
        {
            TakeDamage(65);
        }



        //if (other.gameObject.tag == "heavyBulletsPackTag")
        //{
        //    heavyBulletsUnlock = true;
        //    Destroy(other.gameObject);
        //}

        if (other.GetComponent<laserMove>())
        {
            playerStun = true;
            Invoke("LaserHalt", 2);
        }

        if (other.gameObject.tag == "doubleJumpTag")
        {
            doubleJumpUnlocked = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "increaseHealthTag")
        {
            //healthIncrease = true;
            healthAmount = Mathf.Clamp(healthAmount, 0, totalHealth);

            totalHealth = 199f;
            healthAmount = 199f;

            healthBarBar.fillAmount = healthAmount / totalHealth;
            Destroy(other.gameObject);
        }

        if (healthAmount < totalHealth && other.gameObject.tag == "healthPackTag")
        {
            Heal(10);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<spike>())
        //{
        //    Respawn();
        //}
    }
}
