using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    [SerializeField] private float scale;

    private MusicController musicController;

    private void Awake()
    {
        musicController = GameObject.FindWithTag("System").transform.Find("MusicController").GetComponent<MusicController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            musicController.setDryLevel(scale);
        }
    }
}
