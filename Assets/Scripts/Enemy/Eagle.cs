using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : EnemyController
{
    protected override void Move() {
        transform.position += Vector3.up * speed * Time.deltaTime; 
    }

    private void EagleTurn() {
        this.speed *= -1;
    }

    protected override void Switch() {
        EagleTurn();
    }
}
