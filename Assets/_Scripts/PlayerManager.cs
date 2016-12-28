using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;

    GameObject target;
    float speed;

    void Awake () {
        Instance = this;
    }

    void Start () {
        target = GameManager.Instance.playerFinishGO;
        speed = GameManager.Instance.playerSpeed;
    }

	void Update () {
        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
        }
    }
}
