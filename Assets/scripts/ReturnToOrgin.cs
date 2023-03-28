using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToOrgin : MonoBehaviour
{
    [SerializeField] private Pose orginPose;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        orginPose.position = transform.position;
        orginPose.rotation = transform.rotation;
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(LaserGunReleased);
    }
    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(LaserGunReleased);
    }
    private void LaserGunReleased(SelectExitEventArgs arg0)
    {
        transform.position = orginPose.position;
        transform.rotation = orginPose.rotation;
    }

}
