using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{

    public Enemy enemy;

    public void HasGottenUp()
    {
        enemy.hasGottenUp = true;
    }
}
