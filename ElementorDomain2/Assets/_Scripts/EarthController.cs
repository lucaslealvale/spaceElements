using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] public AudioSource isBornSound;

    void Start() {
        rb = GetComponent<Rigidbody>();
        isBornSound.Play();
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Hand")) {
            Vector3 impulse = col.gameObject.transform.forward*6;
            rb.AddForce(impulse, ForceMode.Impulse);
        }
    }

    void Update() {
        if (!insideMap(this.transform.position)) {
            Destroy(this);
        }
         
    }

    private bool insideMap(Vector3 pos) {
        if (pos.x > -28f && pos.x < 28f && pos.z > -28f && pos.z < 28f) 
            return true;

        return false;
        
    }
}