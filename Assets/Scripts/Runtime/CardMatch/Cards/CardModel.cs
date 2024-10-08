using UnityEngine;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardModel
    {
        public int ID;
        public Sprite Sprite;

        public CardModel(int id, Sprite sprite)
        {
            ID = id;
            Sprite = sprite;
        }
    }
}