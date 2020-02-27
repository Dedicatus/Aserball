using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    FMOD.Studio.EventInstance bgm;

    // Start is called before the first frame update
    void Start()
    {
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        bgm.start();
    }

}
