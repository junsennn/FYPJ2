using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class DamagePlayer : MonoBehaviour {

	public FirstPersonController player;

	public Texture lowDamage;
	public Texture medDamage;
	public Texture highDamage;
	public Texture maxDamage;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (player.myHealth <= 95f) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lowDamage);
		}

		if (player.myHealth <= 75f) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), medDamage);
		}

		if (player.myHealth <= 50f) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), highDamage);
			player.m_WalkSpeed = 8f;
			player.m_RunSpeed = 15f;
		}

		if (player.myHealth <= 25f) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), maxDamage);
			player.m_WalkSpeed = 5f;
			player.m_RunSpeed = 8f;
		}
	}
}
