using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenDoChores
{
    class ModConfig
    {
        public bool UseChildSkillProficiencies;
        public bool HarvestGreenhouseCrops;
        public bool HarvestTrees;
        public int MaximumNumberOfChores;
        public List<ChildConfig> ChildrenAndChores;
        public ModConfig()
        {
            UseChildSkillProficiencies = true;
            HarvestGreenhouseCrops = true;
            HarvestTrees = true;
            MaximumNumberOfChores = 2;

            ChildConfig blankChild = new ChildConfig();
            ChildrenAndChores = new List<ChildConfig>();
            ChildrenAndChores.Add(blankChild);
        }
    }

    class ChildConfig
    {
        public string Name { get; set; }
        public List<string> Chores { get; set; }

        public ChildConfig()
        {
            Name = "";
            Chores = new List<string>
            {
                "Water Crops",
                "Fill Pet Bowl"
            };
        }
    }
}
