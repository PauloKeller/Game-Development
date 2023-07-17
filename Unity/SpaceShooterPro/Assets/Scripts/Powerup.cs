using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private int _powerupID;
    [SerializeField]
    private AudioClip _powerupAudioClip;


    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_powerupAudioClip, transform.position);
            if (player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.ToggleTripleShotPowerup();
                        break;

                    case 1:
                        player.ToggleSpeedBoostPowerup();
                        break;
                    case 2:
                        player.ToggleShieldPowerup();
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
