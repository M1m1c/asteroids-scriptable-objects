using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "new AsteroidSet", menuName = "ScriptableObjects/AsteroidSet", order = 0)]
    public class AsteroidSet : ScriptableObject
    {
        private Dictionary<int, Asteroid> _asteroidDict = new Dictionary<int, Asteroid>();

        private void OnEnable()
        {
            _asteroidDict.Clear();
        }

        public Asteroid GetAsteroid(int id)
        {
            return _asteroidDict.ContainsKey(id) ? _asteroidDict[id] : null;
        }

        public void RegisterAsteroid(Asteroid asteroid)
        {
            if (!asteroid) { return; }
            _asteroidDict.Add(asteroid.GetInstanceID(), asteroid);
        }

        public void DestroyAsteroid(Asteroid asteroid)
        {
            if (!asteroid) { return; }

            var id = asteroid.GetInstanceID();
            if (!_asteroidDict.ContainsKey(id)) { return; }

            var asteroidToDestroy = _asteroidDict[id];
            if (!asteroidToDestroy) { return; }

            _asteroidDict.Remove(id);
            Destroy(asteroidToDestroy.gameObject);
        }
    }
}
