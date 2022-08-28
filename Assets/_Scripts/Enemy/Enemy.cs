using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    public Animator animator;
    public Rigidbody rigidbody;
    public GameObject model;

    public Collider fallenCollider;
    
    [Header("Settings")]
    public float fallMultiplier;

    public float moveSpeed;

    public Transform target;

    public bool hasGottenUp = true;

    private bool isDisabled;

    private EnemyManager enemyManager;

    private void Update()
    {
        if (isDisabled) return;
        
        RotateTowardsPlayer();
    }

    private void FixedUpdate()
    {
        FallFaster();
        
        if (isDisabled) return;
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (!hasGottenUp) return;

        var moveDirection = target.transform.position - transform.position;
        moveDirection = moveDirection.normalized;

        rigidbody.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    private void RotateTowardsPlayer()
    {
        if (!hasGottenUp) return;

        Vector3 lookVector = target.transform.position - transform.position;
        lookVector.y = model.transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, rot, 1);
        
        model.transform.eulerAngles = new Vector3(0,model.transform.eulerAngles.y, 0);
    }
    
    private void FallFaster()
    {
        if (rigidbody.velocity.y <= 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    public void Initialize(Transform targetTrans, EnemyManager manager)
    {
        target = targetTrans;
        enemyManager = manager;
        isDisabled = false;
    }

    public void Disable()
    {
        enemyManager.EnemyDisabled();
        isDisabled = true;
    }
    

    public void GotHit()
    {
        if (!hasGottenUp) return;

        hasGottenUp = false;
        
        animator.SetTrigger("Fall");
    }

    public void HasGottenUp()
    {
        hasGottenUp = true;
    }
}
