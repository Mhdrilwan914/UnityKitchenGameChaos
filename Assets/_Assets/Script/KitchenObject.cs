using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter _clearCounter;
    public KitchenObjectSO GetKitchenObject()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this._clearCounter != null)
        {
            _clearCounter.ClearKitchenObject();
        }

        this._clearCounter = clearCounter;
        if (clearCounter.HasKitchenObject())
        {
            Debug.Log("clear Counter already has the kitchen object");
        }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetTransformTopPoint();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return _clearCounter;
    }
}
