using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Website
{
    public class TrainingLesson : BaseTraining, IVersionable, ICloneable
    {
        private int[] version = new int[] { 0, 0, 0, 0, 0, 0, 0, 1 };
        public int[] Version { get; set; }
        public string GenerateMyGuid()
        {
            MyGuid = Guid.NewGuid().ToString();
            return MyGuid;
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
            else
            {

            }

            return $"Lesson type: {lesson}";
        }

        public List<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();

        public void UpdateVersion(int[] version)
        {
            int counter = 0;
            foreach (var item in version)
            {
                this.Version[counter] = version[counter];
                counter++;
            }
        }

        public object Clone()
        {
            TrainingLesson newLesson = (TrainingLesson)this.MemberwiseClone();
            newLesson.MyGuid = (string)this.MyGuid.Clone();

            return newLesson;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
