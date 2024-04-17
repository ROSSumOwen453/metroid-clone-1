using System.Collections;
using UnityEngine;

//Owen,Rossum
//4/6/2024
//the flying koopa enemy controller
public class FlyerKoopa : MonoBehaviour
{
    //game object placeholders
    public GameObject leftBoundary;
    public GameObject rightBoundary;

    //vector 3 positions
    private Vector3 leftPos;
    private Vector3 rightPos;

    //bool used for direction/ up direction / pause
    private bool moveLeft = true;
    private bool goingUp = false;
    private bool waiting;

    //floats for speed / y position
    private float speedUp = 3;
    private float speedDown = 3;
    private float startY;
    private float bottomY;
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //boundary points set
        leftPos = leftBoundary.transform.position;
        rightPos = rightBoundary.transform.position;

        //raycast for height above ground level
        RaycastHit hit;
        float thwompBottomY = transform.position.y - (transform.localScale.y / 2);
        startY = transform.position.y;
        Vector3 raycastOrigin = new Vector3(transform.position.x, thwompBottomY, 0);

        //draw ray from the bottom to the ground
        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit))
        {
            float distToGround = hit.distance;
            bottomY = startY - distToGround;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //while moving left times it by speed
        if (moveLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < leftPos.x)
            {
                //change direction when certain x position
                moveLeft = false;
            }
        }
        else
        {
            //while moving left times it by speed
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x > rightPos.x)
            {
                //change direction when certain x position
                moveLeft = true;
            }
        }

        //when not waiting
        if (!waiting)
        {
            //koopa goes up without pause before going back down
            if (goingUp)
            {
                //up wit hthe raycast for X distance
                transform.Translate(Vector3.up * speedUp * Time.deltaTime);

                if (transform.position.y >= startY)
                {
                    goingUp = false;
                }
            }
            else//goingdown
            {
                transform.Translate(Vector3.down * speedDown * Time.deltaTime);

                if (transform.position.y <= bottomY)
                {
                    //enumerator waits
                    goingUp = true;
                    StartCoroutine(Wait(1));
                }
            }
        }
    }

    /// <summary>
    /// this creates the pause between up and down jumps before continuing the script again
    /// </summary>
    /// <param name="time">1 second</param>
    /// <returns>nothing</returns>
    private IEnumerator Wait(float time)
    {
        waiting = true;
        yield return new WaitForSeconds(time);
        waiting = false;
    }

    /// <summary>
    /// when this koopa hits the player the koopa is destroyed and the player is unharmed
    /// </summary>
    /// <param name="other">character player</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player_Controller>())
        {
            Destroy(gameObject);
        }
    }
}
