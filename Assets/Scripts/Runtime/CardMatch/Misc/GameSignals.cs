using Assets.Scripts.Runtime.CardMatch.Cards;

namespace Assets.Scripts.Runtime.CardMatch.Misc
{
    public struct ReturnToMainUISignal
    {
    }
    public struct StartGameSignal
    {
    }
    public struct LoadGameSignal
    {
    }
    public struct SettingsSignal
    {
    }
    public struct QuitGameSignal
    {
    }
    public struct ResetScoreUISignal
    {
    }
    public struct UpdateScoreValueSignal
    {
        public int newValue;
    }
    public struct UpdateComboValueSignal
    {
        public int newValue;
    }
    public struct FlipCardSignal
    {
        public CardController cardFlipped;
    }
}