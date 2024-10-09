using Assets.Scripts.Runtime.CardMatch.Misc;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    [RequireComponent(typeof(Collider2D))]
    public class CardView : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public SpriteRenderer SpriteRenderer;
        public Sprite CardSprite;
        public SignalBus SignalBus;

        IMemoryPool _pool;

        public void Dispose()
        {
            if (_pool.NumActive < 5)
            {
                _pool.Resize(10);
            }
            SpriteRenderer.enabled = true;
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

        public void SwapSprite()
        {
            SignalBus.Fire(new SwapSpriteSignal() { cardView = this });
        }

        public class Factory : PlaceholderFactory<CardView>
        {
        }

        public class CardViewPool : MonoPoolableMemoryPool<IMemoryPool, CardView>
        {
        }
    }
}