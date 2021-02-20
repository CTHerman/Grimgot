using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

    // Start is called before the first frame update
    void Start() {
		target = GameObject.Find("DwarfWarrior").transform;
	}

    // Update is called once per frame
    void Update() {
		Vector3 pos = new Vector3(
			target.position.x,
			transform.position.y,
			transform.position.z);
		transform.position = pos;
	}

	public void SetTarget(int dwarf) {
		if(dwarf == 0) {
			target = GameObject.Find("DwarfWarrior").transform;
		} else if(dwarf == 1) {
			target = GameObject.Find("DwarfCraftsman(Clone)").transform;
		} else if (dwarf == 2) {
			target = GameObject.Find("DwarfMage(Clone)").transform;
		}
	}
}
