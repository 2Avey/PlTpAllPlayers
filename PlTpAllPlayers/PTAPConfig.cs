using Rocket.API;

namespace PlTpAllPlayers
{
    public class PTAPConfig : IRocketPluginConfiguration
    {
        public uint timeCount;
        public float xPos;
        public float yPos;
        public float zPos;
        public void LoadDefaults()
        {
            timeCount = 30;
            xPos = 0f;
            yPos = 60f;
            zPos = 0f;
        }
    }
}
