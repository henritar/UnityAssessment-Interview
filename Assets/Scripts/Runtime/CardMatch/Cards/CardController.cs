using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardController : IInitializable
    {

        private readonly CardModel _cardModel;
        private readonly CardView _cardView;

        public CardController(CardModel cardModel, CardView cardView)
        {
            _cardModel = cardModel;
            _cardView = cardView;
        }

        public void Initialize()
        {
          
        }

        public void Flip()
        {
            throw new System.NotImplementedException();
        }

        public bool Compare(Sprite otherCardSprite)
        {
            return otherCardSprite.Equals(_cardView.SpriteRenderer.sprite);
        }

        public void Animate()
        {
            throw new System.NotImplementedException();
        }
    }
}