using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using MelonLoader;

[assembly: MelonInfo(typeof(HyposonicTowers.Mod), "Hyposonic Towers", "1.0.0", "Baydock")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonAuthorColor(255, 255, 104, 0)]

namespace HyposonicTowers {
    [HarmonyPatch]
    public sealed class Mod : MelonMod {
        public static MelonLogger.Instance Logger { get; set; }

        public override void OnInitializeMelon() {
            Logger = LoggerInstance;
        }

        [HarmonyPatch(typeof(GameModelLoader), nameof(GameModelLoader.Set_v_WeaponModel_Fields))]
        [HarmonyPostfix]
        public static void GetWeapons(GameModelLoader __instance, int start, int count) {
            int end = start + count;
            for (int i = start; i < end; i++)
                __instance.m[i].Cast<WeaponModel>().rate = 9999999;
        }
    }
}
