namespace WorkoutLog_Onion.Domain.Models
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public Exercise(string name) {

            Name = name;

        }
        public string Name { get; set; }

        public int NumberOfRepetitions { get; set; }

        public int Resistance { get; set; }

        public int Volume => Resistance * NumberOfRepetitions;

    }
}