using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    float _packageDestructionDelay = 0.5f;
    [SerializeField]
    Color32 _hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 _noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer _spriteRenderer;
    bool _hasPackage = false;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Uch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !_hasPackage)
        {
            _hasPackage = true;
            _spriteRenderer.color = _hasPackageColor;
            Destroy(other.gameObject, _packageDestructionDelay);
        }
        
        if (other.tag == "Costumer" && _hasPackage) 
        {
            Debug.Log("Delivery complete!");
            _spriteRenderer.color = _noPackageColor;
            _hasPackage = false;
        }
    }
}
