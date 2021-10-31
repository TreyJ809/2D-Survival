using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpawnerScript : Spawner {

    protected override void Teleport() {
        float x = (float)((rnd.NextDouble() * 2 * rightBound) - rightBound);
        float y = t.position.y;
        float z = t.position.z;
        t.position = new Vector3(x, y, z);
    }

    protected override void SetBounds() {
        upperBound = 6.5f;
        lowerBound = upperBound;
        rightBound = 14.5f;
        leftBound = -rightBound; ;
    }

    protected override void SetSpawnsFlipX() {
        spawnsFlipX = true;
    }

    protected override void SetDirectionForSpawns() {
        directionForSpawns = new Vector2(0, -1);
    }

}
