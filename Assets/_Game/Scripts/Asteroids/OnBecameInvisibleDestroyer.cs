using UnityEngine;

namespace Asteroids
{
    public class OnBecameInvisibleDestroyer : MonoBehaviour
    {
        [SerializeField] private AsteroidSet _asteroidSet;
        [SerializeField] private GameObject _toDestroy;

        private void OnBecameInvisible()
        {
            if (_asteroidSet)
            {
                var asteroid = _toDestroy.GetComponent<Asteroid>();
                if (asteroid) 
                {
                    _asteroidSet.DestroyAsteroid(asteroid);
                }
            }

            if (!_toDestroy) { return; }
            Destroy(_toDestroy);
        }
    }
}