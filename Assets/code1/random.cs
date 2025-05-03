using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{//x=412, y=372, z=676;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public static float areaWidth = 68;
    public static float areaLength = 167;
    public int objectCount1;
    public int objectCount2;
    public int objectCount3;//total<=40
    public static float x= 455.8f, y= 528.06f, z= 175.7f;
    public static float x_min= (-areaWidth / 2) + x,x_max= (areaWidth / 2) + x-2f,
                        y_min = y - 47f, y_max = y + 45.8f,
                        z_min= (-areaLength / 2) + z,z_max= (areaLength / 2) + z-65;

    private List<Vector3> objectPositions;

    void Start()
    {
        objectPositions = new List<Vector3>();
        GenerateObjects();
    }

    public void GenerateObjects()
    {

        CudeRandom(prefab1, objectCount1);
        CudeRandom(prefab2, objectCount2);
        CudeRandom(prefab3, objectCount3);

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
