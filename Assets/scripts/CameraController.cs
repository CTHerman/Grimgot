using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector2 size; // x and y sizes are 1 less than real room size
	public float speed; //0.1 0.5 (between 0 and 1)

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		Vector3 pos = new Vector3(
			Mathf.RoundToInt(target.position.x / size.x) * size.x,
			Mathf.RoundToInt(target.position.y / size.y) * size.y,
			transform.position.z);
		transform.position = Vector3.Lerp(transform.position, pos, speed);
	}
}
