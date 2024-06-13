using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject block2;
    public GameObject Goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public GameObject goalParticle;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Screen.SetResolution(1920, 1080, false);

        int[,] map =
        {
            {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,3,3,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0, 3,3,0,0,1,1,1,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,3,3,0,0, 1,1,0,0,0,0,1,0,2,2, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,1,0,0, 0,0,0,0,3,3,1,0,2,2, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1 },
        };
        Vector3 position = Vector3.zero;
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
        for (int x = 0; x < lenX; x++)
        {
            for (int y = 0; y < lenY; y++)
            {
                position.y = -y + 4;
                if (map[y,x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                if (map[y, x] == 2)
                {
                    Instantiate(Goal, position, Quaternion.identity);
                    goalParticle.transform.position = position;
                }
                if (map[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
            }
            position.x = x;
            //Instantiate(block,position, Quaternion.identity);
        }

        // ”wŒi
        for(int y = 0;y < lenY; y++)
        {
            for(int x = 0;x < lenX; x++)
            {
                position.x = x;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(block2, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalScript.isGameClear == true)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        scoreText.text = "SCORE " + score;
    }
}
