using System.Text;

namespace Training_Website
{

    public class VideoMaterial : TrainingMaterial, IVersionable
    {
        private string videoContentURI = string.Empty;
        private string splashScreenURI = string.Empty;
        private EnumVideoFormats videoFormat;
        private int[] version;


        public VideoMaterial(string textDescription, string videoContentURI, string spashScreenURI, EnumVideoFormats videoFormat) : base(textDescription)
        {
            MyGuid = base.MyGuid;
            this.VideoContentURI = videoContentURI;
            this.SplashScreenURI = splashScreenURI;
            this.VideoFormat = videoFormat;
            this.Version = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
        }

        public string VideoContentURI
        {
            get
            {
                return this.videoContentURI;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyVideoURI);
                }
                this.videoContentURI = value;
            }
        }

        public string SplashScreenURI { get; set; }
        public EnumVideoFormats VideoFormat { get; set; }

        public byte[] Version { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Video material description: ");
            sb.Append(base.TextDescription);
            return sb.ToString();
        }

        public void UpdateVersion(byte[] version)
        {
            Array.Copy(version, Version, 8);
        }
    }
}
