namespace Training_Website
{
    public abstract class BaseTraining
    {
        private string? myGuid = null;
        public string? MyGuid { get; set; }
        public string GenerateMyGuid()
        {
            MyGuid = Guid.NewGuid().ToString();
            return MyGuid;
        }

        public override bool Equals(object obj)
        {
            var material = (BaseTraining)obj;

            if (this.myGuid == material.MyGuid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
