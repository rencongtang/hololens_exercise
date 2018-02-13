using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganScrollController : MonoBehaviour {

    public GameObject[] objects;
    private int activeIndex = 0;


    // Use this for initialization
    //void start()
    //{

    //}

    public void SetActiveObjects()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == activeIndex);
        }
    }

    public void InputCase()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0 )
        {
            activeIndex++;
        }

        else if (activeIndex == 0 && Input.GetAxisRaw("Horizontal") < 0)
        {
            activeIndex = 0;
        }

        else if (activeIndex > 0 && Input.GetAxisRaw("Horizontal") < 0 )
        {
            activeIndex--;
        }
    }

    // Update is called once per frame
    void Update()
    {

        InputCase();
        SetActiveObjects();

    }
}
