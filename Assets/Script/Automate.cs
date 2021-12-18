using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>();
    private readonly List<string> allMove = new List<string>()
    {
        "U","D","L","R","F","B",
        "U'","D'","L'","R'","F'","B'",
        "U2","D2","L2","R2","F2","B2"
    };
    private CubeState cubeState;
    private ReadCube readCube;
    public List<GameObject> showObjects;
    bool shuffled=false;
    public bool startShuffle = false;
    bool showFlag=false;
    public static bool finishAuto = false;
    private void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
        //Shuffle();
    }
    private void Update()
    {
        //print(moveList.Count);
        if(moveList.Count==0&&!shuffled&&startShuffle)
        {
            shuffled = true;
        }
        if(shuffled&&!CubeState.autoRotating&&!showFlag)
        {
            foreach(GameObject obj in showObjects)
            {
                obj.SetActive(true);
            }
            showFlag = true;
            finishAuto = true;
            //player.SetActive(true);
            //timer.SetActive(true);
        }
        if(moveList.Count>0&&!CubeState.autoRotating&&CubeState.started)
        {
            //print(moveList[0]);
            DoMove(moveList[0]);
            moveList.Remove(moveList[0]);
            //if(moveList.Count==0)
            //{
            //    player.SetActive(true);
            //}
        }
    }
    void DoMove(string move)
    {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if(move=="U")
        {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeState.up, -180);
        }
        if (move == "D")
        {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeState.down, -180);
        }
        if (move == "L")
        {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeState.left, -180);
        }
        if (move == "R")
        {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeState.right, -180);
        }
        if (move == "F")
        {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeState.front, -180);
        }
        if (move == "B")
        {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeState.back, -180);
        }
    }
    void RotateSide(List<GameObject>side,float angle)
    {
        PivotRotation pr = side[0].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
    public void Shuffle()
    {
        List<string> moves = new List<string>();
        //int shuffleLength = Random.Range(10, 30);
        int shuffleLength = 15;
        for (int i=0;i<shuffleLength;i++)
        {
            int randomMove = Random.Range(0, allMove.Count);
            moves.Add(allMove[randomMove]);
        }
        moveList = moves;
        //print(moveList);
    }
}
