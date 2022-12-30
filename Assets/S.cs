using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S : MonoBehaviour
{
    public float s;
     public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
      s=score.final;  
    }

    // Update is called once per frame
    void Update()
    {
         text.text="Meters:"+s;
    }
}
