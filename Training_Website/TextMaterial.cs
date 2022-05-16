using System.Text;

namespace Training_Website
{
    public class TextMaterial : TrainingMaterial
    {
        private string text = string.Empty;

        public TextMaterial(string textDescription, string text) : base(textDescription)
        {
            MyGuid = base.MyGuid;
            this.Text = text;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyText);
                }
                if (value.Length > 9999)
                {
                    throw new ArgumentException(ExceptionMessages.TextLength);
                }
                this.text = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Text material description: ");
            sb.Append(base.TextDescription);
            return sb.ToString();
        }
    }
}
