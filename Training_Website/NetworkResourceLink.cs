using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Website
{
    public class NetworkResourceLink : TrainingMaterial
    {
        private string contentURI = string.Empty;
        private EnumLinkType linkType;


        public NetworkResourceLink(string textDescription, string contentURI, EnumLinkType linkType) : base(textDescription)
        {
            
           MyGuid = base.MyGuid;
            this.ContentURI = contentURI;
            this.LinkType = linkType;
        }

        public string ContentURI
        {
            get
            {
                return this.contentURI;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyContentURI);
                }
                this.contentURI = value;
            }
        }

        public EnumLinkType LinkType { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Network Resource Link material description: ");
            sb.Append(base.TextDescription);
            return sb.ToString();
        }

        public override bool Equals(object? obj1)
        {
            return true;
        }
    }
}
