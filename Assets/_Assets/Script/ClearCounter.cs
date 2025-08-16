using com.feelzgame.kitchenchaos;
using com.feelzgame.kitchenchaos.iKitchenparent;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private ClearCounter _clearCounter;
    public bool IsTesting;

    private KitchenObject KitchenObject;


    private void Update()
    {
        if (IsTesting && Input.GetKeyDown(KeyCode.T))
        {
            if (KitchenObject != null)
            {
                KitchenObject.SetKitchenObjectParent(_clearCounter);
                //Debug.Log("Clear counter " + KitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact(PlayerController player)
    {
        if (KitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSo.Prefab, _counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            KitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            KitchenObject.SetKitchenObjectParent(this);
        }
        else
        {
           // KitchenObject.SetKitchenObjectParent(this);
        }


    }

    public Transform GetTransformTopPoint()
    {
        return _counterTopPoint;
    }


    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        KitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }

    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return (KitchenObject != null);
    }
}
