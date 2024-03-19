/* Charlie Dye - 2024.03.07

This is the script for drawer features */

using System.Collections;
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

        // Drawers with a simple interactable
        simple_interactable ?. selectEntered.AddListener((s) =>
        {

            // If the drawer is not open
            if (!drawer_is_open)
            {

                OpenDrawer();

            }

        });
        
    }

    private void OpenDrawer()
    {

        drawer_is_open = true;
        PlayOnStart();
        StartCoroutine(ProcessMotion());

    }

    private IEnumerator ProcessMotion()
    {

        while (drawer_is_open)
        {

            if (feature_direction == FeatureDirection.Forward && drawer_pullout.localPosition.z >= max_distance)
            {

                drawer_pullout.Translate(Vector3.forward * Time.deltaTime * drawer_speed);

            }
            else if (feature_direction == FeatureDirection.Backward && drawer_pullout.localPosition.z <= max_distance)
            {

                drawer_pullout.Translate(Vector3.back * Time.deltaTime * drawer_speed);

            }
            else
            {

                drawer_is_open = false;

            }

            yield return null;

        }

    }

}
