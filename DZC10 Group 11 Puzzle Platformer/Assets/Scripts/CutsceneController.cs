using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    private int conversationLimit = 3;
    private int conversationIndex = 0;
    private int trigger = 2;

    private GameObject canvas, professor, machine, playerInConversation;
    public GameObject portal, player;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;

        for (int i = 1; i <= conversationLimit; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }

        playerInConversation = transform.GetChild(1).gameObject;
        professor = transform.GetChild(2).gameObject;
        machine = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (conversationIndex < conversationLimit)
            {
                if (conversationIndex == trigger - 1)
                {
                    professor.GetComponent<SpriteRenderer>().flipX = false;
                }

                if (conversationIndex == trigger)
                {
                    Destroy(professor);
                    Destroy(machine);
                    Instantiate(portal, machine.transform.position, Quaternion.identity);
                }

                canvas.transform.GetChild(conversationIndex).gameObject.SetActive(false);
                canvas.transform.GetChild(conversationIndex + 1).gameObject.SetActive(true);
                conversationIndex++;
            }
            else
            {
                canvas.transform.GetChild(conversationIndex).gameObject.SetActive(false);
                Destroy(playerInConversation);
                Instantiate(player, playerInConversation.transform.position, Quaternion.identity);
            }
        }
    }
}
