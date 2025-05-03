using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Score : MonoBehaviour
{
    public Game_Player player;
    public int score;
    public Text ScoreText;
    public Text playerScore;
    public GameObject prefab1, prefab2, prefab3;
    private List<Vector3> objectPositions;
    public int objectCount1, objectCount2, objectCount3;
    private int reset_times = 0;
    public static float areaWidth = 68;
    public static float areaLength = 167;
    public static float x = 455.8f, y = 528.06f, z = 175.7f;
    public static float x_min = (-areaWidth / 2) + x, x_max = (areaWidth / 2) + x - 2f,
                        y_min = y - 47f, y_max = y + 45.8f,
                        z_min = (-areaLength / 2) + z, z_max = (areaLength / 2) + z - 65;
    // Start is called before the first frame update
    void Start()
    {
        objectPositions = new List<Vector3>();
        player.GetScore += Player_GetScore;
        CudeRandom(prefab1, objectCount1);
        CudeRandom(prefab2, objectCount2);
        CudeRandom(prefab3, objectCount3);
    }

    private void Player_GetScore(int score)
    {
        ScoreManager += score;
    }

    public int ScoreManager
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            ScoreText.text = score.ToString();
            playerScore.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score != 0 && (score - reset_times) % 70 == 0) 
        //if(score == 70 || score == 141 || score == 212 || score == 283 || score == 354)
        {
            Debug.Log("123321");
            //Debug.Log(R.objectCount1);
            //R.GenerateObjects();
            objectPositions = new List<Vector3>();
            CudeRandom(prefab1, objectCount1);
            CudeRandom(prefab2, objectCount2);
            CudeRandom(prefab3, objectCount3);
            ScoreManager += 1;
            reset_times++;

        }
    }
    bool IsOverlapping(Vector3 position)
    {
        for (int i = 0; i < objectPositions.Count; i++)
        {
            if (Vector3.Distance(position, objectPositions[i]) < 25f)//¼Æ¦r¶V¤j ¶ZÂ÷¶V»·
            {
                return true;
            }
        }
        return false;
    }
    public void CudeRandom(GameObject prefab, int objectCount)
    {
        Debug.Log("random");
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(x_min, x_max),
                                                 Random.Range(y_min, y_max),
                                                 Random.Range(z_min, z_max));
            while (IsOverlapping(randomPosition))
            {
                randomPosition = new Vector3(Random.Range(x_min, x_max),
                                                 Random.Range(y_min, y_max),
                                                 Random.Range(z_min, z_max));
            }
            objectPositions.Add(randomPosition);
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }

    }
}
