﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 8;
    public float InteractRange = 3;
    public LayerMask InteractLayer;

    private float _inputMove;

    private Rigidbody2D _rb2D;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Interact();
        _inputMove = Input.GetAxis("Horizontal");

        Vector2 movementVector = new Vector2(_inputMove * Speed, 0);
        _rb2D.velocity = movementVector;
    }

    private void Interact()
    {
        
        var hit = Physics2D.OverlapCircleAll(_rb2D.position, InteractRange, InteractLayer);
        Interactable closest;

        if (hit.Length > 0)
            closest = FindClosest(hit);
        else
            return;

        if (closest != null)
            closest.Interact();
    }

    private Interactable FindClosest(IEnumerable<Collider2D> objects)
    {
        GameObject best = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (Collider2D potential in objects)
        {
            print(potential);
            Vector2 targetVector = potential.transform.position - position;
            float dSqrToTarget = targetVector.sqrMagnitude;
            if (!(dSqrToTarget < closestDistanceSqr)) continue;

            closestDistanceSqr = dSqrToTarget;
            best = potential.gameObject;
        }

        return best.GetComponent<Interactable>();
    }
}