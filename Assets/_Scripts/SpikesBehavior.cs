using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior: MonoBehaviour {

    public List <SpriteRenderer> sprites;

    public enum trapStates {
        HIDDEN = 0,
        ACTIVE = 1,
        IDLE = 2
    }
    public trapStates spikeStates;

    void Start () {
        //sprites = new List<SpriteRenderer> ();
        changeSpikesState (0);
    }

    void Update () {

    }

    void changeSpikesState(int status) {
        switch (status) {
            case 0:
                Debug.Log ("HIDDEN");
                spikeStates = trapStates.HIDDEN;
                changeSpritesAlpha (0f);
                break;
            case 1:
                Debug.Log ("ACTIVE");
                spikeStates = trapStates.ACTIVE;
                changeSpritesAlpha (1f);
                Invoke ("hideSpikes", 2);
                Debug.Log ("invoked");
                break;
            case 2:
                Debug.Log ("IDLE");
                spikeStates = trapStates.IDLE;
                changeSpritesAlpha (0.4f);
                break;
            default:
                break;
        }
    }
    void hideSpikes () {
        changeSpikesState (2);
    }

    void changeSpritesAlpha(float _a) {
        foreach (SpriteRenderer sr in sprites) {
            Color tmp = sr.color;
            tmp.a = _a;
            sr.color = tmp;
            //sr.color = new Color (255, 255, 255, _a);
        }
    }

    void OnTriggerEnter2D (Collider2D coll) {
        Debug.Log ("collider");
        if (coll.tag == "Player") {
            if (spikeStates == trapStates.HIDDEN || spikeStates == trapStates.IDLE) {
                changeSpikesState (1);
            }
        }
    }
}
