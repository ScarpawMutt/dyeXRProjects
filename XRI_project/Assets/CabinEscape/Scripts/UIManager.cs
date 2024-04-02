/* Charlie Dye - 2024.03.26

This is the script for the UI manager */

using DyeXR.Singleton;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{

    [Header("UI Options")]
    [SerializeField] private float offset_position_from_player = 1.0f; // How far from the camera?
    [SerializeField] private GameObject menu_container; // Canvas with some buttons
    private const string GAME_SCENE_NAME = "CabinEscape"; // Allows us to restart the game

    [Header("Events")]
    public Action on_game_resume; // Notifies the GameManager to update class
    private Menu menu; // References a Menu.cs script

    // Bind menu buttons
    private void Awake()
    {
        
        menu = GetComponentInChildren<Menu>(true); // Add true in case any part of the menu is hidden at the beginning

        menu.ResumeButton.onClick.AddListener(() =>
        {

            HandleMenuOptions(GameState.Playing);
            on_game_resume?.Invoke(); 

        });

        menu.RestartButton.onClick.AddListener(() =>
        {

            SceneManager.LoadScene(GAME_SCENE_NAME);
            on_game_resume?.Invoke();

        });

    }

    private void OnEnable()
    {
        
        // TO DO - We need to add listener for GameManager changes
        // Bind to the GameManager
        // GameManager.Instance.onGamePaused += HandleMenuOptions;

    }

    private void OnDisable()
    {

        // TO DO - Ditto

    }

    private void HandleMenuOptions(GameState gameState) // Make sure these match the enum values!
    {

        if (gameState == GameState.Paused)
        {

            menu_container.SetActive(true);
            PlaceMenuInFront();

        }
        else if (gameState == GameState.PuzzleSolved)
        {

            menu_container.SetActive(true);
            menu.ResumeButton.gameObject.SetActive(false);
            menu.SolvedText.gameObject.SetActive(true);
            PlaceMenuInFront();

        }
        else
        {

            menu_container.SetActive(false); // This is essentially the "Playing" GameState. We don't want the menu to show while playing.

        }

    }

    void PlaceMenuInFront()
    {



    }

}
