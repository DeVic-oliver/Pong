using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundarySoundHandler : MonoBehaviour, ISoundPlayable
{
    [SerializeField] private AudioClip hitBallSound;
    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(hitBallSound);
    }
}
