using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : DamageView
{
    [SerializeField]
    int maximumDamage = 3;
    bool isDestroyed = false;
    
    void OnTriggerEnter2D(Collider2D col){ 
        if(isDestroyed) return;       
        if(col.tag == "bullet" && col.name == "enemyBullet") {
            SufferDamage();
            DestroyBullet(col.gameObject);
        }
        else if(
            (col.name.StartsWith("ChaserShip") &&
            col.GetComponent<EnemyMove>().IsChaser())
            ||
            (col.transform.parent != null &&
            col.transform.parent.name.StartsWith("ChaserShip"))
        ) {
            SufferDamage();
            if(col.transform.parent != null){
                DestroyEnemyShip(col.transform.parent.gameObject);
            }
            else if(col.name.StartsWith("ChaserShip")){
                DestroyEnemyShip(col.gameObject);
            }
        }
    }

    void SufferDamage() {
        if(isDestroyed) return;
        NotifyHealthUpdate();
        if(damageLevel < shipSpritesAccordingToDamage.Length) 
            {
                damageLevel++;
                if(damageLevel == maximumDamage) {
                    DestroyPlayerShip();
                }
                else {
                    UpdateShipDamageLook();
                }
            }
        PlayAnimationExplosion();
    }

    void DestroyBullet(GameObject bullet) {
        bullet.SetActive(false);
        Destroy(bullet);
    }

    void DestroyEnemyShip(GameObject ship) {        
        if(ship.GetComponent<HealthUIEnemy>() != null) {
            ship.GetComponent<HealthUIEnemy>().DestroyText();
        }
        ship.SetActive(false);
       // Destroy(ship);
    }

    void DestroyPlayerShip() {
        if(isDestroyed) return;
        EventManager.TriggerEvent("playerShipDestroyed", new Dictionary<string, object> { { "playerShipDestroyed", 1 } });;
        isDestroyed = true;
        UpdateShipDamageToDestroyedLook();
    }

    void NotifyHealthUpdate() {
        var newHealth =  maximumDamage - damageLevel - 1;
        if(newHealth <= 0) {
            newHealth = 0;
            DestroyPlayerShip();
        }
        Debug.Log("Health damage!!" + newHealth);
        EventManager.TriggerEvent("updateHealth", new Dictionary<string, object> { { "newHealth", newHealth } });
    }
}
