using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    private int conversationLength = 3;
    private int conversationIndex = 0;
    private int trigger = 3;

    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;

        for (int i = 1; i < conversationLength; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && conversationIndex < conversationLength)
        {
            canvas.transform.GetChild(conversationIndex).gameObject.SetActive(false);
            canvas.transform.GetChild(conversationIndex + 1).gameObject.SetActive(true);
            conversationIndex++;
        }
    }
}
