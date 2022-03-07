using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private string _movingAnimName = "Moving";
    [SerializeField] private string _rotatingAnimName = "Rotating";
    private Animator _animator;
    private PlayerController _controller;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        _animator.SetFloat(_movingAnimName, _controller.SpeedRatio);
        _animator.SetFloat(_rotatingAnimName, _controller.AngleSpeedRatio);
    }
}