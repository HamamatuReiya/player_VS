using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject hitKey;
    private int timar = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("SampleScene");
        }

        timar++;
        if(timar % 100 > 50)
        {
            hitKey.SetActive(false);
        }
        else
        {
           hitKey.SetActive(true);
        }
    }
}
