namespace NoPowerWires
{
    using Verse;
    using HarmonyLib;
    using System.Reflection;

    public class Mod : Verse.Mod
    {
        public Mod(ModContentPack content) : base(content) {
            Harmony noPowerWires = new Harmony("weilbyte.rimworld.nopowerwires");

            MethodInfo targetMethod = AccessTools.Method(typeof(RimWorld.PowerNetGraphics), "PrintWirePieceConnecting");
            HarmonyMethod prefixMethod = new HarmonyMethod(AccessTools.Method(typeof(NoPowerWires.Mod), "PrintWirePieceConnecting_Prefix"));

            noPowerWires.Patch(targetMethod, prefixMethod);
        }

        public static bool PrintWirePieceConnecting_Prefix(bool forPowerOverlay) {
            return forPowerOverlay;
        }
    }
}
