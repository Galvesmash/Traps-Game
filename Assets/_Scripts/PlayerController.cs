using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;

    GameObject target;
    float speed;

    void Awake () {
        Instance = this;
    }

    void Start () {
        target = GameController.Instance.playerFinishGO;
        speed = GameController.Instance.playerSpeed;
    }

	void Update () {
        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
        }
    }
}
