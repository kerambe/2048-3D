using System;
using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    public class CollisionDetectorForPointsContainer : MonoBehaviour
    {
        public event Action<PointCollection> onCollisionStart;
        public event Action<PointCollection> onCollisionContinue;

        private void OnCollisionEnter(Collision col)
        {
            var colContainer = col.gameObject.GetComponent<PointCollection>();

            if (colContainer == null)
                return;
            
            onCollisionStart?.Invoke(colContainer);
            onCollisionContinue?.Invoke(colContainer);
        }
    }
}
