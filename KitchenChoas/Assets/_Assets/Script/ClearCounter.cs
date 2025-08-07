using UnityEngine;

public class ClearCounter : MonoBehaviour
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

                KitchenObject.SetClearCounter(_clearCounter);
                Debug.Log("Clear counter " + KitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact()
    {
        if (KitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSo.Prefab, _counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            KitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            KitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log("Clear counter " + KitchenObject.GetClearCounter());
        }


    }
}
