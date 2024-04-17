using UnityEngine;

//Owen,Rossum
//4/6/2024
//controls the laser object
public class laserMove : MonoBehaviour
{
    private bool goingLeft = false;
    private float speed = 20;

    /// <summary>
    /// speed of laser in X direction and destroys after ends screen travel
    /// </summary>
    void Update()
    {
        //controls the laser speed in left direction
        if (goingLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //controls the laser speed in right direction
        if (!goingLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //destroys object once off scene
        if (transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
