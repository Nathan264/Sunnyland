using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHeadHit : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject deathAnim;
    [SerializeField] private float points;

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.Instance.UpdatePoints(points);
            Destroy(enemy);  
            Instantiate(deathAnim, transform.position, transform.rotation);
        }
    }
}
