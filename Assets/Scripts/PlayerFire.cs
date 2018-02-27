﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour 
{
    // The player's crosshair
    public GameObject cursor;

    // Bullet to fire
    public GameObject bullet;
    // Where to spawn the bullet
    public GameObject bulletCreationPoint;

    public GameObject testRotater;

    // Stores when the player can next fire their weapon, prevents a million bullets firing at once
    private float nextFire;

    // Script on the main camera with a method that shakes the screen
    public ScreenShaker shaker;

    // Update is called once per frame
    void Update () 
    {
        // Take the distance between the player and the crosshair
        Vector3 difference = cursor.transform.position - gameObject.transform.position;
        // Normalize it, making the the x and y values a value between 0 and 1
        difference.Normalize();

        // Convert the difference to an angle
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        testRotater.transform.rotation = Quaternion.Euler(0, 0, angle);

        // If the player presses the E key,
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            fireWeapon(angle);
        }
	}

    void fireWeapon(float angle)
    {
        // Shoot a bullet at the proper angle
        Instantiate(bullet, bulletCreationPoint.transform.position, Quaternion.Euler(0, 0, angle + Random.Range(-15, 16)));

        // Shake that screen, boye
        shaker.ShakeCamera(2f);

        // Set a delay between the next shot
        nextFire = Time.time + .05f;
    }

}