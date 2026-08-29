using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayerManager : MonoBehaviour
{   
    public AudioClip SFXplayer;
    public void Step()
    {
        AudioManager.instance.SFXPlaySimple(SFXplayer);
    }
}
