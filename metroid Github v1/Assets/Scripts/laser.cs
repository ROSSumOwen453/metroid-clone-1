using UnityEngine;

//Owen,Rossum
//4/6/2024
//to control the laser cannon
public class laser : MonoBehaviour
{
    public GameObject laserPrefab;
    private float spawnRate = 10;

    /// <summary>
    /// begins the laser shot once every 10 seconds
    /// </summary>
    void Start()
    {
        InvokeRepeating("SpawnLaser", 1, spawnRate);
    }

    /// <summary>
    /// this creates the instance of the laser and uses the prefab to spawn at intervals
    /// </summary>
    private void SpawnLaser()
    {
        GameObject newLaser = Instantiate(laserPrefab, transform.position, transform.rotation);
    }
}
