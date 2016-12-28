using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public PlayerSpawn playerSpawn { get; set; }
    public GameObject playerSpawnGO { get; set; }
    public GameObject playerFinishGO { get; set; }

    public float playerSpeed;

    void Awake () {
        Instance = this;

        playerSpawn = FindObjectOfType<PlayerSpawn> ();
        playerSpawnGO = playerSpawn.gameObject;
        playerFinishGO = GameObject.FindGameObjectWithTag ("Finish");
    }

    void Start () {

    }
    
	void Update () {
	
	}

    //FUNCTIONS
    public void SawButtonClick () {

    }

    public void LaserButtonClick () {

    }

    public void SpikesButtonClick () {

    }
}
