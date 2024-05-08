using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerHandler))]
public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerHandler _playerHandler;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerHandler = GetComponent<PlayerHandler>();
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if (_characterController != null)
        {
            Vector3 playerSpeed = new Vector3(_playerHandler.Horizontal, 0, _playerHandler.Vertical);
            playerSpeed *= Time.deltaTime * _speed;

            if (_characterController.isGrounded)
            {
                _characterController.Move(-playerSpeed + Physics.gravity);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
            }
        }
    }
}
