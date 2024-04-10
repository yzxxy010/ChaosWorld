using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

using HarmonyLib;

using UnityEngine;

namespace ChaosWorld.Code.patch
{
    internal class attackSpeedMax
    {
        [HarmonyTranspiler, HarmonyPatch(typeof(ActorBase), "updateStats")]
        public static IEnumerable<CodeInstruction> attackSpeedMax_1_Transpiler(
            IEnumerable<CodeInstruction> instructions
        )
        {
            List<CodeInstruction> instructionList = new List<CodeInstruction>(instructions);

            // 找到目标 IL 代码块，即对应的ldarg.0、ldc.r4和stfld指令
            for (int i = 0; i < instructionList.Count - 2; i++)
            {
                if (isTimer(instructionList[i], instructionList[i + 1], instructionList[i + 2]))
                {
                    // 删除目标 IL 代码块
                    instructionList.RemoveRange(i, 3);
                    break;
                }
            }

            return instructionList.AsEnumerable();
        }

        [HarmonyTranspiler, HarmonyPatch(typeof(Actor), "tryToAttack")]
        public static IEnumerable<CodeInstruction> attackSpeedMax_2_Transpiler(
            IEnumerable<CodeInstruction> instructions
        )
        {
            List<CodeInstruction> instructionList = new List<CodeInstruction>(instructions);

            // 找到目标 IL 代码块，即对应的ldarg.0、ldc.r4和stfld指令
            for (int i = 0; i < instructionList.Count - 2; i++)
            {
                if (isTryToAttack(instructionList[i]))
                {
                    instructionList.RemoveRange(i, 1);
                    break;
                }
            }

            return instructionList.AsEnumerable();
        }

        private static bool isTimer(
            CodeInstruction instruction1,
            CodeInstruction instruction2,
            CodeInstruction instruction3
        )
        {
            return (instruction1.opcode == OpCodes.Ldarg_0)
                && (instruction2.opcode == OpCodes.Ldc_R4)
                && (instruction2.operand is float && (float)instruction2.operand == 0.1f)
                && (instruction3.opcode == OpCodes.Stfld)
                && (
                    instruction3.operand is FieldInfo fieldInfo
                    && fieldInfo.Name == "s_attackSpeed_seconds"
                );
        }

        private static bool isTryToAttack(CodeInstruction instruction1)
        {
            return (instruction1.opcode == OpCodes.Call)
                && (
                    instruction1.operand is MethodInfo methodInfo
                    && methodInfo.Name == "isAttackReady"
                    && methodInfo.ReturnType.FullName == typeof(bool).FullName
                );
        }
    }
}