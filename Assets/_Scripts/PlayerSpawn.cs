using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public GameObject PlayerPrefab;
    Vector3 startPosition;

    void Start () {
        startPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
    }

	void Update () {
        if (PlayerManager.Instance == null) {
            Instantiate (PlayerPrefab, startPosition, Quaternion.identity);
        }
	}
	
}
