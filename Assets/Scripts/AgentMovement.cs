using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 10:05:49
================================================*/
[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour {

    protected Rigidbody2D rb2D;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }
    [SerializeField]
    protected float currentVelocity = 3f;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        OnVelocityChange?.Invoke(currentVelocity);
        rb2D.velocity = currentVelocity * movementDirection.normalized;
    }

    public void MoveAgent(Vector2 movementInput) {
        //rb2D.velocity = movementInput.normalized * currentVelocity;

        if (movementInput.magnitude > 0) {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                currentVelocity = 0;
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput) {
        if(movementInput.magnitude > 0) {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        } else {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }
}