using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;

public class FireController : MonoBehaviour {
    public SteamVR_Action_Boolean botao = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    [SerializeField] public ParticleSystem fuego;
    protected bool letPlay = true;

    SteamVR_Behaviour_Pose trackedObj;
    FixedJoint joint = null;

    private void Awake() {
        fuego.Stop();
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update() {
        //Criar e prende objeto na mão do usuário
        if (joint == null && botao.GetStateDown(trackedObj.inputSource)) {
            if (!fuego.isPlaying) {
                fuego.Play();
                Debug.Log("Start fuego");
            }
        } else if (joint == null && botao.GetStateUp(trackedObj.inputSource)) {
            Debug.Log("Entrei no else");
            if(fuego.isPlaying) {
                fuego.Stop();
                Debug.Log("Stop fuego");
            }
        }
    }
}
