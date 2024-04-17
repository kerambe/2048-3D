using ChainCube.Scripts.Cube;
using System.Collections;
using UnityEngine;

namespace ChainCube.Scripts.Utils
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 0.3f;

        [SerializeField] private MergePointsOnCollisionContainer _cubePrefab;

        [SerializeField] private Score _score;

        [SerializeField] private GameObject _swipeDetectorObject;

        private CubeDependencyResolver[] _cubeDependencies;
        
        private ISwipeDetector _swipeDetector;

        private Coroutine _spawnRoutine;
        
        private void Start()
        {
            _swipeDetector = _swipeDetectorObject.GetComponent<ISwipeDetector>();
            _cubeDependencies = FindObjectsOfType<CubeDependencyResolver>();
            Subscribe();
        }

        private void Subscribe()
        {
            _swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void Unsubscribe()
        {
            _swipeDetector.onSwipeEnd -= OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            if (_spawnRoutine == null)
                _spawnRoutine = StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            yield return null;
            yield return new WaitForSeconds(_spawnDelay);
            var instance = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            _score.SetCollisionMergePointsContainer(instance);
            InjectCube(instance.gameObject);
            _spawnRoutine = null;
        }

        private void InjectCube(GameObject cube)
        {
            foreach (var dependency in _cubeDependencies)
            {
                dependency.Cube = cube;
            }
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
