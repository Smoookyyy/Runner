using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Damage;
    PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag=="Player")
       {
            _playerController = other.GetComponent<PlayerController>();
            if (_playerController)
            {
                if (_playerController.CanBeDamage==true)
                {
                    Debug.Log("апчхи");
                    _playerController.Points-= Damage;
                    _playerController.ForbidToDamage();
                }
            }
       }
    }

}
