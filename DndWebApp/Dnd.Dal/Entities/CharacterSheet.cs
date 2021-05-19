using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dnd.Dal.Entities
{
    public class CharacterSheet
    {
        [Key]
        public int ID { get; set; }
        public List<FeatureSkill> FeatureSkills { get; set; } = new List<FeatureSkill>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Spell> Spells { get; set; } = new List<Spell>();
        [Required]
        [StringLength(50)]
        public string CharacterName { get; set; }
        [StringLength(50)]
        public string Class { get; set; }
        public int? Level { get; set; }
        public int? Proficiency { get; set; }
        public int? Inspiration { get; set; }
        public int? AC { get; set; }
        public int? Initiative { get; set; }
        public int? Speed { get; set; }
        public int? HpMax { get; set; }
        public int? CurrHp { get; set; }
        public int? TempHp { get; set; }
        public int? HitDice { get; set; }
        public int? DeathSaveSuccess { get; set; }
        public int? DeathSaveFail { get; set; }
        public int? PassiveWisdom { get; set; }
        [StringLength(5000)]
        public string ProficienciesLanguages { get; set; }
        [StringLength(10000)]
        public string Notes { get; set; }
        public int? Gold { get; set; }
        public int? Silver { get; set; }
        public int? Copper { get; set; }
        [StringLength(5000)]
        public string Equipment { get; set; }
        public int? STR { get; set; }
        public int? DEX { get; set; }
        public int? CON { get; set; }
        public int? INT { get; set; }
        public int? WIS { get; set; }
        public int? CHA { get; set; }
        public int? STRSave { get; set; }
        public int? DEXSave { get; set; }
        public int? CONSave { get; set; }
        public int? INTSave { get; set; }
        public int? WISSave { get; set; }
        public int? CHASave { get; set; }
        public int? Acrobatics { get; set; }
        public int? AnimalHandling { get; set; }
        public int? Arcana { get; set; }
        public int? Athletics { get; set; }
        public int? Deception { get; set; }
        public int? History { get; set; }
        public int? Insight { get; set; }
        public int? Intimidation { get; set; }
        public int? Investigation { get; set; }
        public int? Nature { get; set; }
        public int? Medicine { get; set; }
        public int? Perception { get; set; }
        public int? Performance { get; set; }
        public int? Persuasion { get; set; }
        public int? Religion { get; set; }
        public int? SleightOfHand { get; set; }
        public int? Stealth { get; set; }
        public int? Survival { get; set; }
        [StringLength(5000)]
        public string Background { get; set; }
        [StringLength(50)]
        public string Race { get; set; }
        [StringLength(50)]
        public string Alignment { get; set; }
        [StringLength(50)]
        public string XP { get; set; }
        [StringLength(50)]
        public string Age { get; set; }
        [StringLength(50)]
        public string Height { get; set; }
        public string Weight { get; set; }
        [StringLength(50)]
        public string Eyes { get; set; }
        [StringLength(50)]
        public string Skin { get; set; }
        [StringLength(50)]
        public string Hair { get; set; }
        [StringLength(5000)]
        public string Personality { get; set; }
        [StringLength(5000)]
        public string Ideals { get; set; }
        [StringLength(5000)]
        public string Bonds { get; set; }
        [StringLength(5000)]
        public string Flaws { get; set; }
        [StringLength(50)]
        public string SpellAbility { get; set; }
        public int? SpellSaveDC { get; set; }
        public int? SpellAtkBonus { get; set; }

    }
}
