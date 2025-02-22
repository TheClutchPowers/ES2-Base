using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Windows;

public class mouvement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    [SerializeField] private float _vitessePromenade;
    private Vector3 directionInput;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
         _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBouger (InputValue directionBase) {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade;
        directionInput = new Vector3(directionAvecVitesse.x, 0f, directionAvecVitesse.y);
    }
}
