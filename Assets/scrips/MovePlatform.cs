using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    
    void Start(){

    }

    public float speed = 6f;

    void Update(){
    
        transform.Translate(Vector3.back * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Trigger_DestroyWall")){
            Destroy(gameObject);
        }
    }


}