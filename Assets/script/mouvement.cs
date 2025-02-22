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
    [SerializeField] private float _modifierAnimTranslation;
    private float _rotationVelocity;
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

void FixedUpdate()
    {
        // calculer et appliquer la translation
        Vector3 mouvement = directionInput;
        float rotation = 0f;
        // si on a une direction d'input
        if (directionInput.magnitude > 0f)
        {
            // calculer rotation cible
            float rotationCible = Vector3.SignedAngle(-Vector3.forward, directionInput, Vector3.up);
            // faire le changement plus graduel avec une interpolation
            rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationCible, ref _rotationVelocity, 0.12f);
            // appliquer la rotation cible directement
            _rb.MoveRotation(Quaternion.Euler(0.0f, rotation, 0.0f));
        }
        // appliquer la vitesse de translation
        _rb.AddForce(mouvement, ForceMode.VelocityChange);

        // calculer un modifiant pour la vitesse d'animation
        Vector3 vitesseSurPlane = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _animator.SetFloat("Vitesse", vitesseSurPlane.magnitude * _modifierAnimTranslation);
        _animator.SetFloat("Deplacement", vitesseSurPlane.magnitude);
    }
}