using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public LayerMask interactablesLayer;

    Vector2 movement;

    public LayerMask solidObjectsLayer;

    // Update is called once per frame
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }


     void Interact()
     {
        var facingDir = new Vector3(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 0.4f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactablesLayer);
        if (collider != null)
        {
            Debug.Log("NPC here");
        }
     }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
   

}
