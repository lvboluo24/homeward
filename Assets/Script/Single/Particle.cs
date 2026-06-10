using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem[] ps;
    public bool play;
    public int type;//0, 持续播放，1，单次播放
    public bool isplay;//已经播放

    void Start()
    {
        foreach (var item in ps)
        {
            item.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            if (!play)
            {
                foreach (var item in ps)
                {
                    item.Play();
                }

            }

            else if (play)
            {
                foreach (var item in ps)
                {
                    item.Stop(true);
                }

            }
        }
        if (type == 1)
        {
            if (!isplay && play)
            {
                foreach (var item in ps)
                {
                    item.Play();
                }
                isplay = true;
            }
            else if (!play)
            {
                foreach (var item in ps)
                {
                    item.Stop();
                }

            }
        }


    }
    public void Play()
    {
        StartCoroutine(PlayParticle());
    }
    public void PlaySolo()
    {
        StartCoroutine(PlayParticlesolo());
    }
    //协程
    public IEnumerator PlayParticle()
    {
        foreach (var item in ps)
        {
            item.Play();
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var item in ps)
        {
            item.Stop(true);
        }

    }
    public IEnumerator PlayParticlesolo()
    {
        ps[0].Play();
        yield return new WaitForSeconds(0.5f);
        ps[0].Stop(true);
    }
}
