using UnityEngine;

//Owen,Rossum
//4/6/2024
//this controls the actual bullet bill
public class Bullet : MonoBehaviour
{
    private bool goingLeft = false;
    private float speed = -10;

    /// <summary>
    /// speed of bill left/right fo 5 seconds then destroys
    /// </summary>
    void Update()
    {
        //speed of bill in the left direction
        if (goingLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //speed of bill in the right direction
        if (!goingLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //destroys the bullet after 5 seconds on the x axis
        if (transform.position.x > 76)
        {
            Destroy(this.gameObject);
        }
    }
}
