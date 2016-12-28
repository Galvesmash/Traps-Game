using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior: MonoBehaviour {

    public List <SpriteRenderer> sprites;

    public enum trapStates {
        HIDDEN = 0,
        IDLE = 1,
        ACTIVE = 2,
        DEACTIVE = 3
    }
    public trapStates spikeStates;
    int stateStateBefore = 0;

    void Start () {
        //sprites = new List<SpriteRenderer> ();
        changeSpikesState (0);
    }
    
    public void changeSpikesState(int status) {
        switch (status) {
            case 0:
                Debug.Log ("Spikes: HIDDEN");
                spikeStates = trapStates.HIDDEN;
                changeSpritesAlpha (0f);
                break;
            case 1:
                Debug.Log ("Spikes: IDLE");
                spikeStates = trapStates.IDLE;
                changeSpritesAlpha (0.4f);
                break;
            case 2:
                Debug.Log ("Spikes: ACTIVE");
                spikeStates = trapStates.ACTIVE;
                changeSpritesAlpha (1f);
                Invoke ("hideSpikes", 2);
                Debug.Log ("invoked");
                break;
            case 3:
                Debug.Log ("Spikes: DEACTIVE");
                if (spikeStates == trapStates.IDLE || spikeStates == trapStates.ACTIVE) {
                    stateStateBefore = 1;
                }
                spikeStates = trapStates.DEACTIVE;

                if (stateStateBefore == 1) {
                    changeSpritesAlpha (0.4f);
                } else {
                    changeSpritesAlpha (0f);
                }

                Invoke ("reactiveSpikes", GameManager.Instance.timeDeactivated);
                break;
            default:
                break;
        }
    }
    void hideSpikes () {
        changeSpikesState (1);
    }

    void reactiveSpikes () {
        changeSpikesState (stateStateBefore);
    }

    void changeSpritesAlpha(float _a) {
        //TODO change animation
        //Change alpha
        foreach (SpriteRenderer sr in sprites) {
            Color tmp = sr.color;
            tmp.a = _a;
            sr.color = tmp;
        }
    }

    void OnTriggerEnter2D (Collider2D coll) {
        if (coll.tag == "Player") {
            if (spikeStates != trapStates.DEACTIVE && (spikeStates == trapStates.HIDDEN || spikeStates == trapStates.IDLE)) {
                changeSpikesState (2);
            }
        }
    }
}
