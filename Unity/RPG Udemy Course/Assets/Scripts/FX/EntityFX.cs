using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class EntityFX : MonoBehaviour
{
    protected SpriteRenderer sr;

    [Header("Pop Up Text")]
    [SerializeField] private GameObject popUpTextPrefab;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Ailment colors")]
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] shockColor;

    [Header("Ailment particles")]
    [SerializeField] private ParticleSystem igniteFX;
    [SerializeField] private ParticleSystem chillFX;
    [SerializeField] private ParticleSystem shockFX;

    [Header("Hit FX")]
    [SerializeField] private GameObject hitFX;
    [SerializeField] private GameObject criticalHitFX;

    private GameObject myHealthBar;

    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;

        myHealthBar = GetComponentInChildren<HealthBarUI>().gameObject;
    }

    public void CreatePopUpText(string _text)
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(1.5f, 3);
        Vector3 positionOffset = new Vector3(randomX, randomY, 0);

        GameObject newText = Instantiate(popUpTextPrefab, transform.position + positionOffset, Quaternion.identity);

        newText.GetComponent<TextMeshPro>().text = _text;
    }

    public void MakeTransparent(bool isTransparent)
    {
        if (isTransparent)
        {
            sr.color = Color.clear;
            myHealthBar.SetActive(false);
        }
        else
        { 
            sr.color = Color.white;
            myHealthBar.SetActive(true);
        }
    }

    public IEnumerator FlashFX() 
    { 
        sr.material = hitMat;
        Color currentColor = sr.color;

        sr.color = Color.white;
        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    public void RedColorBlink() 
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }
    private void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;

        igniteFX.Stop();
        chillFX.Stop();
        shockFX.Stop();
    }

    public void ChillFxFor(float seconds)
    {
        chillFX.Play();

        InvokeRepeating("ChillColorFx", 0, .3f);
        Invoke("CancelColorChange", seconds);
    }

    public void ShockFxFor(float seconds)
    {
        shockFX.Play();

        InvokeRepeating("ShockColorFx", 0, .3f);
        Invoke("CancelColorChange", seconds);
    }

    public void IgniteFxFor(float seconds)
    {
        igniteFX.Play();

        InvokeRepeating("IgniteColorFx", 0, .3f);
        Invoke("CancelColorChange", seconds);
    }

    private void IgniteColorFx()
    { 
        if (sr.color != igniteColor[0])
            sr.color = igniteColor[0];
        else 
            sr.color = igniteColor[1];
    }

    private void ShockColorFx()
    {
        if (sr.color != shockColor[0])
            sr.color = shockColor[0];
        else
            sr.color = shockColor[1];
    }

    private void ChillColorFx()
    {
        if (sr.color != chillColor[0])
            sr.color = chillColor[0];
        else
            sr.color = chillColor[1];
    }

    public void CreateHitFX(Transform _target, bool _critical)
    {
        float zRotation = Random.Range(-90, 90);
        float xPosition = Random.Range(-.5f, .5f);
        float yPosition = Random.Range(-.5f, .5f);

        Vector3 hitFXRotation = new Vector3(0, 0, zRotation);
        
        GameObject hitPrefab = hitFX;

        if (_critical)
        { 
            hitPrefab = criticalHitFX;
            float yRotation = 0;
            zRotation = Random.Range(-45, 45);

            if (GetComponent<Entity>().facingDir == -1)
            {
                yRotation = 180;
            }

            hitFXRotation = new Vector3(0, yRotation, zRotation);
        }

        GameObject newHitFX = Instantiate(hitPrefab, _target.position + new Vector3(xPosition, yPosition), Quaternion.identity);

        newHitFX.transform.Rotate(hitFXRotation);

        Destroy(newHitFX, .5f);
    }
}
