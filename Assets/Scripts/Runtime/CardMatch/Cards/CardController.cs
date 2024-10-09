using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Runtime.CardMatch.Misc;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardController : IInitializable
    {

        private readonly CardModel _cardModel;
        private readonly CardView _cardView;
        private readonly Camera _camera;
        private readonly SignalBus _signalBus;

        private bool _isFlipped;
        public string CardName => _cardView.name;

        public CardController(CardModel cardModel, CardView cardView, Camera camera, SignalBus signalBus)
        {
            _cardModel = cardModel;
            _cardView = cardView;
            _camera = camera;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            Observable.EveryUpdate()
           .Where(_ => Input.GetMouseButtonDown(0))
           .Select(_ => _camera.ScreenToWorldPoint(Input.mousePosition))
           .Subscribe(OnClick)
           .AddTo(_cardView);

            _signalBus.Subscribe<GameOverSignal>(RestartBehaviour);
        }

        public void Flip()
        {
            _isFlipped = !_isFlipped;
        }

        public bool Compare(CardController otherCard)
        {
            if (otherCard == null)
            {
                return false;
            }

            return otherCard.CardName.Equals(CardName);
        }

        public bool Compare(Sprite otherCardSprite)
        {
            return otherCardSprite.name.Equals(_cardView.SpriteRenderer.sprite.name);
        }

        public void MatchCard()
        {
            _cardView.SpriteRenderer.enabled = false;
        }

        private void OnClick(Vector3 clickPosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == _cardView.gameObject && !_isFlipped)
            {
                Debug.Log("Clicked card name: " + _cardView.name);
                Flip();
                _signalBus.Fire(new FlipCardSignal() { cardFlipped = this });
            }
        }

        private void RestartBehaviour(GameOverSignal signal)
        {
            _isFlipped = false;
        }
    }
}