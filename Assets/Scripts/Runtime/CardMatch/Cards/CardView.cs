﻿using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardView : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        IMemoryPool _pool;

        public void Dispose()
        {
            if (_pool.NumActive < 5)
            {
                _pool.Resize(10);
            }
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public class Factory : PlaceholderFactory<CardView>
        {
        }

        public class CardViewPool : MonoPoolableMemoryPool<IMemoryPool, CardView>
        {
        }
    }
}