using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class death : MonoBehaviour
{
     public static int deaths = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       text.text="DEATH:"+deaths;
    }
}
