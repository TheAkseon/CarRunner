using UnityEngine;

public class ConfettiSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _confettiParticle;
    
    private const float _yOffset = 5f;
    
    private float _currentZOffset;
    private float _currentXOffset;
    private float _xOffset;
    private float _zOffset;

    public void SpawnConfetti(Transform playerTransform, int confettiCount)
    {
        Vector3 confettiSpawnPosition = new Vector3(_currentXOffset, _yOffset, _currentZOffset);
        
        for (int i = 0; i < confettiCount; i++)
        {
            CalculateXOffset(i, confettiCount);
            _currentXOffset += _xOffset;
            confettiSpawnPosition.x = _currentXOffset;
            
            if(i == confettiCount - 1)
            {
                confettiSpawnPosition.x = 4.2f;
            }

            _zOffset = CalculateZOffset(i, confettiCount);
            _currentZOffset = _zOffset;
            confettiSpawnPosition.z = playerTransform.position.z + _currentZOffset;

            Instantiate(_confettiParticle, confettiSpawnPosition, Quaternion.identity);
        }
    }
    
    private void CalculateXOffset(int iteration, int confettiCount)
    {
        if (iteration == 0)
        {
            _xOffset = -4.2f;
        }
        else 
        {
            _xOffset = (4.2f / (confettiCount - 1)) * 2;
        }
    }

    private float CalculateZOffset(int iteration, int confettiCount)
    {
        if(iteration == 0 || iteration == confettiCount - 1)
        {
            return 0;
        }
        else
        {
            return 20;
        }
    }
}