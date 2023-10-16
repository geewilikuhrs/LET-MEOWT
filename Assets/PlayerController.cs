using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    Vector2 lastPos;
    bool moving;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        animateMovement();
        if (moving && (Vector2)transform.position != lastPos) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastPos, step);
        } else {
            moving = false;
        }
        
    }
    void animateMovement() {
        if (animator != null) {
            if(moving) {
                animator.SetBool("isMoving", true);
            } else {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
