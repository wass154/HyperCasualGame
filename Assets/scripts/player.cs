using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject FinalCanvas;
    public Vector3 scale,currentscale;
    private Transform cube;
    private Vector3 mouseStartPos,cubeStartPos;
    private bool moveCube;
    [Range(0f,1f)] public float Speed;
        [Range(0f,1f)] public float CamSpeed;
          [Range(0f,50f)] public float pathSpeed;
    private float Velocity,camVelocity;
    private Camera cam;
    public Transform path;
    private Rigidbody rb;
    public Renderer PlayerRenderer;
    public ParticleSystem particleEffect;
    // Start is called before the first frame update
    void Start()
    {
        FinalCanvas.gameObject.SetActive(false);
        PlayerRenderer=GetComponent<Renderer>();
rb=GetComponent<Rigidbody>();
       cube=transform;
      cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)){
        moveCube=true;
        Plane newplan=new Plane(Vector3.up,0f);
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(newplan.Raycast(ray,out var distance)){
            mouseStartPos=ray.GetPoint(distance);
            cubeStartPos=cube.position;
        }
       } 
       else if(Input.GetMouseButtonUp(0)){
        moveCube=false;
       }
       if(moveCube){
        Plane newplan=new Plane(Vector3.up,0f);
      Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
       if(newplan.Raycast(ray,out var distance)){
        Vector3 mouseNewpos=ray.GetPoint(distance);
         Vector3 MouseNewpos=mouseNewpos-mouseStartPos;
          Vector3  Dcubepos=MouseNewpos+mouseStartPos;
         Dcubepos.x=Mathf.Clamp(Dcubepos.x,-8f,8f);//lamp in x between two value
          cube.position=new Vector3(Mathf.SmoothDamp(cube.position.x,Dcubepos.x,ref Velocity,Speed),
          cube.position.y,cube.position.z);
       }
       }
       if(CanvasManager.CanvasInstance.state){
 var NewPathpos=path.position;
       path.position=new Vector3(NewPathpos.x,NewPathpos.y,Mathf.MoveTowards(NewPathpos.z,-500f,pathSpeed*Time.deltaTime));
       }
     currentscale= cube.transform.localScale;
     if(currentscale.y<3.10f){
        gameObject.SetActive(false);
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          death.deaths+=1;
     }



    }
    void LateUpdate(){
        var newCampos=cam.transform.position;
        cam.transform.position=new Vector3(Mathf.SmoothDamp(newCampos.x,cube.transform.position.x,ref camVelocity,CamSpeed),
       newCampos.y,newCampos.z );
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("obstacle")){
           gameObject.SetActive(false);//make player invisible
           CanvasManager.CanvasInstance.state=false;
            var ObstacleParticle=Instantiate(particleEffect,transform.position,Quaternion.identity);
           ObstacleParticle.GetComponent<Renderer>().material=cube.GetComponent<Renderer>().material;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             death.deaths+=1;
        }
        // if(other.gameObject.CompareTag("finalRoad")){
        //     rb.isKinematic=true;
        //     pathSpeed=pathSpeed*0.5f;
        // }
        if(other.gameObject.CompareTag("Road")){
           rb.isKinematic=false;
            pathSpeed=30f;
        }
    }
    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Road")){
            rb.isKinematic=false; // make player not drop down (fixed) not dynamic
            rb.velocity=new Vector3(0f,15f,0f);// jump in the air (in Y axis)
        pathSpeed=pathSpeed*2.5f; // path speed *2 (ground is move)
        }
    }
    void OnTriggerEnter(Collider other){
        switch(other.tag){
            case "yellow":
             PlayerRenderer.material=other.GetComponent<Renderer>().material;
            other.gameObject.SetActive(false);
            var ParticleY=Instantiate(particleEffect,transform.position,Quaternion.identity);
           ParticleY.GetComponent<Renderer>().material=other.GetComponent<Renderer>().material;

            break;
            case "green":
             PlayerRenderer.material=other.GetComponent<Renderer>().material;
            other.gameObject.SetActive(false);
             var ParticleG=Instantiate(particleEffect,transform.position,Quaternion.identity);
           ParticleG.GetComponent<Renderer>().material=other.GetComponent<Renderer>().material;
            break;
            case "-1":
 scale = cube.transform.localScale;
scale.y -= 1;
cube.transform.localScale = scale;
 var Particle=Instantiate(particleEffect,transform.position,Quaternion.identity);
           Particle.GetComponent<Renderer>().material=other.GetComponent<Renderer>().material;
            break;
             case "-2":
 scale = cube.transform.localScale;
scale.y -= 2;
cube.transform.localScale = scale;
             break;
              case "+2":
 scale = cube.transform.localScale;
scale.y += 2;
cube.transform.localScale = scale;
             break;
              case "0":
 scale = cube.transform.localScale;
scale.y += 0;
cube.transform.localScale = scale;
             break;

           
        }
       if(other.gameObject.CompareTag("final")){
         gameObject.SetActive(false);
FinalCanvas.gameObject.SetActive(true);
       }

    }
   
}
