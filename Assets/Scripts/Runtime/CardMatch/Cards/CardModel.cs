using Assets.Scripts.Runtime.CardMatch.Installers;
using UnityEngine;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardModel
    {
        public int ID;
        public Sprite Sprite;

        public CardModel(MainSceneInstaller.CardType cardType)
        {
            ID = cardType.CardId;
            Sprite = cardType.CardSprite;
        }
    }
}