using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimation;

    private readonly int _isWalkiangAnimHash = Animator.StringToHash("IsWalking");

    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerAnimation = GetComponent<Animator>();
    }


    private void Update()
    {
        _playerAnimation.SetBool(_isWalkiangAnimHash, _playerController.IsPlayerMoving);
    }
}
