using UnityEngine;
using UnityEngine.SceneManagement;

//Owen,Rossum
//4/6/2024
//this is the controller for the start / End screens
public class EndScene : MonoBehaviour
{
    /// <summary>
    /// quit game button
    /// </summary>
    public void QuitGame()
    {
        //exit out of the game
        Application.Quit();
        //test
        print("game has been quit");
    }

    /// <summary>
    /// button that takes you back to the game
    /// </summary>
    /// <param name="buildIndex">Level placeholder for unity engine</param>
    public void SwitchScene(int buildIndex)
    {
        //with game graphics level
        SceneManager.LoadScene(buildIndex);
        //without game graphics level
        SceneManager.LoadScene(buildIndex);
    }
}
