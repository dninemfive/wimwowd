using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Verse;

namespace Wimwowd
{
    [StaticConstructorOnStartup]
    public class HawmonyPatch
    {
        static HawmonyPatch()
        {
            Harmony hawmony = new Harmony("com.dninemfive.ohgod");
            hawmony.PatchAll();
        }

        [HarmonyPatch(typeof(Translator), "Translate", new Type[] { typeof(string) })]
        class UwUpatch
        {
            [HarmonyPostfix]
            public void TranslatePostfix(ref TaggedString __result)
            {
                // __result = __result.Replace("[lr]", "w").Replace("[LR]", "W").Replace("WW", "W").Replace("[Ww]w", "w"); // string.Replace doesn't support regex smdh
                __result = __result.Replace("l", "w")
                                   .Replace("r", "w")
                                   .Replace("L", "W")
                                   .Replace("R", "W")
                                   .Replace("WW", "W")
                                   .Replace("Ww", "W")
                                   .Replace("wW", "w")
                                   .Replace("ww", "w");
            }
        }
    }
}
