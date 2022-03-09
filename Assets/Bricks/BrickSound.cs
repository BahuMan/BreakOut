using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSound : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] clips;
    private AudioSource[] src;

    // Start is called before the first frame update
    void Start()
    {
        src = new AudioSource[clips.Length];
        for (int i=0; i<clips.Length; ++i)
        {
            src[i] = gameObject.AddComponent<AudioSource>();
            src[i].playOnAwake = false;
            src[i].spatialBlend = 0f;
            src[i].spatialize = false;
            src[i].volume = 0.5f;
            src[i].clip = clips[i];
        }
    }

    public void PlayBrick(int c)
    {
        src[c].Play();
    }
}
