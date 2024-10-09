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
    }
    public struct ResetComboValueSignal
    {
    } 
    public struct GameOverSignal
    {
    }
    public struct FlipCardSignal
    {
        public CardController cardFlipped;
    }
}