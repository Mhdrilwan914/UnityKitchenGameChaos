using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameInput _userInput;
    [SerializeField] private LayerMask _layerMask;
    [HideInInspector] public bool IsPlayerMoving { get; private set; }

    private Vector3 lastPlayerPosition;
    private ClearCounter _selectedCounter;

    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than One instance");
        }
        Instance = this;
    }

    public event EventHandler<OnClearCounterInteractionEventArgs> OnClearCounterInteraction;

    public class OnClearCounterInteractionEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }
    private void Start()
    {
        _userInput.OnInteractionPressed += OnIntraction;
    }

    private void OnIntraction(object sender, EventArgs e)
    {

        if (_selectedCounter != null)
        {
            _selectedCounter.Interact();

        }
    }

    private void Update()
    {
        HandlePlayerMovement();
        HandelInteraction();
    }

    private void HandelInteraction()
    {
        var m_Position = _userInput.GetNormailizedInput();

        Vector3 movDir = new(m_Position.x, 0f, m_Position.y);
        if (movDir != Vector3.zero)
        {
            lastPlayerPosition = movDir;
        }
        if (Physics.Raycast(transform.position, lastPlayerPosition, out RaycastHit hitInfo, _layerMask))
        {
            if (hitInfo.transform.gameObject.TryGetComponent(out ClearCounter clearCounter))
            {
                if (clearCounter != _selectedCounter)
                {
                    SeletedCounter(clearCounter);
                }
            }
            else
            {
                SeletedCounter(null);
            }
        }
        else
        {
            SeletedCounter(null);
        }

    }

    private void HandlePlayerMovement()
    {
        var olderTransfrom = transform.position;

        var m_Position = _userInput.GetNormailizedInput();

        Vector3 movDir = new(m_Position.x, 0f, m_Position.y);

        float moveDirection = _moveSpeed * Time.deltaTime;

        float playerSize = 2f;

        float playerRadius = .7f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, movDir, moveDirection);

        if (!canMove)
        {
            Vector3 moveDirX = new(movDir.x, 0f, 0f);

            bool canMoveXaxis = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDirX, moveDirection);

            if (canMoveXaxis)
            {
                transform.position += moveDirX * moveDirection;
            }
            if (!canMoveXaxis)
            {
                Vector3 moveDirZ = new(0f, 0f, movDir.z);

                bool canMoveZaxis = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDirZ, moveDirection);

                if (canMoveZaxis)
                {
                    transform.position += moveDirZ * moveDirection;
                }
            }
        }

        if (canMove)
        {

            transform.position += movDir * moveDirection;
        }

        IsPlayerMoving = transform.position != olderTransfrom;

        transform.forward = Vector3.Slerp(transform.forward, movDir, Time.deltaTime * _rotationSpeed);
    }

    private void SeletedCounter(ClearCounter clearCounter)
    {
        this._selectedCounter = clearCounter;

        OnClearCounterInteraction.Invoke(this, new OnClearCounterInteractionEventArgs
        {
            selectedCounter = _selectedCounter
        });

    }
}
