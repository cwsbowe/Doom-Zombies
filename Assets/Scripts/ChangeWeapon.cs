using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
    public int equippedIndex; //starts at 0
    public int numberOfWeapons = 1;
    public GameObject crosshair;
    public void Unequip() {
        gameObject.transform.GetChild(equippedIndex).gameObject.SetActive(false);
    }

    public void Equip(int index) {
        GetComponent<AudioSource>().Play();
        equippedIndex = index;
        gameObject.transform.GetChild(index).gameObject.SetActive(true);
        if(gameObject.transform.GetChild(index).gameObject.tag == "Gun"){
            crosshair.SetActive(true);
        }else{
            crosshair.SetActive(false);
        }

    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && numberOfWeapons > 1) {
            ChangeWeaponFunction();
        }
    }
    public void ChangeWeaponFunction(){
        Unequip();
        bool changed = false;
        for (int i = equippedIndex + 1; i < gameObject.transform.childCount ; i++) {
            if (gameObject.transform.GetChild(i).GetComponent<BuyWeapon>().owned) {
                print("index:" + i + " - " +gameObject.transform.GetChild(i).name + " "+gameObject.transform.GetChild(i).GetComponent<BuyWeapon>().owned);
                Equip(i);
                 changed = true;
                break;
            }
        }
        if (!changed) {
            Equip(0);
        }
    }
}
