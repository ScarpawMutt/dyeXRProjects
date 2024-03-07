/* Charlie Dye - 2024.02.29

This is the script for core features */

using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Inherits CoreFeatures' class
public class DoorFeatures : CoreFeatures
{

    /* What do we need for our doors?
    We need its pivot information, open door state,
    a maximum angle for how far it can pivot,
    and reverse and speed variables. */

    [Header("Door Configurations")]
    [SerializeField] private Transform door_pivot; // Controls pivot
    [SerializeField] private float max_angle = 90f; // Perhaps less than 90 will be wanted?
    [SerializeField] private bool reverse_angle_direction = false;
    [SerializeField] private float door_speed = 10f; // 10f should be a good start
    [SerializeField] private bool door_is_open = false;
    [SerializeField] private bool make_kinematic_on_open = false;

    /* We also need interaction features for our socket interactor
    and a simple interactor. */

    [Header("Interaction Configurations")]
    [SerializeField] private XRSocketInteractor socket_interactor;
    [SerializeField] private XRSimpleInteractable simple_interactor;

    private void Start()
    {

        socket_interactor ?. selectEntered.AddListener((s) =>
        {

            OpenDoor();
            PlayOnStart();

        });

        socket_interactor?.selectExited.AddListener((s) =>
        {

            // When we are finshed exiting, we don't want to reuse the socket.
            PlayOnEnd();
            socket_interactor.socketActive = feature_usage == FeatureUsage.Once ? false : true;

        });

        simple_interactor?.selectEntered.AddListener((s) =>
        {

            OpenDoor();

        });

    }

    public void OpenDoor()
    {

        if (!door_is_open)
        {

            PlayOnStart();
            door_is_open = true;
            StartCoroutine(ProcessMotion());

        }

    }

    private IEnumerator ProcessMotion()
    {

        while (door_is_open)
        {

            var angle = door_pivot.localEulerAngles.y < 180 ? door_pivot.localEulerAngles.y : door_pivot.localEulerAngles.y - 360;
            angle = reverse_angle_direction ? Mathf.Abs(angle) : angle;

            if (angle <= max_angle)
            {

                door_pivot?.Rotate(Vector3.up, door_speed * Time.deltaTime * (reverse_angle_direction ? -1 : 1));

            }
            else
            {

                door_is_open = false;
                var feature_rigidbody = GetComponent<Rigidbody>();
                if (feature_rigidbody != null && make_kinematic_on_open)
                {

                    feature_rigidbody.isKinematic = true;

                }

            }

            yield return null;

        }

    }    

}
