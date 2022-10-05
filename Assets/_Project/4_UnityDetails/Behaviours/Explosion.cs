using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float secondsToDisappear = 0.5f;
    void Start() {
        StartCoroutine(DestroyAfterXSeconds(secondsToDisappear));
    }

    IEnumerator DestroyAfterXSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
