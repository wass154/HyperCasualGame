using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yellowS : MonoBehaviour
{
    public GameObject Player;
    public Renderer YellowT;
    public Renderer  PlayerRenderer;
    public bool ischeck;
    public bool iscolorY;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRenderer=GetComponent<Renderer>();
        ischeck=false;
        iscolorY=false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnTriggerEnter(Collider other){
           if (YellowT.GetComponent<Renderer>().material.color.Equals(Player.GetComponent<Renderer>().material.color)) {
iscolorY=true;
        }
        else{
         iscolorY=false;   
        }
        if(other.CompareTag("Player") && iscolorY ){
ischeck=true;
        }
       else{
        Player.gameObject.SetActive(false);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          death.deaths+=1;
       }

    }
}

