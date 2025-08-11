using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] private ClearCounter _clearCounter;
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        PlayerController.Instance.OnClearCounterInteraction += Player_OnClearCounterInteraction;
    }

    private void Player_OnClearCounterInteraction(object sender, PlayerController.OnClearCounterInteractionEventArgs selectedCounter)
    {
        if (selectedCounter.selectedCounter == _clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }


    }

    private void Show()
    {
        _gameObject.SetActive(true);
    }

    private void Hide()
    {
        _gameObject.SetActive(false);
    }
}
