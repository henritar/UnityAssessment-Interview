using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Enum;
using static Assets.Scripts.Runtime.CardMatch.Handler.SaveGameStateHandler;

namespace Assets.Scripts.Runtime.CardMatch.Misc
{
    public struct ReturnToMainUISignal
    {
    }
    public struct StartGameSignal
    {
    }
    public struct StartLoadedGameSignal
    {
    }
    public struct SaveScoreComboSignal
    {
        public int score;
        public int combo;
    }
    public struct LoadGameSignal
    {
        public GameInfo gameInfo;
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
    public struct LoadScoreComboSignal
    {
        public int score;
        public int combo;
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
    public struct ToggleSaveButtonSignal
    {
        public bool showButton;
    }
    public struct FlipCardSignal
    {
        public CardController cardFlipped;
    }
    public struct UpdateGridSizeSignal
    {
        public int rowCount;
        public int columnCount;
        public GridSizeModifier modifier;
    }
}