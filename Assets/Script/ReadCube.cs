using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;

    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();

    public GameObject emptyGO;

    private int layerMask = 1 << 8;//儲存layer的編號/可以想成是二進位的選單/屬於的layer就是1不屬於的就是0/第8層是faces所以是1<<8

    CubeState cubeState;
    CubeMap cubeMap;
    
    // Start is called before the first frame update
    void Start()
    {
        SetRayTransforms();
        cubeState = FindObjectOfType<CubeState>();//只會有一個CubeState物件->可以用FindObjectOfType找到唯一一個
        cubeMap = FindObjectOfType<CubeMap>();
        ReadState();
        CubeState.started = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ReadState();
    }
    public void ReadState()
    {
        cubeState = FindObjectOfType<CubeState>();//只會有一個CubeState物件->可以用FindObjectOfType找到唯一一個
        cubeMap = FindObjectOfType<CubeMap>();
        cubeState.up = ReadFace(upRays, tUp);
        cubeState.down = ReadFace(downRays, tDown);
        cubeState.left = ReadFace(leftRays, tLeft);
        cubeState.right = ReadFace(rightRays, tRight);
        cubeState.front = ReadFace(frontRays, tFront);
        cubeState.back = ReadFace(backRays, tBack);
        cubeMap.Set();
    }
    void SetRayTransforms()
    {
        //每個ray要長在自己那個面的方向，所以每個面的ray要長的方向不一樣
        upRays = BuildRays(tUp, new Vector3(90, 90, 0));
        downRays = BuildRays(tDown, new Vector3(270, 90, 0));
        leftRays = BuildRays(tLeft, new Vector3(0, 0, 0));
        rightRays = BuildRays(tRight, new Vector3(0, 180, 0));
        frontRays = BuildRays(tFront, new Vector3(0, 270, 0));
        backRays = BuildRays(tBack, new Vector3(0, 90, 0));
    }
    //需要知道每格方塊的顏色，所以一個面應該要有9個ray/本來只創立了一個->用BuildRays函式變成9個
    List<GameObject> BuildRays(Transform rayTransform,Vector3 direction)
    {
        //用rayCount來命名ray
        //0|1|2
        //3|4|5
        //6|7|8
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();

        for(int y=1;y>-2;y--)
        {
            for(int x=-1;x<2;x++)
            {
                Vector3 startPos = new Vector3(rayTransform.localPosition.x + x, rayTransform.localPosition.y + y, rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGO, startPos, Quaternion.identity, rayTransform);//Quaternion.identity->生成的相對rotation都和parent(也就是rayTransform)一樣
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        //fix the rotation
        //調整rayTransform的rotation到該面對應的方向
        //每個rayStart因為是rayTransform的child所以方向也會被調整到
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }
    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        foreach(GameObject rayStart in rayStarts)
        {
            //RayCast是一種有點像LiDAR的東東，往前發射然後會回傳看到的東西(可以看HackMD)->在每一格擺一個Ray->用RayCast來看這個格子上的顏色
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;
            if(Physics.Raycast(ray,rayTransform.forward,out hit,Mathf.Infinity,layerMask))
            {
                facesHit.Add(hit.collider.gameObject);//把看到射線碰到的物體加進list裡
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                //print(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
        return facesHit;

    }
}
