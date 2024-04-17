using ChainCube.Scripts.Cube;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    private MergePointsOnCollisionContainer _collisionMergePointsContainer;
    private long _score;
    private void UpdateScore(long value)
    {
        _score += value;
        _scoreView.UpdateScore(_score);
    }
    public void SetCollisionMergePointsContainer(MergePointsOnCollisionContainer collisionMergePointsContainer)
    {
        _collisionMergePointsContainer = collisionMergePointsContainer;
        _collisionMergePointsContainer.OnMerge += UpdateScore;
    }

}
