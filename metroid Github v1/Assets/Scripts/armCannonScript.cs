using System.Collections;
using UnityEngine;


public class armCannonScript : MonoBehaviour
{
    public Player_Controller playerController;
    public GameObject basicBlasterPrefab;
    public GameObject heavyBlasterPrefab;

    public bool lookingUp;
    public bool lookingDown;
    public bool heavyBulletsUnlock;
    public bool heavyBlasterUnlocked;

    private void Start()
    {
        heavyBlasterUnlocked = false;
        StartCoroutine("ShotDelay");
        heavyBulletsUnlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        //fire arm cannon as fast as you can tap the button
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    ShootLaser1();
        //    print("test1");
        //}

        //if (Input.GetKey(KeyCode.B))
        //{
        //    StartCoroutine(ShotDelay());
        //}

        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W)))
        {
            lookingUp = true;
        }
        else
        {
            lookingUp = false;
        }

        if (lookingUp && Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            transform.Rotate(0f, 0f, 90f);
        }

        if (!lookingUp && Input.GetKeyUp(KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.W)))
        {

            transform.Rotate(0f, 0f, -90f);
        }

        if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S)))
        {
            lookingDown = true;
        }
        else
        {
            lookingDown = false;
        }

        if (lookingDown && Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            transform.Rotate(0f, 0f, -90f);
        }

        if (!lookingDown && Input.GetKeyUp(KeyCode.DownArrow) || (Input.GetKeyUp(KeyCode.S)))
        {
            //print("test");
            transform.Rotate(0f, 0f, 90f);
        }
    }

    private void ShootLaser1()
    {
        if (heavyBlasterUnlocked == true)
        {
            GameObject newLaser = Instantiate(heavyBlasterPrefab, transform.position, transform.rotation);
        }
        else
        {
            GameObject newLaser = Instantiate(basicBlasterPrefab, transform.position, transform.rotation);
        }
    }

    private IEnumerator ShotDelay()
    {
        while (true)
        {
            while (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.Return))
            {
                ShootLaser1();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "heavyBulletsPackTag")
        {
            heavyBlasterUnlocked = true;
            heavyBulletsUnlock = true;
            Destroy(other.gameObject);
        }
    }
}
