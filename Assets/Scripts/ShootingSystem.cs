using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private int index = 0;
    private int lastIndex = 0;
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Transform startPointBullet;
    [SerializeField] private Camera cameraMain;


    private void OnEnable()
    {
        InputsManager.OnShoot += Shoot;
        InputsManager.OnSwapWeapon += SwapWeapon;
        InputsManager.OnReload += Reload;
        InputsManager.OnPressNumber += SetWeaponOnIndex;
    }


    private void OnDisable()
    {
        InputsManager.OnShoot -= Shoot;
        InputsManager.OnSwapWeapon -= SwapWeapon;
        InputsManager.OnReload -= Reload;
        InputsManager.OnPressNumber -= SetWeaponOnIndex;
    }


    private void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        SetWeaponOnIndex(index);
    }


    private void Shoot()
        => StartCoroutine(weapons[index].Shoot(startPointBullet, cameraMain));


    private void Reload()
        => StartCoroutine(weapons[index].Reload());


    private void SwapWeapon(float delta)
    {
        if (delta > 0)
        {
            if (index == weapons.Count - 1)
                index = 0;
            else
                index++;
        }
        else if (delta < 0)
        {
            if (index == 0)
                index = weapons.Count - 1;
            else
                index--;
        }
        SetWeaponOnIndex(index);
    }


    public void SetWeaponOnIndex(int index)
    {
        if (index >= weapons.Count)
            return;
        weapons[lastIndex].gameObject.SetActive(false);
        weapons[index].gameObject.SetActive(true);
        lastIndex = index;
    }
}
