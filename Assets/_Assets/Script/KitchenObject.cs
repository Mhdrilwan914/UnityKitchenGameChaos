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
        _clearCounter = clearCounter;
        transform.parent = clearCounter.GetTransformTopPoint();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return _clearCounter;
    }
}
