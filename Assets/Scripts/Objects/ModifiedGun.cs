using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedGun : MonoBehaviour
{
    // Start is called before the first frame update
    public int weaponType = 1;
    public float fireRate = 0.5f;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        bool isPlayer = other.gameObject.tag == "Player";
        if (isPlayer)
        {
            other.gameObject.GetComponentInChildren<WeaponController>().weaponType = weaponType;
            other.gameObject.GetComponentInChildren<WeaponController>().fireRate = fireRate;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
