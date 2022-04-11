using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using System.Collections;
using System.Collections.Generic;

public class WaterController : MonoBehaviour {
    public SteamVR_Action_Boolean botao = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    public SteamVR_Action_Boolean botaoGrip = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

    [SerializeField] public GameObject earthRect;
    
    [SerializeField] public ParticleSystem water;

    public List<ParticleCollisionEvent> collisionEvents;
    protected bool letPlay = true;

    SteamVR_Behaviour_Pose trackedObj;
    FixedJoint joint = null;

    private void Awake() {
        water.Stop();
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    
    private void Update() {
        //Criar e prende objeto na mão do usuário
        if (joint == null && botao.GetStateDown(trackedObj.inputSource)) {
            if (!water.isPlaying) {
                water.Play();
                // Debug.Log("Start water");
            }
        } else if (joint == null && botao.GetStateUp(trackedObj.inputSource)) {
            Debug.Log("Entrei no else");
            if(water.isPlaying) {
                water.Stop();
                // Debug.Log("Stop water");
            }
        }
        if (joint == null && botaoGrip.GetStateDown(trackedObj.inputSource)) {
            // Instantiate earth
            Debug.Log("UWU earthhhhhh");
            Vector3 pos = transform.position + (transform.forward);
            pos.y = 0;
            Instantiate(earthRect, pos, Quaternion.identity);
            Debug.Log("Instanciei Terra");
        }
    }
}
