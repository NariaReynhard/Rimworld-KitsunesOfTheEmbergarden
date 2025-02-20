using RimWorld;
using Verse;
using System.Collections.Generic;

namespace KitsunesOfTheEmbergarden
{
    public class PolymerHarmonyHediff : HediffWithComps
    {
        private const float auraRange = 6f; // Adjust this value if needed

        public override void PostTick()
        {
            base.PostTick();

            if (pawn == null || pawn.Map == null)
                return;

            // Check if any Kitsune is in range
            bool inAura = IsPawnInKitsuneAura(pawn);

            if (inAura)
            {
                ApplyPolymerHarmonyEffect();
            }
            else
            {
                RemovePolymerHarmonyEffect();
            }
        }

        private bool IsPawnInKitsuneAura(Pawn cinder)
        {
            foreach (Pawn otherPawn in cinder.Map.mapPawns.AllPawns)
            {
                if (otherPawn != cinder && IsKitsuneWithAura(otherPawn) && cinder.Position.DistanceTo(otherPawn.Position) <= auraRange)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsKitsuneWithAura(Pawn pawn)
        {
            return pawn.genes?.GetGene(DefDatabase<GeneDef>.GetNamed("PolymerHarmony_Aura")) != null;
        }

        private void ApplyPolymerHarmonyEffect()
        {
            HediffDef harmonyEffect = DefDatabase<HediffDef>.GetNamed("PolymerHarmony_Effect");
            if (!pawn.health.hediffSet.HasHediff(harmonyEffect))
            {
                pawn.health.AddHediff(HediffMaker.MakeHediff(harmonyEffect, pawn));
            }
        }

        private void RemovePolymerHarmonyEffect()
        {
            HediffDef harmonyEffect = DefDatabase<HediffDef>.GetNamed("PolymerHarmony_Effect");
            Hediff existingHediff = pawn.health.hediffSet.GetFirstHediffOfDef(harmonyEffect);
            if (existingHediff != null)
            {
                pawn.health.RemoveHediff(existingHediff);
            }
        }
    }
}
