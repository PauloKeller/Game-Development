using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    void LateUpdate()
    {
        transform.position = _player.transform.position + new Vector3(0, 0, -10); 
    }
}
