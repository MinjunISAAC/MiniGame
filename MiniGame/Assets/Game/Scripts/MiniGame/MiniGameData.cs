
namespace InGame.ForMiniGame.ForData
{
    [System.Serializable]
    public class MiniGameData 
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        public EMiniGameType MiniGameType = EMiniGameType.Unknown;
        public MiniGameBase  MiniGame     = null;
    }
}