using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [SerializeField]
    TMPro.TMP_Text mTextOverHead;
    Transform mTransform;
    Transform mTextOverTransform;
    void Awake() {
        mTransform = transform;
        mTextOverTransform =  mTextOverHead.transform;
    }
    void LateUpdate() {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        screenPos.y += 35;
        mTextOverTransform.position = screenPos;
    }
}