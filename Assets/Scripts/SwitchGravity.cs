using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start() {

        rb = GetComponent<Rigidbody2D>();
   }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.gravityScale *= -1;
        }

        else {
            rb.gravityScale = Mathf.Abs(rb.gravityScale);
        }
   }
}
