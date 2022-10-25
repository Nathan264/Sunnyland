using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  EnemyController : MonoBehaviour
{
    [SerializeField] protected float speed = -4f;
    [SerializeField] protected float timeToTurn = 1f;
    protected Rigidbody2D rig;
    protected Animator anim;

    protected virtual void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(Turn());
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move() {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    protected virtual void Switch() {}

    protected IEnumerator Turn() {
        while (true) {
            Switch();
            yield return new WaitForSeconds(timeToTurn);
        }
    }

}
