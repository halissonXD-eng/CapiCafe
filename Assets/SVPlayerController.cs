using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVPlayerController : MonoBehaviour
{
    public AudioClip _audioClip;
    public void StepSound()
    {
        AudioManager.instance.SFXPlaySimple(_audioClip);
    }

}
