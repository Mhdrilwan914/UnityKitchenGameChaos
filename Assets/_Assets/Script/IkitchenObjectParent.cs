using UnityEngine;

namespace com.feelzgame.kitchenchaos.iKitchenparent
{
    public interface IKitchenObjectParent
    {
        public Transform GetTransformTopPoint();
        public void SetKitchenObject(KitchenObject kitchenObject);
        public KitchenObject GetKitchenObject();
        public void ClearKitchenObject();
        public bool HasKitchenObject();

    }
}

