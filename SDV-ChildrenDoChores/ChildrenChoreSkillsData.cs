using System.Collections.Generic;

namespace ChildrenDoChores
{
    /// <summary>
    /// The data containing information about the skills of each child across all save files.  
    /// </summary>
    class ChildrenChoreSkillsData
    {
        public Dictionary<string, ChildSkills> ListOfChildrenAndSkills;

        public ChildrenChoreSkillsData()
        {
            ListOfChildrenAndSkills = new Dictionary<string, ChildSkills>();
        }
    }

    /// <summary>
    /// The data model for each individual child, which tracks their proficiency in the different chores and earned EXP
    /// </summary>
    class ChildSkills
    {
        Dictionary<string, int> WaterCrops;
        Dictionary<string, int> HarvestCrops;
        Dictionary<string, int> PlantCrops;
        Dictionary<string, int> PetAnimals;
        Dictionary<string, int> HarvestBarn;
        Dictionary<string, int> HarvestCoop;

        /// <summary>
        /// Constructor to create data about a child.  Levels and EXP default to 0.
        /// </summary>
        public ChildSkills()
        {
            WaterCrops = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };

            HarvestCrops = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };

            PlantCrops = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };

            PetAnimals = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };

            HarvestBarn = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };

            HarvestCoop = new Dictionary<string, int>
            {
                { "level", 0 },
                { "exp", 0 }
            };
        }
    }
}
