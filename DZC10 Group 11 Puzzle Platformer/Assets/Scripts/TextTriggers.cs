using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggers : MonoBehaviour
{
    [HideInInspector] public GameObject canvas;

    // Start is called before the first frame update
    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            canvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
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
