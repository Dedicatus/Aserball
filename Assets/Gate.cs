using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    enum GateType { MyGate, OpponentGate };

    [SerializeField] private GateType gateType = GateType.MyGate;

    private LevelController levelController;

    [SerializeField] private int myScore;

    FMOD.Studio.EventInstance scoreSound;
    FMOD.Studio.EventInstance getScoredSound;

    private void Start()
    {
        levelController = GameObject.FindWithTag("LevelController").GetComponent<LevelController>();
        myScore = 0;
        scoreSound = FMODUnity.RuntimeManager.CreateInstance("event:/Score");
        getScoredSound = FMODUnity.RuntimeManager.CreateInstance("event:/GetScored");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            switch (gateType)
            {
                case GateType.MyGate:
                    float reverbTimeScale = ((float)myScore / 3.0f) > 1.0f ? 1.0f : ((float)myScore / 3.0f);
                    getScoredSound.setParameterByName("ReverbTime", reverbTimeScale);
                    ++myScore;
                    getScoredSound.start();
                    break;
                case GateType.OpponentGate:
                    float pitchScale = ((float)myScore / 5.0f) > 1.0f ? 1.0f : ((float)myScore / 5.0f);
                    scoreSound.setParameterByName("Pitch", pitchScale);
                    ++myScore;
                    ++levelController.score;
                    scoreSound.start();
                    break;
                default:
                    break;
            }
            levelController.resetRound();
        }
    }
}
