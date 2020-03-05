using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    FMOD.Studio.EventInstance bgm;

    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.FindWithTag("LevelController").GetComponent<LevelController>();
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        bgm.start();
    }

    private void Update()
    {
        float reverbHighCutScale = ((float) levelController.score / 3.0f) > 1.0f ? 1.0f : ((float)levelController.score / 3.0f);
        Debug.Log(reverbHighCutScale);
        bgm.setParameterByName("ReverbHighCut", reverbHighCutScale);
    }

}
