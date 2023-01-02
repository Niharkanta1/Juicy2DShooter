using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 09:54:45
================================================*/
public class AgentInput : MonoBehaviour {
    private Camera mainCamera;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        GetMovementInput();
        GetPointerInput();
    }

    private void GetPointerInput() {
        // to avoid a bug we need to do these two lines
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = mainCamera.nearClipPlane;

        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

    private void GetMovementInput() {
        OnMovementKeyPressed?.Invoke(movement.action.ReadValue<Vector2>());
    }
}