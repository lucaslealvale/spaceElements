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
    private AudioSource waterSound;

    SteamVR_Behaviour_Pose trackedObj;
    FixedJoint joint = null;

    private void Awake() {
        water.Stop();
        waterSound = GetComponent<AudioSource>();
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    
    private void Update() {
        //Criar e prende objeto na mão do usuário
        if (joint == null && botao.GetStateDown(trackedObj.inputSource)) {
            if (!water.isPlaying) {
                water.Play();
                waterSound.Play();
            }
        } else if (joint == null && botao.GetStateUp(trackedObj.inputSource)) {
            Debug.Log("Entrei no else");
            if(water.isPlaying) {
                water.Stop();
                waterSound.Stop();
            }
        }
        if (joint == null && botaoGrip.GetStateDown(trackedObj.inputSource)) {
            Vector3 pos = transform.position + 1.5f*(transform.forward);
            pos.y = 0;
            Instantiate(earthRect, pos, Quaternion.identity);
        }
    }
}
