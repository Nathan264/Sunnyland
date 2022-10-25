using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : EnemyController
{
    private void OpossumTurn() {
        this.speed *= -1;

        if (speed < 0) {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f); 
        }
        else if (speed > 0) {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f); 
        }
    }

    protected override void Switch() {
        OpossumTurn();
    } 

    
}
