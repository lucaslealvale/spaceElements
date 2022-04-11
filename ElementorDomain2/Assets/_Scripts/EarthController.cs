using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour {

    void Start() {
        
    }

    private void OnTriggerEnter(Collider col) {
        Debug.Log(col.tag);
    }

    void Update() {
        
    }
}
