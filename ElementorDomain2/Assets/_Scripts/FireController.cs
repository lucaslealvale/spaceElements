using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.Extras;
using Valve.VR;

public class FireController : MonoBehaviour {
    public SteamVR_Action_Boolean botao = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    public SteamVR_Action_Boolean botaoGrip = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    [SerializeField] public ParticleSystem fuego;
    protected bool letPlay = true;

    SteamVR_Behaviour_Pose trackedObj;
    [SerializeField] public GameObject earthRect;
    private AudioSource fireSound;
    FixedJoint joint = null;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Awake() {
        fuego.Stop();
        fireSound = GetComponent<AudioSource>();
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void Update() {
        //Criar e prende objeto na mão do usuário
        if (joint == null && botao.GetStateDown(trackedObj.inputSource)) {
            if (!fuego.isPlaying) {
                fireSound.Play();
                fuego.Play();
            }
        } else if (joint == null && botao.GetStateUp(trackedObj.inputSource)) {
            if(fuego.isPlaying) {
                fireSound.Stop();
                fuego.Stop();
            }
        }

        if (joint == null && botaoGrip.GetStateDown(trackedObj.inputSource)) {
            Vector3 pos = transform.position + 1.5f*(transform.forward);
            pos.y = 0;
            Instantiate(earthRect, pos, Quaternion.identity);
        }
    }
}
