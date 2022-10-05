using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PirateBattle.Shared;
public class PlayerShootInput : Shooter
{
    float lastShootTime = 0;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!IsShootTimeOK()) {
                ShootFrontal();
                UpdateShootTime(); 
            }
        }
        if(Input.GetKeyDown(KeyCode.L)){
            if(!IsShootTimeOK()){
                ShootLateral();  
                UpdateShootTime(); 
            }           
        }
    }

    void UpdateShootTime() {
        lastShootTime = Time.time;
    }

    bool IsShootTimeOK() {
        return Time.time > lastShootTime + 0.25f;
    }
}
