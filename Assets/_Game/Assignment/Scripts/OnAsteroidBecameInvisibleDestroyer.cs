using UnityEngine;

namespace Asteroids
{
    public class OnAsteroidBecameInvisibleDestroyer : MonoBehaviour
    {
        [SerializeField] private AsteroidSet _asteroidSet;
        [SerializeField] private GameObject _toDestroy;

        //calls DestroyAsteroid in asteriod set if this asteroid is in there.
        //Otherwise just destroyes it.
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