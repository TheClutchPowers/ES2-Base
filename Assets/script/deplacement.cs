using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class deplacement : MonoBehaviour
{
    [SerializeField]private Rigidbody _rb;
    [SerializeField]private Animator _animator;
    [SerializeField]private float movementSpeed = 70f;
    [SerializeField]private Vector2 moveInput;
    [SerializeField]private float modifierAnimTranslation = 1;
    float speedMultiplier = 1;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Deplacement();
    }

    private void Deplacement()
    {
        
        Vector3 moveDir = new Vector3(0,moveInput.y,moveInput.x);
        _rb.AddForce(moveDir * movementSpeed * speedMultiplier);
        Debug.Log(speedMultiplier);
        _animator.SetFloat("Deplacement",moveDir.magnitude * modifierAnimTranslation);
        
    }

    private void OnDash(InputValue value)
    {
        if(value.isPressed){
            speedMultiplier = 2;
            modifierAnimTranslation = 2;
        }
        
        else{
        speedMultiplier = 1;
        modifierAnimTranslation = 1;
        }
    }

    public void OnBouger(InputValue value)
    {
         moveInput = value.Get<Vector2>();
    }
}
