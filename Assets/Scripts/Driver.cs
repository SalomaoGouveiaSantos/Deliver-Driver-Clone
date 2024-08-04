using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float slowSpeed = 15f;

    private string STR_HORIZONTAL = "Horizontal";
    private string STR_VERTICAL = "Vertical";
    private string TAG_Boost = "Boost";
    private void Start()
    {
        
    }
    private void Update()
    {
        float steerAmount = Input.GetAxis(STR_HORIZONTAL) * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis(STR_VERTICAL) * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TAG_Boost) 
        {
            moveSpeed = boostSpeed;
        }
    }
}
