using Newtonsoft.Json;

namespace Training_Center_Task_5.JSONInfo
{
    public class Args
    {
        [JsonProperty("Args")]
        public string Path { get; set; }
        public string RollingInterval { get; set; }
        public string RestrictedToMinimumLevel { get; set; }
    }
}
