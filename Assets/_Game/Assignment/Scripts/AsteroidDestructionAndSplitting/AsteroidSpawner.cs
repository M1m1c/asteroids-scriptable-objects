﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private AsteroidSet _asteroidSet;
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;

        private float _timer;
        private float _nextSpawnTime;
        private Camera _camera;

        //added this function, which is triggered via scriptable event listener
        //Spawns 2 to 3 smaller asteroids offset from the position sent in split data.
        public void SplitAsteroid(SplitData splitData)
        {
            var rand = Random.Range(2, 4);
            for (int i = 0; i < rand; i++)
            {
                var randX = Random.Range(-0.4f, 0.4f);
                var randY = Random.Range(-0.4f, 0.4f);
                var position = splitData.SpawnPos + new Vector3(randX, randY, 0f);
                var spawned = Instantiate(_asteroidPrefab, position, Quaternion.identity);
                spawned.SetSize(splitData.Size);

                if (!_asteroidSet) { continue; }
                _asteroidSet.RegisterAsteroid(spawned);
            }
        }

        private enum SpawnLocation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private void Start()
        {
            _camera = Camera.main;
            Spawn();
            UpdateNextSpawnTime();
        }

        private void Update()
        {
            UpdateTimer();

            if (!ShouldSpawn())
                return;

            Spawn();
            UpdateNextSpawnTime();
            _timer = 0f;
        }

        private void UpdateNextSpawnTime()
        {
            _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private bool ShouldSpawn()
        {
            return _timer >= _nextSpawnTime;
        }

        private void Spawn()
        {
            var amount = Random.Range(_minAmount, _maxAmount + 1);

            for (var i = 0; i < amount; i++)
            {
                var location = GetSpawnLocation();
                var position = GetStartPosition(location);
                var spawned = Instantiate(_asteroidPrefab, position, Quaternion.identity);
                spawned.SetSize();

                if (!_asteroidSet) { continue; }
                _asteroidSet.RegisterAsteroid(spawned);
            }
        }

        private static SpawnLocation GetSpawnLocation()
        {
            var roll = Random.Range(0, 4);

            return roll switch
            {
                1 => SpawnLocation.Bottom,
                2 => SpawnLocation.Left,
                3 => SpawnLocation.Right,
                _ => SpawnLocation.Top
            };
        }

        private Vector3 GetStartPosition(SpawnLocation spawnLocation)
        {
            var pos = new Vector3 { z = Mathf.Abs(_camera.transform.position.z) };

            const float padding = 5f;
            switch (spawnLocation)
            {
                case SpawnLocation.Top:
                    pos.x = Random.Range(0f, Screen.width);
                    pos.y = Screen.height + padding;
                    break;
                case SpawnLocation.Bottom:
                    pos.x = Random.Range(0f, Screen.width);
                    pos.y = 0f - padding;
                    break;
                case SpawnLocation.Left:
                    pos.x = 0f - padding;
                    pos.y = Random.Range(0f, Screen.height);
                    break;
                case SpawnLocation.Right:
                    pos.x = Screen.width - padding;
                    pos.y = Random.Range(0f, Screen.height);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spawnLocation), spawnLocation, null);
            }

            return _camera.ScreenToWorldPoint(pos);
        }
    }
}