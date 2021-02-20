using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour {

	public int sceneIndex;
	bool areaComplete;
	public GameManager gm;
	public int totalCitizensToExit;
	public int totalGoblinsToExit;
	public int totalActiveDwarvesToExit;
	private bool dwarfWarriorInZone;
	private bool dwarfCraftsmanInZone;
	private bool dwarfMageInZone;

	//CanvasController cc;

	private void Awake() {
		//cc = FindObjectOfType<GameCanvasController>();
		gm = FindObjectOfType<GameManager>();
	}

	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (AllConditionsMet() && Input.GetKeyDown(KeyCode.Return)) {
			GoToScene(sceneIndex);
		} else if (!AllConditionsMet() && Input.GetKeyDown(KeyCode.Return)) {
			AudioManager.Play(10);
		}
	}

	void GoToScene(int sceneIndex) {
		//cc.SetDialogPanelActive(false);
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneIndex);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name.Equals("DwarfWarrior")) {
			dwarfWarriorInZone = true;
			IndicateLevelComplete();
		}
		if (collision.gameObject.name.Equals("DwarfCraftsman(Clone)")) {
			dwarfCraftsmanInZone = true;
			IndicateLevelComplete();
		}
		if (collision.gameObject.name.Equals("DwarfMage(Clone)")) {
			dwarfMageInZone = true;
			IndicateLevelComplete();
		}

	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.name.Equals("DwarfWarrior")) {
			dwarfWarriorInZone = false;
		}
		if (collision.gameObject.name.Equals("DwarfCraftsman(Clone)")) {
			dwarfCraftsmanInZone = false;
		}
		if (collision.gameObject.name.Equals("DwarfMage(Clone)")) {
			dwarfMageInZone = false;
		}
	}

	private bool DwarfConditionsComplete() {
		return (totalActiveDwarvesToExit == 1 && dwarfWarriorInZone)
			|| (totalActiveDwarvesToExit == 2 && dwarfWarriorInZone && dwarfCraftsmanInZone)
			|| (totalActiveDwarvesToExit == 3 && dwarfWarriorInZone && dwarfCraftsmanInZone && dwarfMageInZone);
	}

	private bool CitizenAndGoblinConditionsComplete() {
		return (gm.defeatedEnemys == totalGoblinsToExit)
			&& (gm.savedCitizens == totalCitizensToExit);
	}

	private bool AllConditionsMet() {
		return DwarfConditionsComplete() && CitizenAndGoblinConditionsComplete();
	}

	private void IndicateLevelComplete() {
		if (AllConditionsMet()) {
			AudioManager.Play(13);
		}
	}
}
