using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Bloons;
using MelonLoader;

[assembly: MelonInfo(typeof(HyposonicTowers.Mod), "Hyposonic Towers", "1.0.0", "Baydock")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonAuthorColor(255, 255, 104, 0)]

namespace HyposonicTowers {
    [HarmonyPatch]
    public class Mod : MelonMod {
        public static MelonLogger.Instance Logger { get; set; }

        public override void OnInitializeMelon() {
            Logger = LoggerInstance;
        }

        [HarmonyPatch(typeof(GameModelLoader), nameof(GameModelLoader.Load))]
        [HarmonyPostfix]
        public static void Hypo(GameModel __result) {
            foreach (var tower in __result.towers) {
                foreach (var behavior in tower.behaviors) {
                    AttackModel attack = behavior.TryCast<AttackModel>();
                    if (attack is not null) {
                        foreach (var weapon in attack.weapons) {
                            weapon.rate = 9999999;
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
        [HarmonyPrefix]
        public static bool Heheheha(ref float totalAmount) {
            totalAmount = 0;
            return true;
        }
    }
}
