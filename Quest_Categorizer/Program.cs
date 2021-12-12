using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;

namespace Quest_Categorizer
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "Quest_Categorizer.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            foreach (var quest in state.LoadOrder.PriorityOrder.Quest().WinningOverrides())
            {
                if( quest.Name != null)
                {
                    String typestring = "";
                    if( (int)quest.Type == 0)
                    {
                        continue;
                    }
                    if( (int)quest.Type == 1)
                    {
                        typestring = "Main Quest";
                    }
                    if ((int)quest.Type == 2)
                    {
                        typestring = "Mages Guild";
                    }
                    if ((int)quest.Type == 3)
                    {
                        typestring = "Thieves Guild";
                    }
                    if ((int)quest.Type == 4)
                    {
                        typestring = "Dark Brotherhood";
                    }
                    if ((int)quest.Type == 5)
                    {
                        typestring = "Companions";
                    }
                    if ((int)quest.Type == 6)
                    {
                        typestring = "Misc";
                    }
                    if ((int)quest.Type == 7)
                    {
                        typestring = "Daedric";
                    }
                    if ((int)quest.Type == 8)
                    {
                        typestring = "Side Quest";
                    }
                    if ((int)quest.Type == 9)
                    {
                        typestring = "Civil War";
                    }
                    if ((int)quest.Type == 10)
                    {
                        typestring = "Dawnguard";
                    }
                    if ((int)quest.Type == 11)
                    {
                        typestring = "Dragonborn";
                    }
                    IQuest newquest = state.PatchMod.Quests.GetOrAddAsOverride(quest);
                    newquest.Name = typestring + ": " + quest.Name;
                }
            }
        }
    }
}
