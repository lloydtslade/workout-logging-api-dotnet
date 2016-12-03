

namespace WorkoutLog_Onion.Domain.Models
{
    
    using System.ComponentModel;
  
    public enum WorkoutType
    {

        [Description("Upper Body Strength")]
        UpperBodyStrength,

        [Description("Lower Body strength")]
        LowerBodyStrength,

        [Description("Upper Body Hypertrophy")]
        UpperBodyHypertrophy,

        [Description("Lower Body Hypertrophy")]
        LowerBodyHypertrophy,

        [Description("Cardio")] Cardio,

        [Description("Body Weight / Calisthenics")] Bodyweight,

        [Description("Other")]
        Other

    
    }

}