using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalHeight : MonoBehaviour
{
    public float i;
      public TextMeshProUGUI finalHeight;
    public Vector3 Scale;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scale=player.transform.localScale;
        i=Scale.y;
         finalHeight.text="finalHeight:"+i;
        
    }
}
