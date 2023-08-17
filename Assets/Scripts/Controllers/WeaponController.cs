using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public int weaponType = 1;//1 normal ,2 escopeta


    public float fireRate = 0.5f;

    private void Update()
    {
        bool canShoot = GameState.Instance.canShoot;
        if (!canShoot)
        {
            float elapsedTime = Time.time - GameState.Instance.timeSinceLastShot;
            float fireRatio = fireRate;
            // GetComponent<WeaponController>().fireRate;
            int percentage = (int)((100 * elapsedTime) / fireRatio);
            GameState.Instance.GetFireRatioBar().setWaitFireShot(percentage);

        }

    }
    public void fire()
    {
        bool canShoot = GameState.Instance.canShoot;
        if (weaponType == 1 && canShoot)
        {
            handleWeaponTypeOne();
        }
        if (weaponType == 2 && canShoot)
        {

            handleWeaponTypeTwo();
        }
        if (weaponType == 3 && canShoot)
        {
            handleWeaponTypeThree();
        }



    }

    private void handleWeaponTypeTwo()
    {
        initLogicFire();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = (mousePosition - firePoint.position).normalized;

        float baseAngle = Mathf.Atan2(direccion.y, direccion.x);

        float[] additionalAngles = { -15f, -10f, 0f, 10f, 15f };

        foreach (float angle in additionalAngles)
        {
            float totalAngle = baseAngle + Mathf.Deg2Rad * angle;

            Vector2 modifiedDireccion = new Vector2(Mathf.Cos(totalAngle), Mathf.Sin(totalAngle));

            Debug.Log("" + modifiedDireccion);
            Debug.Log(Mathf.Cos(totalAngle));
            Debug.Log(Mathf.Sin(totalAngle));

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(modifiedDireccion * fireForce, ForceMode2D.Impulse);
        }


    }
    private void handleWeaponTypeOne()
    {

        initLogicFire();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void handleWeaponTypeThree()
    {
        initLogicFire();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = (mousePosition - firePoint.position).normalized;

        float baseAngle = Mathf.Atan2(direccion.y, direccion.x);

        float[] additionalAngles = { 0f, 5f };

        foreach (float angle in additionalAngles)
        {
            float totalAngle = baseAngle + Mathf.Deg2Rad * angle;

            Vector2 modifiedDireccion = new Vector2(Mathf.Cos(totalAngle), Mathf.Sin(totalAngle));

            Debug.Log("" + modifiedDireccion);
            Debug.Log(Mathf.Cos(totalAngle));
            Debug.Log(Mathf.Sin(totalAngle));

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(modifiedDireccion * fireForce, ForceMode2D.Impulse);
        }
    }
    private void initLogicFire()
    {

        GameState.Instance.GetFireRatioBar().setWaitFireShot();
        GameState.Instance.canShoot = false;
        GameState.Instance.timeSinceLastShot = Time.time;

        StartCoroutine(EnableShooting());
    }


    private IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(fireRate);
        GameState.Instance.canShoot = true;
    }



}
