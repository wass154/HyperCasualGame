using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public static float final;
    public Transform finaltarget;
    public Transform player;
    public  float distance;
    public TextMeshProUGUI Dtext;
    // Start is called before the first frame update
    void Start()
    {
        final=finaltarget.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
     
       distance=(finaltarget.transform.position-player.transform.position).magnitude;
       // Dtext.text=distance.ToString("d")+"Meters:";
       Dtext.text="Meters:"+distance;
    }
}
