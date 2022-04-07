using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterClass : MonoBehaviour {
    public ParticleSystem water;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start() {
        water = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = water.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        Debug.Log("collision detected");
        while (i < numCollisionEvents) {
            if (rb) {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
}
