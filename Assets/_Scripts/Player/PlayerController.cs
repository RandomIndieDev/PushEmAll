using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")] 
    public FloatingJoystick floatingJoystick;

    public Rigidbody rigidbody;

    public GameObject player;
    public Animator animator;

    public GameObject mainWeapon;
    public GameObject weapon;

    [Header("Settings")] 
    public float moveSpeed;


    private bool allowHit;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = weapon.transform.localPosition;
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            var seq = DOTween.Sequence();
            seq.Append(weapon.transform.DOLocalMove(weapon.transform.localPosition + new Vector3(0, 0, 3), .2f));
            seq.Append(weapon.transform.DOLocalMove(originalPos, .2f));

        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

        rigidbody.velocity = direction * moveSpeed * Time.fixedDeltaTime;
        
        
        
        var characterSpeed = Mathf.Clamp(Mathf.Abs(floatingJoystick.Vertical) + Mathf.Abs(floatingJoystick.Horizontal), 0,
            1);
        
        animator.SetFloat("MoveSpeed", characterSpeed);

        if (direction != Vector3.zero)
        {
            player.transform.forward = direction;
        }
    }
}
