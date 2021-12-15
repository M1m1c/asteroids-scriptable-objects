using DefaultNamespace.ScriptableEvents;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] private ScriptableEventSplitData _OnAsteroidSplit;
        [SerializeField] private AsteroidSet _asteroidSet;
        public void OnAsteroidHitByLaser(int asteroidId)
        {
            if (!_asteroidSet) { return; }

            var hitAsteroid = _asteroidSet.GetAsteroid(asteroidId);
            if (!hitAsteroid) { return; }
            // Get the asteroid
            var size = hitAsteroid.GetSize();
            if (size > 0.3)
            {
                //Split asteroid by spawning two new ones with half the size
                if (_OnAsteroidSplit) 
                {
                    var destroyPos = hitAsteroid.transform.position;
                    _OnAsteroidSplit.Raise(new SplitData(destroyPos, size));
                }
            }

            _asteroidSet.DestroyAsteroid(hitAsteroid);



            // Check if big or small

            // if small enough, we Destoy

            // if it's big, we split it up.
        }

    }
}
