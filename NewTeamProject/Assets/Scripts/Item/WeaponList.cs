﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveWeapon(string WeaponName)
    {
        transform.Find(WeaponName).gameObject.SetActive(true);
    }
    public void InactiveWeapon(string WeaponName)
    {
        transform.Find(WeaponName).gameObject.SetActive(false);
    }
}
