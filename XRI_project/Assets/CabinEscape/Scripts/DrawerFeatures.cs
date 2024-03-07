/* Charlie Dye - 2024.03.07

This is the script for drawer features */

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerFeatures : CoreFeatures
{

    [Header("Drawer Configurations")]
    [SerializeField] private Transform drawer_pullout;
    [SerializeField] private float max_distance = 1.0f;
    [SerializeField] private FeatureDirection feature_direction = FeatureDirection.Forward;
    [SerializeField] private bool drawer_is_open = false;
    [SerializeField] private float drawer_speed = 1.0f;
    [SerializeField] private XRSimpleInteractable simple_interactable;
    
    void Start()
    {


        
    }

}
