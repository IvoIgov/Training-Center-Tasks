namespace Training_Website
{
    public abstract class TrainingMaterial : BaseTraining
    {
        private string? textDescription = null;

        protected TrainingMaterial(string? textDescription = null)
        {
            this.MyGuid = GenerateMyGuid();
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
                if (value.Length > 255)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTextDescriptionLength);
                }
                this.textDescription = value;
            }
        }
    }
}
