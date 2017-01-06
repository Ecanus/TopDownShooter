﻿using UnityEngine;
using System.Collections;

/// <summary>
/// BulletController class manages bullet behaviour
/// 
/// @author - Dedie K.
/// @version - 0.0.1
/// 
/// 
/// </summary>
/// 
public class Bullet : MonoBehaviour {

	/// <summary>
	/// The player gameobject
	/// </summary>
	private GameObject player;

	/// <summary>
	/// Direction bullet is fired in
	/// </summary>
	private Vector3 fireDirection;

	/// <summary>
	/// Speed at which bullet travels
	/// </summary>
	private float bulletSpeed;

	/// <summary>
	/// Name of quad bullet was fired in
	/// </summary>
	private string quadName;

	/// <summary>
	/// Bullet state of having been fired
	/// </summary>
	public bool isFired;



	/// <summary>
	/// Sets fireDirection and sets isFIred to true
	/// </summary>
	/// 
	/// <param name= "shootDirection"> Vector calculated from player to mouse position. Determines bullet trajectory.</param>
	/// <param name = "firedDomain"> name of quad Bullet was instantiated within </param>
	/// 
	public void fireBullet(Vector3 shootDirection, string firedDomain)
	{
		fireDirection = shootDirection;
		isFired = true;
		quadName = firedDomain;

	}	

	/// <summary>
	/// Destroys bullet
	/// </summary>
	private void destroyBullet()
	{
		if (gameObject.name == "Sprite_Bullet(Clone)") 
		{
			Destroy (gameObject, 2);
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<Enemy>().isShot();
		}

	}

	private void OnTriggerExit(Collider other)
	{
		/* If bullet exits quad it orginated in, reverse x trajectory */
		if ((other.gameObject.name == quadName)) 
		{
			fireDirection.x = (-1) * fireDirection.x;
		}
	}
		

	// Use this for initialization
	void Start () {
		bulletSpeed = 15f;
		player = GameObject.Find ("Sprite_Player");

	}
	
	// Update is called once per frame
	void Update () {

		if (isFired) 
		{
			transform.Translate(fireDirection * Time.deltaTime * bulletSpeed);
		}
	
	}
}
