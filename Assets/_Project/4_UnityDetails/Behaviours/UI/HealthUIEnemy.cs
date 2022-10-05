using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIEnemy : MonoBehaviour
{
    Transform mTransform;
    Transform mTextOverTransform;
    void Awake() {
        mTransform = transform;
    }
    void LateUpdate() {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        screenPos.y += 35;
        mTextOverTransform.position = screenPos;
    }
    public void SetTextTransform(Transform textTransform) {
        mTextOverTransform = textTransform;
    }

    public void SetHealthText(float newHealth) {
        mTextOverTransform.GetComponent<TMPro.TMP_Text>().text = $"Health: {newHealth}";
    }

    public void DestroyText(){
        mTextOverTransform.gameObject.SetActive(false);
        Destroy(mTextOverTransform.gameObject);
    }
}
