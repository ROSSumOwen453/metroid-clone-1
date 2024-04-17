using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform Player;
    private Vector3 cameraPosition;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        cameraPosition = new Vector3(Player.position.x, Player.position.y + 2.89f, -13.59f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPosition, ref velocity, 0);
    }
}
