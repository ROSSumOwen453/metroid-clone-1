using UnityEngine;

//Owen,Rossum
//4/6/2024
//controls the enemy that walks side to side
public class Enemy : MonoBehaviour
{
    private float speed = 4;
    private float health;

    public GameObject leftBoundary;
    public GameObject rightBoundary;

    //public GameObject TopBoundary;
    //public GameObject BottBoundary;

    //vector 3 postions left right
    private Vector3 leftPos;
    private Vector3 rightPos;

    //private Vector3 upPos;
    //private Vector3 downPos;

    //decides when the object turns back
    private bool moveLeft = true;

    //private bool moveUp = true;

    /// <summary>
    /// tags for the left and right end positions
    /// </summary>
    void Start()
    {
        leftPos = leftBoundary.transform.position;
        rightPos = rightBoundary.transform.position;

        //upPos = TopBoundary.transform.position;
        //downPos = BottBoundary.transform.position;

        if (this.gameObject.tag == "regularEnemyTag")
        {
            health = 1;
        }

        if (this.gameObject.tag == "hardEnemyTag")
        {
            health = 10;
        }

        //if (this.gameObject.tag == "Metroid1Tag")
        //{
        //    health = 3;
        //}
    }

    /// <summary>
    /// controls the speed of the object and its direction
    /// </summary>
    void Update()
    {
        if (moveLeft)
        {
            //while moving left on the X axis the enemy uses the speed
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < leftPos.x)
            {
                moveLeft = false;
            }
        }
        else
        {
            //while moving right on the X axis the enemy uses the speed
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x > rightPos.x)
            {
                moveLeft = true;
            }
        }

        //if (moveUp && this.gameObject.tag == "Metroid1Tag")
        //{
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);

        //    if (transform.position.y < upPos.y)
        //    {
        //        moveLeft = false;
        //    }
        //}
        //else
        //{
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);

        //    if (transform.position.y > downPos.y)
        //    {
        //        moveLeft = false;
        //    }
        //}

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "basicBlasterTag")
        {
            health--;
        }

        if (other.gameObject.tag == "heavyBlasterTag")
        {
            health = health - 3;
        }
    }
}