/* Charlie Dye - 2024.04.02

This is the script for the menu */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{

    /* Menu variable for quick reference
    Creating PROPERTY values: Encapsulation variable
    Get Accessor (READ); Set Accessor (WRITE) */

    [field: SerializeField] public Button ResumeButton { get; set; }
    [field: SerializeField] public Button RestartButton { get; set; }
    [field: SerializeField] public TextMeshProUGUI SolvedText {  get; set; }

}
