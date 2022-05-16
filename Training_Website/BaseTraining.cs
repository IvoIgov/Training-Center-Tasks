namespace Training_Website
{
    public abstract class BaseTraining
    {
        private string? myGuid = null;
        public string? MyGuid { get; set; }

        /// <summary>
        /// Generates a GUID for all entities
        /// </summary>
        /// <returns></returns>
        public string GenerateMyGuid()
        {
            MyGuid = Guid.NewGuid().ToString();
            return MyGuid;
        }

        /// <summary>
        /// Compares whether an entity is of the same type as another entity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var material = obj as BaseTraining;

            return this.MyGuid == material.MyGuid;
        }
    }
}
