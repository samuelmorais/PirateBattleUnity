using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PirateBattle.InterfaceAdapters;
public class DamageView : MonoBehaviour
{
    internal int damageLevel = 0;
    [SerializeField]
    internal Sprite[] shipSpritesAccordingToDamage;
    [SerializeField]
    internal SpriteRenderer spriteRenderer;

    internal void UpdateShipDamageLook(){
        if(damageLevel < shipSpritesAccordingToDamage.Length)
            spriteRenderer.sprite = shipSpritesAccordingToDamage[damageLevel];
    }

    internal void DestroyShip() {
        if(GetComponent<HealthUIEnemy>() != null) {
            GetComponent<HealthUIEnemy>().DestroyText();
        }
        Destroy(gameObject);
    }

    internal void PlayAnimationExplosion(){
        EventManager.TriggerEvent("explosion", new Dictionary<string, object> {{"position", transform.position}});
    }

    internal void UpdateShipDamageToDestroyedLook() {
        spriteRenderer.sprite = shipSpritesAccordingToDamage[shipSpritesAccordingToDamage.Length - 1];
    }
}
