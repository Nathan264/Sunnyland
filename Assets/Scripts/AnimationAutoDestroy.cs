using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    private void Awake() {
        Destroy(gameObject, timeToDestroy);  
    }
}
