namespace Training_Website
{
    public abstract class TrainingMaterial : BaseTraining
    {
        private const int MaxLengthTextDescription = 256;
        private string? textDescription = null;

        protected TrainingMaterial(string? textDescription = null)
        {
            this.TextDescription = textDescription;
        }

        public string TextDescription
        {
            get
            {
                return this.textDescription;
            }
            private set
            {
                if (value.Length >= MaxLengthTextDescription)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTextDescriptionLength);
                }
                this.textDescription = value;
            }
        }
    }
}
