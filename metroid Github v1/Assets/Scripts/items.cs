using TMPro;
using UnityEngine;

public class items : MonoBehaviour
{
    public string itemName = ""; // Name of the item.

    public TMP_Text itemNameText;

    /// <summary>
    /// retrieves the name of the item and store the value to be ued in another script
    /// </summary>
    private void Start()
    {
        itemNameText.text = itemName;
    }

}
