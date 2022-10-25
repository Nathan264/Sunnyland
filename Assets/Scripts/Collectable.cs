using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject collectedAnim;
    [SerializeField] private float points;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.Instance.UpdatePoints(points);
            Instantiate(collectedAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
