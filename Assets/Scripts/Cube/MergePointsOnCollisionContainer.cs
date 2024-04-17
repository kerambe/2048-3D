using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(CollisionDetectorForPointsContainer), typeof(PointCollection))]
    public class MergePointsOnCollisionContainer : MonoBehaviour
    {
        public event Action<long> OnMerge;
        private CollisionDetectorForPointsContainer _detector;
        private PointCollection _pointsContainer;
        private void Start()
        {
            _pointsContainer = GetComponent<PointCollection>();
            _detector = GetComponent<CollisionDetectorForPointsContainer>();
            _detector.onCollisionContinue += OnPointsContainerCollision;
        
        }

        private void OnPointsContainerCollision(PointCollection col)
        {
            if (col.points == _pointsContainer.points)
            {
                Merge();
                _pointsContainer.points *= 2;
                Destroy(col.gameObject);
            }
           
        }

        private void Merge() => OnMerge?.Invoke(_pointsContainer.points / 2);
        private void OnDestroy()
        {
            _detector.onCollisionContinue -= OnPointsContainerCollision;
        }
    }
}
