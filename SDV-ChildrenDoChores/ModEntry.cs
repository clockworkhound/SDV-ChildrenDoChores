using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace ChildrenDoChores
{
    public class ModEntry : Mod
    {
        private ModConfig ModConfig;
        private ChildrenChoreSkillsData ModData;
        private List<string> FarmersChildrensNames;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            FarmersChildrensNames = new List<string>();

            //Read data and config
            ModData = Helper.Data.ReadJsonFile<ChildrenChoreSkillsData>("data.json") ?? new ChildrenChoreSkillsData();
            ModConfig = Helper.ReadConfig<ModConfig>();

            //Get the mod started -- add stuff to the game on save load and day start
            helper.Events.GameLoop.SaveLoaded += Initialize;
            helper.Events.GameLoop.DayStarted += DayStarted;
        }


        /*********
        ** Private methods
        *********/
        private void Initialize(object sender, SaveLoadedEventArgs e)
        {
            Farmer farmer = Game1.player;
            List<StardewValley.Characters.Child> farmerChildren = Game1.player.getChildren();

            if (farmerChildren.Count > 0)
            {
                foreach (StardewValley.Characters.Child child in farmerChildren)
                {
                    foreach (ChildConfig childAndChoreSet in ModConfig.ChildrenAndChores)
                    {
                        if (childAndChoreSet.Name == child.Name)
                        {
                            Monitor.Log($"Chore information found for {child.Name}.", LogLevel.Error);
                            FarmersChildrensNames.Add(child.Name);
                        }
                    }
                }

                foreach(string childName in FarmersChildrensNames)
                {
                    if (ModData.ListOfChildrenAndSkills.ContainsKey(childName))
                    {
                        Monitor.Log($"Data already exists for {childName}; it will be used.", LogLevel.Error);
                    }
                    else
                    {
                        Monitor.Log($"No data exists for {childName} yet; adding their information to the data file.", LogLevel.Error);
                        ModData.ListOfChildrenAndSkills[childName] = new ChildSkills();
                        Monitor.Log(childName);
                        Helper.Data.WriteJsonFile("data.json", ModData);
                    }
                }

            }
            else
            {
                Monitor.Log($"{farmer.Name} has no children to do any chores.", LogLevel.Error);
            }

        }
        private void DayStarted(object sender, DayStartedEventArgs e)
        {
        }
    }
}