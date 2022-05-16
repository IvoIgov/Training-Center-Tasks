using System.Text;

namespace Training_Website
{

    public class VideoMaterial : TrainingMaterial, IVersionable
    {
        private string videoContentURI = string.Empty;
        private string splashScreenURI = string.Empty;
        private EnumVideoFormats videoFormat;
        private byte[] version = { 0, 0, 0, 0, 0, 0, 0, 1 };


        public VideoMaterial(string textDescription, string videoContentURI, string spashScreenURI, EnumVideoFormats videoFormat) : base(textDescription)
        {
            MyGuid = base.MyGuid;
            this.VideoContentURI = videoContentURI;
            this.SplashScreenURI = splashScreenURI;
            this.VideoFormat = videoFormat;
            this.Version = this.version;
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

        /// <summary>
        /// Returns a description of Video lesson
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Video material description: ");
            sb.Append(base.TextDescription);
            return sb.ToString();
        }

        /// <summary>
        /// Updates the current version of the Video lesson
        /// </summary>
        /// <param name="version"></param>
        public void UpdateVersion(byte[] version)
        {
            Array.Copy(version, Version, 8);
        }
    }
}
