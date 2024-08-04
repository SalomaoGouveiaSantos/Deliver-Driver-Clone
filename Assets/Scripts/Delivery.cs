using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    private string TAG_PACKAGE = "Package";
    private string TAG_COSTUMER = "Customer";
    private bool hasPackage = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TAG_PACKAGE && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
        }

        if(collision.tag == TAG_COSTUMER && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
