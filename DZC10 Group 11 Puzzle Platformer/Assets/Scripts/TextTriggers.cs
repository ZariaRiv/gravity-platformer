using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggers : MonoBehaviour
{
    [HideInInspector] public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
        }

        if (other.tag == "SwitchingPlayer")
        {
            canvas.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}
