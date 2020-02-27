using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    enum GateType { MyGate, OpponentGate };

    [SerializeField] private GateType gateType = GateType.MyGate;

    private LevelController levelController;

    private void Start()
    {
        levelController = GameObject.FindWithTag("LevelController").GetComponent<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            switch (gateType)
            {
                case GateType.MyGate:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Scored");
                    break;
                case GateType.OpponentGate:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Score");
                    break;
                default:
                    break;
            }
            levelController.resetRound();
        }
    }
}
