using UnityEngine;
using UnityEngine.SceneManagement;

public class basicBlaster : MonoBehaviour

{
    private float speed = 20;
    private int buildIndexInt;

    void Start()
    {
        Invoke("Destroy", 0.2f);

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Example 1")
        {
            // Do something...
        }
        else if (sceneName == "Example 2")
        {
            // Do something...
        }

        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;
        buildIndexInt = buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "regularEnemyTag" || other.gameObject.tag == "hardEnemyTag" ||
            other.gameObject.tag == "wallTag" || other.gameObject.tag == "floorTag" ||
            other.gameObject.tag == "ArmorDoorTag")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "ArmorDoorTag" && this.gameObject.tag == "heavyBlasterTag")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ExitDoorTag")
        {
            if (buildIndexInt == 1)
            {
                //scene2
                SceneManager.LoadScene(3);
            }
            if (buildIndexInt == 3)
            {
                //scene3
                SceneManager.LoadScene(4);
            }
            if (buildIndexInt == 4)
            {
                //scene Final
                SceneManager.LoadScene(5);
            }
        }
    }
}

