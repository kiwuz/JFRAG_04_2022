using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    [SerializeField] private GameObject slot1_panel;
    [SerializeField] private GameObject slot2_panel;
    [SerializeField] private GameObject slot3_panel;
    private Vector3 EquipmentScaled = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 EquipmentNoScaled = new Vector3(1f, 1f, 1f);

    [SerializeField] private GameObject ShootingGun;
    [SerializeField] private GameObject GraplingGun;
    [SerializeField] private GameObject WaveGun;


    [SerializeField] private GameObject ShootingGun_ammo;
    [SerializeField] private GameObject GraplingGun_ammo;
    [SerializeField] private GameObject WaveGun_ammo;
    [SerializeField] private GameObject waveGun_bar;

    void Start()
    {
        GraplingGun.SetActive(true);
        ShootingGun.SetActive(false);
        WaveGun.SetActive(false);

        GraplingGun_ammo.SetActive(true);
        ShootingGun_ammo.SetActive(false);
        WaveGun_ammo.SetActive(false);
        waveGun_bar.SetActive(false);

    }
    void Update()
    {
        ChangeGun();
    }

    void ChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot1_panel.transform.localScale = EquipmentScaled;
            slot2_panel.transform.localScale = EquipmentNoScaled;
            slot3_panel.transform.localScale = EquipmentNoScaled;
            ShootingGun.SetActive(true);
            GraplingGun.SetActive(false);
            WaveGun.SetActive(false);

            ShootingGun_ammo.SetActive(true);
            GraplingGun_ammo.SetActive(false);
            WaveGun_ammo.SetActive(false);
            waveGun_bar.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot2_panel.transform.localScale = EquipmentScaled;
            slot1_panel.transform.localScale = EquipmentNoScaled;
            slot3_panel.transform.localScale = EquipmentNoScaled;
            GraplingGun.SetActive(true);
            ShootingGun.SetActive(false);
            WaveGun.SetActive(false);

            GraplingGun_ammo.SetActive(true);
            ShootingGun_ammo.SetActive(false);
            WaveGun_ammo.SetActive(false);
            waveGun_bar.SetActive(false);


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slot3_panel.transform.localScale = EquipmentScaled;
            slot2_panel.transform.localScale = EquipmentNoScaled;
            slot1_panel.transform.localScale = EquipmentNoScaled;
            WaveGun.SetActive(true);
            GraplingGun.SetActive(false);
            ShootingGun.SetActive(false);

            WaveGun_ammo.SetActive(true);
            GraplingGun_ammo.SetActive(false);
            ShootingGun_ammo.SetActive(false);
            waveGun_bar.SetActive(true);


        }
    }
}
