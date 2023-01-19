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

    [SerializeField]
    protected bool isKnockedBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        OnVelocityChange?.Invoke(currentVelocity);
        if (!isKnockedBack)
            rb2D.velocity = currentVelocity * movementDirection.normalized;
    }

    public void KnockBack(Vector2 direction, float power, float duration) {
        if (isKnockedBack)
            return;
        isKnockedBack = true;
        StartCoroutine(KnockBackCoroutine(direction, power, duration));
    }

    private void ResetKnockBack() {
        StopAllCoroutines();
        ResetKnockbackParameters();
    }

    IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration) {
        rb2D.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockbackParameters();
    }

    private void ResetKnockbackParameters() {
        currentVelocity = 0;
        rb2D.velocity = Vector2.zero;
        isKnockedBack = false;
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

    public void StopImmediately() {
        currentVelocity = 0;
        rb2D.velocity = Vector2.zero;
    }
}