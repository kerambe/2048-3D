﻿using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCollection))]
    public class RandomPointsGenerator : MonoBehaviour
    {
        [SerializeField] private byte _minDegree = 1;

        [SerializeField] private byte _maxDegree = 4;
        
        private PointCollection _pointsContainer;

        private const byte defaultMinDegree = 1;
        private const byte defaultMaxDegree = 4;

        private void Start()
        {
            NormalizeDegree();
            _pointsContainer = GetComponent<PointCollection>();
            _pointsContainer.points = (int)Mathf.Pow(2, Random.Range(_minDegree, _maxDegree));
        }

        private void NormalizeDegree()
        {
            if (_maxDegree > _minDegree) return;
            
            _minDegree = defaultMinDegree;
            _maxDegree = defaultMaxDegree;
        }
    }
}
