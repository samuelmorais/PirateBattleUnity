using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PirateBattle.Shared;
public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject playerShipBullet;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    Transform[] attackPointsLateral;

    float lastShootTime = 0;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            ShootFrontal();
        }
        if(Input.GetKeyDown(KeyCode.L)){
            ShootLateral();            
        }
    }

    void UpdateShootTime() {
        lastShootTime = Time.time;
    }

    internal void ShootFrontal() {
        if(!IsShootTimeOK()) return;        
        UpdateShootTime();        
        GameObject newBullet = Instantiate(playerShipBullet, attackPoint.position, Quaternion.identity);
        ChangeBulletName(newBullet);
        FixDirectionOfBullet(newBullet);
        SetDirection(newBullet, Constants.FRONTAL_DIRECTION);
    }

    internal void ShootLateral(){
        if(!IsShootTimeOK()) return;
        UpdateShootTime();
        for(var i = 0; i < attackPointsLateral.Length * 2; i++){
            GameObject newBullet = Instantiate(playerShipBullet, attackPointsLateral[i % attackPointsLateral.Length].position, Quaternion.identity);
            ChangeBulletName(newBullet);
            FixDirectionOfBullet(newBullet);  
            SetDirection(newBullet, i >=3 ? Constants.RIGHT_DIRECTION : Constants.LEFT_DIRECTION);
        }            
    }

    void ChangeBulletName(GameObject bullet) {
        bullet.tag = "bullet";
        if(gameObject.name == "PlayerShip") bullet.name = "playerBullet";
        else bullet.name = "enemyBullet";
    }

    bool IsShootTimeOK() {
        return Time.time > lastShootTime + 0.25f;
    }

    void FixDirectionOfBullet(GameObject newBullet){
        newBullet.transform.right = transform.right.normalized;
    }

    void SetDirection(GameObject newBullet, int direction){
        newBullet.GetComponent<Bullet>().SetDirection(direction);
    }
}
