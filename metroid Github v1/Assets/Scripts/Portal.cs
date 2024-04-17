using UnityEngine;

//Owen,Rossum
//4/6/2024
//portal controllers and the destinations
public class Portal : MonoBehaviour
{
    public GameObject teleportPoint;

    //when character touches portal mesh the player in transported to another location
    private void OnTriggerEnter(Collider other)
    {
        //the player touch portal transform the play position
        other.transform.position = teleportPoint.transform.position;
    }
}
