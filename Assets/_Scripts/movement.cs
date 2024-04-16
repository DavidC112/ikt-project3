using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.5f;
    private Rigidbody2D rigidb;
    [HideInInspector]
    public Vector2 moveDir;
    public LoadToCombat encounter;
    public Animator animator;
    PlayerInteract vmi;

    private void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManagment();
        Animation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
        

    }

    void Move()
    {
        if (PlayerInteract.conv == false)
        { rigidb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed); }

        if (encounter != null)
        {
            encounter.CheckForEncounters();
        }
    }
    void Animation()
    {
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }
}


