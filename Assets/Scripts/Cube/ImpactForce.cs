using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCollection), typeof(Rigidbody), typeof(CollisionDetectorForPointsContainer))]
    public class ImpactForce : MonoBehaviour
    {
        private PointCollection _pointsContainer;
        private Rigidbody _rigidbody;
        private CollisionDetectorForPointsContainer _detector;
        private float _jumpForce = 10; 

        private void Start()
        {
            _pointsContainer = GetComponent<PointCollection>();
            _rigidbody = GetComponent<Rigidbody>();
            _detector = GetComponent<CollisionDetectorForPointsContainer>();
            Subscribe();
        }
        
        private void OnCollisionStart(PointCollection col)
        {
            if (col.points == _pointsContainer.points)
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            
        }

        private void Subscribe()
        {
            _detector.onCollisionStart += OnCollisionStart;
        }

        private void Unsubscribe()
        {
            _detector.onCollisionStart -= OnCollisionStart;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
