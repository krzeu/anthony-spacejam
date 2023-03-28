using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    private RaycastHit hit;
    private AudioSource laserAudioSource;

    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        // animera pistolen
        laserAnimator.SetTrigger("Fire");

        // spela laser sfx
        laserAudioSource.PlayOneShot(laserSFX);
        // raycast
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
           if(hit.transform.GetComponent<AstroidHits>() != null)
            {
                hit.transform.GetComponent<AstroidHits>().AsteroidHit();
            }
            
        }
    }
}
