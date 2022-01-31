using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuses : MonoBehaviour
{
    public float BlockPoints;
    PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerController = other.GetComponent<PlayerController>();
            if (_playerController)
            {
                if (_playerController.CanGetBonus == true)
                {
                    _playerController.ForbidToGetBonus();
                    _playerController.Points += BlockPoints;
                }
            }
        }
    }

}
