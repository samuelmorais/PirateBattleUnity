using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PirateBattle.InterfaceAdapters;
public class EnemyDamage : DamageView
{
    [SerializeField]
    int maximumDamage = 3;

    void OnTriggerEnter2D(Collider2D col){       
        if(col.tag == "bullet" && col.name == "playerBullet") {
            if(damageLevel < shipSpritesAccordingToDamage.Length) 
            {
                damageLevel++;
                UpdateHealthText();
                Debug.Log("Damage:"+damageLevel+" name:"+gameObject.name+" max:"+maximumDamage);
                if(damageLevel == maximumDamage) {
                    NotifyScoreController();
                    DestroyShip();
                }
                else {
                    UpdateShipDamageLook();
                }
            }
            PlayAnimationExplosion();
            DestroyBullet(col.gameObject);
        }
    }

    void NotifyScoreController() {
        EventManager.TriggerEvent("addPoints", new Dictionary<string, object> { { "ammount", 1 } });
    }

    int GetThisObjectID() {
        return gameObject.GetInstanceID();
    }

    void DestroyBullet(GameObject bullet) {
        Destroy(bullet);
    }

    void UpdateHealthText() {
        var newHealth =  maximumDamage - damageLevel;
        GetComponent<HealthUIEnemy>().SetHealthText(newHealth);
    }

}
