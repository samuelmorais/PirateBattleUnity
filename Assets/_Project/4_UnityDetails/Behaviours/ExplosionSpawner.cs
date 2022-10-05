using UnityEngine;
using System.Collections.Generic; 
public class ExplosionSpawner : MonoBehaviour {
    [SerializeField]
    GameObject explosionPrefab;
    
    void OnEnable() {
        EventManager.StartListening("explosion", OnExplosion);
    }

    void OnDisable() {
        EventManager.StopListening("explosion", OnExplosion);
    }
    
    void OnExplosion(Dictionary<string, object> message) {
        var position = (Vector3) message["position"];
        var explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
    }
}
