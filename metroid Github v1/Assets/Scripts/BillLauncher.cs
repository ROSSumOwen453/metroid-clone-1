using UnityEngine;

//Owen,Rossum
//4/6/2024
//this  controls the launcher for the bullet bills
public class BillLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float spawnRate = 10;

    /// <summary>
    /// spawns the bullet bill prefab at every 10 frames
    /// </summary>
    void Start()
    {
        InvokeRepeating("SpawnBullet", 1, spawnRate);
    }

    /// <summary>
    /// spawns the bullet bill once every 10 frames
    /// </summary>
    private void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
