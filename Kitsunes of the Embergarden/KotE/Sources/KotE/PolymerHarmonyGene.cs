using RimWorld;
using Verse;

namespace KotE
{
    public class PolymerHarmonyGene : Gene
    {
        ModExtension_RequireXenotype AuthorizedXenotypes => def.GetModExtension<ModExtension_RequireXenotype>();
        ModExtension_GeneEmitsAura AuraDatas => def.GetModExtension<ModExtension_GeneEmitsAura>();
        public override void PostAdd()
        {
            if (AuthorizedXenotypes.PawnHasRequiredXenotype(pawn)){
                pawn.genes.RemoveGene(this);
            };
        }

        public override void Tick()
        {
            base.Tick();
            ApplyEffect();
        }
        
        private void ApplyEffect(){
            foreach (Pawn potentialSubject in pawn.Map.mapPawns.AllHumanlikeSpawned){
                if (potentialSubject.Position.DistanceToSquared(pawn.Position)<=AuraDatas.radius){
                    potentialSubject.health.AddHediff(AuraDatas.auraEffect);
                };
            }
        }
    }

    public class ModExtension_RequireXenotype : DefModExtension
    {
        public XenotypeDef RequiredXenotypes;

        public bool PawnHasRequiredXenotype(Pawn pawn)
        {
            if(pawn?.genes==null) return false;
            return pawn.genes.Xenotype==RequiredXenotypes;
        }
    }

    public class ModExtension_GeneEmitsAura : DefModExtension
    {
        public HediffDef auraEffect;
        public float radius;
        public XenotypeDef affectsXenotypes;
    }
}