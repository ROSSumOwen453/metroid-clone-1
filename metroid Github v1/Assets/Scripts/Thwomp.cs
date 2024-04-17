using System.Collections;
using UnityEngine;

//Owen,Rossum
//4/6/2024
//the controller for the thwomp enemy
public class Thwomp : MonoBehaviour
{
    //float place holders for speed/ y positions
    private float speedUp = 3;
    private float speedDown = 10;
    private float startY;
    private float bottomY;

    //bool placeholders for up and down / and for pausing
    private bool goingUp = false;
    private bool waiting;

    //called at teh start of scene
    private void Start()
    {
        //the raycast for the height of the thwomp
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

    //called every frame
    private void Update()
    {
        //when the thwomp goes up the object pauses
        if (!waiting)
        {
            if (goingUp)
            {
                //raycast detects height then pauses
                transform.Translate(Vector3.up * speedUp * Time.deltaTime);

                if (transform.position.y >= startY)
                {
                    goingUp = false;
                    StartCoroutine(Wait(3));
                }
            }
            else//goingdown
            {
                //raycast detects height then pauses
                transform.Translate(Vector3.down * speedDown * Time.deltaTime);

                if (transform.position.y <= bottomY)
                {
                    goingUp = true;
                    StartCoroutine(Wait(2));
                }
            }
        }
    }

    /// <summary>
    /// this coroutine 
    /// </summary>
    /// <param name="time"></param>
    /// <returns>nothing</returns>
    private IEnumerator Wait(float time)
    {
        waiting = true;
        yield return new WaitForSeconds(time);
        waiting = false;
    }
}
