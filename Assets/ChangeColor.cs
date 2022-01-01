using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public List<Material> mats;
    public List<GameObject> front;
    public List<GameObject> back;
    public List<GameObject> up;
    public List<GameObject> down;
    public List<GameObject> left;
    public List<GameObject> right;
    public Image f;
    public Image b;
    public Image u;
    public Image d;
    public Image l;
    public Image r;
    bool init = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!init)
        {
        //Material m = GetComponent<CubeState>().front[0].transform.GetChild(0).GetComponent<Renderer>().material;
        Vector3 y = front[0].transform.right;
            //print(y);
        for(int i=0;i<front.Count;i++)
        {
            print(front[i].transform.right);
            if(Vector3.Distance(front[i].transform.right,y)>0.005&& ColorToFinish.finish[0] == 0)
            {
                f.color = new Color(166f / 255, 166f / 255, 166f / 255);
                    ColorToFinish.finish[0] = 0 ;
                break;

            }
            if (i == 8)
            {
                f.color = Color.white;
                    ColorToFinish.finish[0] = 1;
                }
        }       
        y = back[0].transform.right;
        for (int i = 0; i < back.Count; i++)
        {
            if (Vector3.Distance(back[i].transform.right, y) > 0.005 && ColorToFinish.finish[3] == 0)
            {
                b.color = new Color(166f / 255, 166f / 255, 166f / 255);
                    ColorToFinish.finish[3] = 0;
                    break;

            }
            if (i == 8)
            {
                b.color = Color.white;
                    ColorToFinish.finish[3] = 1;
                }
        }
        y = down[0].transform.up;
        for (int i = 0; i < down.Count; i++)
        {
            if (Vector3.Distance(down[i].transform.up, y) > 0.005 && ColorToFinish.finish[1] == 0)
            {
                d.color = new Color(166f / 255, 166f / 255, 166f / 255);
                    ColorToFinish.finish[1] = 0;
                    break;

            }
            if (i == 8)
            {
                d.color = Color.white;
                ColorToFinish.finish[1] = 1;
            }
        }
        y = up[0].transform.up;
        for (int i = 0; i < up.Count; i++)
        {
            if (Vector3.Distance(up[i].transform.up, y) > 0.005 && ColorToFinish.finish[2] == 0)
            {
                u.color = new Color(166f / 255, 166f / 255, 166f / 255);
                    ColorToFinish.finish[2] = 0;
                    break;

            }
            if (i == 8)
            {
                u.color = Color.white;
                    ColorToFinish.finish[2] = 1;
                }
        }
 
        y = left[0].transform.forward;
        for (int i = 0; i < front.Count; i++)
        {
            if (Vector3.Distance(left[i].transform.forward, y) > 0.005 && ColorToFinish.finish[4] == 0)
            {
                l.color = new Color(166f / 255, 166f / 255, 166f / 255);
                    ColorToFinish.finish[4] = 0;
                    break;

            }
            if (i == 8)
            {
                l.color = Color.white;
                    ColorToFinish.finish[4] = 1;
                }
        }
        y = right[0].transform.forward;
        for (int i = 0; i < right.Count; i++)
        {
            if (Vector3.Distance(right[i].transform.forward, y) > 0.005 && ColorToFinish.finish[5] == 0)
            {
                r.color = new Color(166f / 255, 166f / 255, 166f / 255);
                ColorToFinish.finish[5] = 0;
                    break;
            }
            if (i == 8)
            {
                r.color = Color.white;
                ColorToFinish.finish[5] = 1;
                }
        }
        //for (int i = 0; i < 9; i++)
        //{
        //    if(GetComponent<CubeState>().front[i].name!="front")
        //    {
        //        f.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;

        //    }
        //    if (i==8)
        //    {
        //        f.color = Color.white;
        //    }
        //}
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().back[i].name != "back")
        //    {
        //        b.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;

        //    }
        //    if (i == 8)
        //    {
        //        b.color = Color.white;
        //    }
        //}
        ////m = GetComponent<CubeState>().back[0].transform.GetChild(0).GetComponent<Renderer>().material;
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().back[i].transform.GetChild(0).GetComponent<Renderer>().material != m)
        //    {
        //        b.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;
        //    }
        //    if (i == 8)
        //    {
        //        b.color = Color.white;
        //    }
        //}
        ////m = GetComponent<CubeState>().up[0].transform.GetChild(0).GetComponent<Renderer>().material;
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().up[i].transform.GetChild(0).GetComponent<Renderer>().material != m)
        //    {
        //        u.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;
        //    }
        //    if (i == 8)
        //    {
        //        u.color = Color.white;
        //    }
        //}
        ////m = GetComponent<CubeState>().down[0].transform.GetChild(0).GetComponent<Renderer>().material;
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().down[i].transform.GetChild(0).GetComponent<Renderer>().material != m)
        //    {
        //        d.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;
        //    }
        //    if (i == 8)
        //    {
        //        d.color = Color.white;
        //    }
        //}
        ////m = GetComponent<CubeState>().left[0].transform.GetChild(0).GetComponent<Renderer>().material;
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().left[i].transform.GetChild(0).GetComponent<Renderer>().material != m)
        //    {
        //        l.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;
        //    }
        //    if (i == 8)
        //    {
        //        l.color = Color.white;
        //    }
        //}
        ////m = GetComponent<CubeState>().right[0].transform.GetChild(0).GetComponent<Renderer>().material;
        //for (int i = 0; i < 9; i++)
        //{
        //    if (GetComponent<CubeState>().right[i].transform.GetChild(0).GetComponent<Renderer>().material != m)
        //    {
        //        r.color = new Color(166f / 255, 166f / 255, 166f / 255);
        //        break;
        //    }
        //    if (i == 8)
        //    {
        //        r.color = Color.white;
        //    }
        //}

        }

    }
    public void change()
    {
            for(int i=0;i<9;i++)
            {
                front[i].transform.GetChild(0).GetComponent <Renderer>().material= mats[0];
                back[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[1];
                up[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[2];
                down[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[3];
                left[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[4];
                right[i].transform.GetChild(0).GetComponent<Renderer>().material = mats[5];
            }
        init = false;
    }
}
