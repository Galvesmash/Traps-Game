using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public PlayerSpawn playerSpawn { get; set; }
    public GameObject playerSpawnGO { get; set; }
    public GameObject playerFinishGO { get; set; }

    public List<SawBehavior> sawList { get; set; }
    public List<LaserBehavior> laserList { get; set; }
    public List<SpikesBehavior> spikesList { get; set; }

    [Header ("Player")]
    public float playerSpeed;

    [Header ("Traps")]
    public float timeDeactivated;

    void Awake () {
        Instance = this;

        playerSpawn = FindObjectOfType<PlayerSpawn> ();
        playerSpawnGO = playerSpawn.gameObject;
        playerFinishGO = GameObject.FindGameObjectWithTag ("Finish");
    }

    void Start () {
        sawList = new List<SawBehavior> ();
        laserList = new List<LaserBehavior> ();
        spikesList = new List<SpikesBehavior> ();

        sawList.AddRange (FindObjectsOfType<SawBehavior> ());
        laserList.AddRange (FindObjectsOfType<LaserBehavior> ());
        spikesList.AddRange(FindObjectsOfType<SpikesBehavior> ());
    }
    
	void Update () {
	
	}

    //FUNCTIONS
    public void SawButtonClick () {

    }

    public void LaserButtonClick () {

    }

    public void SpikesButtonClick () {
        foreach (SpikesBehavior sb in spikesList) {
            sb.changeSpikesState (3);
        }
    }
}
