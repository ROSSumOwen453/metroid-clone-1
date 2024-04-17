using TMPro;
using UnityEngine;

//Owen,Rossum
//4/6/2024
//user inter face for lives and coins
public class UIManager : MonoBehaviour
{
    //placeholder text for the Individual scores and lives 
    //public TMP_Text coinsHave;
    //public TMP_Text livesText;
    public TMP_Text healthPercent;

    //controller script access
    public Player_Controller playerController;

    // Update is called once per frame
    void Update()
    {
        //prints a string updated text for the coins and lives
        //coinsHave.text = "Coins = " + playerController.coinsHave.ToString();
        //livesText.text = "Lives = " + playerController.lives.ToString();
        healthPercent.text = playerController.healthAmount.ToString() + "% Health";

    }
}
