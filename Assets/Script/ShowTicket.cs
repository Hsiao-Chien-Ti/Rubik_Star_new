using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTicket : MonoBehaviour
{
    public Ticket levelController;
    void Update()
    {
        if(GetComponent<Slider>().value==GetComponent<Slider>().maxValue&&CollectWithTrash.trash==0)
        {
            levelController.show();
        }
    }
}
