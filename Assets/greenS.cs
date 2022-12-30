using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class greenS : MonoBehaviour
{
       public GameObject Player;
    public Renderer GreenT;
    public Renderer  PlayerRenderer;
    public bool ischeck;
    public bool iscolorG;
    // Start is called before the first frame update
    void Start()
    {
           PlayerRenderer=GetComponent<Renderer>();
        ischeck=false;
        iscolorG=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other){
           if (GreenT.GetComponent<Renderer>().material.color.Equals(Player.GetComponent<Renderer>().material.color)) {
iscolorG=true;
        }
        else{
         iscolorG=false;   
        }
        if(other.CompareTag("Player") && iscolorG ){
ischeck=true;
        }
       else{
        Player.gameObject.SetActive(false);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          death.deaths+=1;
       }

    }
}
