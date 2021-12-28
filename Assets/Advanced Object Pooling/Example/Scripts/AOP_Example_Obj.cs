using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AOP_Example_Obj : MonoBehaviour {
    
    private Rigidbody rigidbody;

    private void OnEnable() {
        if(rigidbody == null) 
            rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.AddForce(GenerateRandomVector() * 10.0f);
    }

    private void OnDisable() {
        rigidbody.velocity = Vector3.zero;
    }

    private static Vector3 GenerateRandomVector(){
        return new Vector3(Random.value - .5f, Random.value - .5f, Random.value - .5f);
    }
}