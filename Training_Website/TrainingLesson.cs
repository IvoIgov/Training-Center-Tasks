namespace Training_Website
{
    public class TrainingLesson : BaseTraining, IVersionable, ICloneable
    {
        private byte[] version = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
        private List<TrainingMaterial> trainingMaterials = new List<TrainingMaterial>();
        public byte[] Version { get; set; }
        public List<TrainingMaterial> TrainingMaterials { get; set; }

        public TrainingLesson()
        {
            Version = this.version;
            TrainingMaterials = this.trainingMaterials;
        }
        public string TypeOfLesson()
        {
            EnumLessonTypes lesson = 0;
            if (TrainingMaterials.OfType<VideoMaterial>().Any())
            {
                lesson = EnumLessonTypes.VideoLesson;
            }
            else if (TrainingMaterials.OfType<TextMaterial>().Any())
            {
                lesson = EnumLessonTypes.TextLesson;
            }
            else if (TrainingMaterials.OfType<NetworkResourceLink>().Any())
            {
                lesson = EnumLessonTypes.NetworkResourceLesson;
            }

            return $"Lesson type: {lesson}";
        }


        public void UpdateVersion(byte[] version)
        {
            Array.Copy(version, Version, 8);
        }

        public object Clone()
        {
            TrainingLesson clonedLesson = new TrainingLesson();
            clonedLesson.MyGuid = this.MyGuid;
            clonedLesson.Version = this.Version;
            clonedLesson.TrainingMaterials = this.TrainingMaterials;

            return clonedLesson;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
