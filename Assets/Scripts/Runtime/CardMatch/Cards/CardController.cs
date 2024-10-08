using UnityEngine;
using Zenject;
using UniRx;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardController : IInitializable
    {

        private readonly CardModel _cardModel;
        private readonly CardView _cardView;
        private readonly Camera _camera;

        private bool _isFlipped;

        public CardController(CardModel cardModel, CardView cardView, Camera camera)
        {
            _cardModel = cardModel;
            _cardView = cardView;
            _camera = camera;
        }

        public void Initialize()
        {
            Observable.EveryUpdate()
           .Where(_ => Input.GetMouseButtonDown(0))
           .Select(_ => _camera.ScreenToWorldPoint(Input.mousePosition))
           .Subscribe(OnClick)
           .AddTo(_cardView);
        }

        public void Flip()
        {
            Debug.Log("Clicked card name: " + _cardView.name);
            _isFlipped = !_isFlipped;
        }

        public bool Compare(Sprite otherCardSprite)
        {
            return otherCardSprite.Equals(_cardView.SpriteRenderer.sprite);
        }

        public void Animate()
        {
            throw new System.NotImplementedException();
        }

        private void OnClick(Vector3 clickPosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == _cardView.gameObject)
            {
                Flip();
            }
        }
    }
}