using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardController : IInitializable
    {

        private readonly CardModel _cardModel;
        private readonly CardView _cardView;

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Flip()
        {
            throw new System.NotImplementedException();
        }

        public bool Compare(int otherCardID)
        {
            return otherCardID.Equals(_cardModel.ID);
        }

        public void Animate()
        {
            throw new System.NotImplementedException();
        }
    }
}