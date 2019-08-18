using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace BDHelper
{
    public class CharacterState
    {
        public string Type; // Item type
        public int sgn; //Selected Gear(Item)
        //public bool iEnch; //Item can or can't be enchanted
        
        // Character stats
        public int cdp; // DP
        public int cap; // AP
        public int caap; // AAP
        public int cev;// Evasion
        public int cacc;//Accuracy
        public int cRes1 = 20;// Resists: Stun/Stiffness/Freezing
        public int cRes2 = 20;// Resists: Knockdown/Bound
        public int cRes3 = 20;// Resists: Grapple
        public int cRes4 = 20;// Resists: Knockback/Floating
        public int cDR; // Damage Reduction
        public int cMaxHP; // Max HP
        public double cWeight; // Weight
        public int cMaxMP;// Max MP
        public int cMaxST;// Max stamina
        public int chev; // Hiden evasion
        public int chdr; // hiden damage reduction
        public int cAtkSpeed;
        public int cCastSpeed;
        public int cAtkSpeedRate;
        public int cCastSpeedRate;
        public int cmvs; // Movement speed 
        public int ccr; // Critical Rate
        public int chap; // Hidden AP
        public int chpr; // HP Recovery
        public int cmpr; //MP Recovery
        public int cluck; // Luck
        public int ceda; //Extra damage all
        public int cedh; //Extra damage humans
        public int ceapa; //Extra AP agains monster
        public int cedKama; //Extra Damage to Kamasylvians
        public int cADtDemiH; //Additional Damage to Demihumans
        public int cADtoAllWithExcept; //Extra Damage to All Species Except Humans and Demihumans
        public int cSpiritRage; // Black Spirit's Rage
        public int cBidding; // Marketplace Bidding Success Rate
        public int cEDtoBack; //Back extra damage
        public int cResistIgnore; // Ignore all Resistance
        public int cHPrecoveryChance; //HP recovery by hit chance 
        public int cdfm; //Damage from Monsters
        public int cSpecialAttackEv; //Special attack Evasion Rate 
        public int cSpecialAttackDam; //Special attack extra damage
        public double cAlchCookTime; // Alchemy and Cooking Time
        public int cProccesingRate; // Processing Success Rate
        public int cGathDropRate; // Gathering Drop Rate
        public int cGathering; //Gathering level
        public int cFishing; //Fishing level
        public int cCombatExp; //Combat EXP bonus
        public int cSkillExp; //Skill EXP bonus

        public int cEDtoAir; //Air extra damage
        public int cEDtoCounter; //Counter extra damage
        public int cEDtoDown; //Down extra damage
        public int cGrapResistIgnore; // Ignore Graple Resistance
        public int cKBResistIgnore; // Ignore Knockback Resistance
        public int cKDResistIgnore; // Ignore KnockDown Resistance
        public int cStunResistIgnore; // Ignore Stun Resistance
        public int cSpeedAtkDmg; // Aditional Speed Atack Damage
        public int cCritHitDmg; // Critical Hit Damage
        public int cVisionRange; // Vision Range
        public int cMagicDR; //Magic Damage Reduction    
        public int cMeleeDR; //Melle Damage Reduction    
        public int cRangeDR; //Range Damage Reduction    
        public int cSiegeWeaponEvRate; //Siege Weapon Evasion Rate    

        public int cMagicAP; //Magic AP    
        public int cMelleAP; //Melle AP    
        public int cRangeAP; //Range AP

        public int cJump; // Jump Height
        public int cFallDamage; // Fall Damage
        public int cUnderwaterBreath; // Underwater Breathing 
        public int cMaxEnergy; //Max Energy


        //Training
        public int tcsb; //Breath
        public double tcss; //Strength
        public int tcsh1; //Health (HP)
        public int tcsh2; //Health (MP)

        //Shai's talent bonus
        public int shaiEv;
        public int shaiDP;
        public int shaiMvs;
        public int shaiSpeed;

        //BossSetBonus Check (SetBonus = 1)
        public int b_sb; //Set Bonus
        public int b_asb; //Armour
        public int b_hsb; //Helm
        public int b_bsb; //Boots
        public int b_gsb; //Gloves
        //LemoriaSetBonus Check (SetBonus = 2)
        public int l_sb;
        public int l_asb;
        public int l_hsb;
        public int l_bsb;
        public int l_gsb;
        //AkumSetBonus Check (SetBonus = 3)
        public int a_sb;
        public int a_asb;
        public int a_hsb;
        public int a_bsb;
        public int a_gsb;
        //GrunilSetBonus Check  (SetBonus = 4)
        public int gr_sb;
        public int gr_asb;
        public int gr_hsb;
        public int gr_bsb;
        public int gr_gsb;
        //TaritasSetBonus Check  (SetBonus = 5)
        public int tr_sb;
        public int tr_asb;
        public int tr_hsb;
        public int tr_bsb;
        public int tr_gsb;       
        //RocabaSetBonus Check  (SetBonus = 6)
        public int rc_sb;
        public int rc_asb;
        public int rc_hsb;
        public int rc_bsb;
        public int rc_gsb;
        //AgerianSetBonus Check  (SetBonus = 7)
        public int ag_sb;
        public int ag_asb;
        public int ag_hsb;
        public int ag_bsb;
        public int ag_gsb;
        //ZerethSetBonus Check  (SetBonus = 8)
        public int zr_sb;
        public int zr_asb;
        public int zr_hsb;
        public int zr_bsb;
        public int zr_gsb;
        //TalisSetBonus Check  (SetBonus = 9)
        public int tl_sb;
        public int tl_asb;
        public int tl_hsb;
        public int tl_bsb;
        public int tl_gsb;
        //Strength "" of Heve SetBonus Check (SetBonus = 10)
        public int sh_sb;
        public int sh_asb;
        public int sh_hsb;
        public int sh_bsb;
        public int sh_gsb;
        //Hercules' Might SetBonus Check  (SetBonus  = 11)
        public int hm_sb;
        public int hm_asb;
        public int hm_hsb;
        public int hm_bsb;
        public int hm_gsb;
        //Luck "" of Fortuna SetBonus Check  (SetBonus = 12)
        public int lf_sb;
        public int lf_asb;
        public int lf_hsb;
        public int lf_bsb;
        public int lf_gsb;

        //Set bonus (num)
        //Boss
        public int b_b3;
        public int b_b4;
        //Lemoria
        public int l_b2;
        public int l_b4;
        //Akum
        public int a_b2;
        public int a_b3a;
        public int a_b3b;
        public int a_b4;
        //Grunil
        public int gr_b2;
        public int gr_b3;
        public int gr_b4;
        //Taritas 
        public int tr_b2;
        public int tr_b3;
        //Rocaba
        public int rc_b2;
        public int rc_b3;
        public int rc_b4;
        //Agerian 
        public int ag_b2;
        public int ag_b3;
        //Zereth
        public int zr_b2;
        public int zr_b3;
        //Talis
        public int tl_b2;
        public int tl_b3;
        //Strength "" of Heve 
        public int sh_b2;
        public int sh_b3;
        //Hercules' Might
        public int hm_b2;
        public int hm_b3;
        //Luck "" of Fortuna
        public int lf_b2;
        public int lf_b3;

        //AccSet
        //GránaSetBonus Check (AccSetBonus = 1)
        public int a_g_sb; //Set Bonus
        public int a_g_bsb; //belt
        public int a_g_nsb; //neck
        public int a_g_e1sb; //ear1
        public int a_g_e2sb; //ear2
        public int a_g_r1sb; //ring1
        public int a_g_r2sb; //ring2
        //AsulaSetBonus Check (AccSetBonus = 2)
        public int a_a_sb;
        public int a_a_bsb;
        public int a_a_nsb;
        public int a_a_e1sb;
        public int a_a_e2sb;
        public int a_a_r1sb;
        public int a_a_r2sb;
        //JaretteSetBonus Check (AccSetBonus = 3)
        public int a_j_sb;
        public int a_j_bsb;
        public int a_j_nsb;
        public int a_j_e1sb;
        public int a_j_e2sb;
        public int a_j_r1sb;
        public int a_j_r2sb;
        //Treant Spirit SetBonus Check (AccSetBonus = 4)
        public int a_ts_sb;
        public int a_ts_bsb;
        public int a_ts_nsb;
        public int a_ts_e1sb;
        public int a_ts_e2sb;
        public int a_ts_r1sb;
        public int a_ts_r2sb;
        //Root Treant SetBonus Check (AccSetBonus = 5)
        public int a_rt_sb;
        public int a_rt_bsb;
        public int a_rt_nsb;
        public int a_rt_e1sb;
        public int a_rt_e2sb;
        public int a_rt_r1sb;
        public int a_rt_r2sb;
        //Val AP SetBonus Check (AccSetBonus = 6)
        public int a_va_sb;
        public int a_va_bsb;
        public int a_va_nsb;
        public int a_va_e1sb;
        public int a_va_e2sb;
        public int a_va_r1sb;
        public int a_va_r2sb;
        //Val DP SetBonus Check (AccSetBonus = 7)
        public int a_vd_sb;
        public int a_vd_bsb;
        public int a_vd_nsb;
        public int a_vd_e1sb;
        public int a_vd_e2sb;
        public int a_vd_r1sb;
        public int a_vd_r2sb;

        //Acc SetBonus (num)
        //Grána
        public int a_g_b3a;
        public int a_g_b3b;
        //Asula
        public int a_a_b3;
        public int a_a_b5;
        //Jarette
        public int a_j_b3;
        public int a_j_b5;
        //Treant Spirit
        public int a_ts_b3;
        public int a_ts_b5;
        //Root Treant
        public int a_rt_b3;
        public int a_rt_b5;
        //Val AP
        public int a_va_b2;
        //Val DP
        public int a_vd_b2;

        //Weapon Set
        //KreaSetBonus Check (WeaponSetBonus = 1)
        public int k_sb;
        public int k_mwb;
        public int k_swb; 
        //RosarSetBonus Check (WeaponSetBonus = 2)
        public int r_sb;
        public int r_mwb;
        public int r_swb; 
        
        //Acc SetBonus (num)
        //Krea
        public int k_b2;
        //Rosar
        public int r_b2;

        //Caphras  Arm
        public int c_armHP;
        public int c_armdp;
        public int c_armev;
        public int c_armhev;
        public int c_armdr;
        public int c_armMP;
        public int c_armhdr;
        //Caphras  Helm
        public int c_helHP;
        public int c_heldp;
        public int c_helev;
        public int c_helhev;
        public int c_heldr;
        public int c_helMP;
        public int c_helhdr;
        //Caphras  Gloves
        public int c_glovHP;
        public int c_glovdp;
        public int c_glovev;
        public int c_glovhev;
        public int c_glovdr;
        public int c_glovMP;
        public int c_glovhdr;
        //Caphras  Shoes
        public int c_shHP;
        public int c_shdp;
        public int c_shev;
        public int c_shhev;
        public int c_shdr;
        public int c_shMP;
        public int c_shhdr;
        //Caphras AW
        public int c_awAAP;
        public int c_awAcc;
        //Caphras MW
        public int c_mwAP;
        public int c_mwAcc;
        //Caphras SW
        public int c_swAP;
        public int c_swAAP;
        public int c_swAcc;
        public int c_swHP;
        public int c_swMP;
        public int c_swDP;
        public int c_swHDR;
        public int c_swEva;
        public int c_swHEva;
        public int c_swDR;

        // Belt stats
        public int beltap; //Betl AP
        public int beltev; // Belt Evasion
        public int beltacc;//Belt Accuracy
        public int beltdp; //Belt DP
        public int beltResis; // Belt Resists
        public int beltDR; //Belt DR
        public int beltHP; //Belt MaxHP
        public int beltWeight;//Belt Weight
        public int beltId = 0; // Current belt Id
        public int beltEnchLvl = 0; // Belt's enchant level
        public bool beltEnch; 
        public int beltDefap; //Betl default AP
        public int beltDefev; // Belt default Evasion
        public int beltDefacc;//Belt default Accuracy
        public int beltDefdp; //Belt default DP
        public int beltDefResis; // Belt default Resists
        public int beltDefDR; //Belt default DR
        public int beltDefHP; //Belt default MaxHP
        public int beltDefWeight;//Belt default Weight
        public int beltDefAPagainst;
        public int beltAPagaingst;
        public int beltSpiritRage; // Black Spirit's Rage
        public int beltDefSpiritRage;
        public int beltSB; // Belt SetBonus

        // Neck stats
        public int neckap; //Neck AP
        public int neckev; // Neck Evasion
        public int neckacc;//Neck Accuracy
        public int neckdp; //Neck DP
        public int neckAllRes; //Neck Resists
        public int neckDR; //Neck DR
        public int neckSSF; //Neck Resists: Stun/Stiffness/Freezing
        public int neckKB; //Neck Resists: Knockdown/Bound
        public int neckG; //Neck Resists: Grapple
        public int neckKF; //Neck Resists: Knockback/Floating
        public int neckHP; //Neck Max HP
        public int neckId = 0; //Current neck Id
        public int neckEnchLvl = 0; // Neck's enchant level
        public bool neckEnch;
        public int neckDefap; //Neck AP
        public int neckDefev; // Neck Evasion
        public int neckDefacc;//Neck Accuracy
        public int neckDefdp; //Neck DP
        public int neckDefAllRes; //Neck Resists
        public int neckDefDR; //Neck DR
        public int neckDefSSF; //Neck Resists: Stun/Stiffness/Freezing
        public int neckDefKB; //Neck Resists: Knockdown/Bound
        public int neckDefG; //Neck Resists: Grapple
        public int neckDefKF; //Neck Resists: Knockback/Floating
        public int neckDefHP; //Neck Max HP

        public int neckDefAPagainst;
        public int neckAPagaingst;

        public int neckDefKamaDamage;
        public int neckKamaDamage;
        public int neckSpiritRage; // Black Spirit's Rage
        public int neckDefSpiritRage;

        public int neckBackDamage;
        public int neckDefBackDamage;

        public int neckSB; // Neck SetBonus

        //First Ring stats
        public int ring1ap; //Ring AP
        public int ring1ev; // Ring Evasion
        public int ring1acc;//Ring Accuracy
        public int ring1dp; //Ring DP
        public int ring1DR; //Ring DR
        public int ring1HP; //Ring Max HP
        public int ring1MP; //Ring Max MP
        public int ring1ST; //Ring Max stamina
        public int ring1Id = 0; // Current ring Id
        public int ring1EnchLvl = 0; // Ring's enchant level
        public bool ring1Ench;
        public int ring1Defap; //Ring default AP
        public int ring1Defev; // Ring default Evasion
        public int ring1Defacc;//Ring default Accuracy
        public int ring1Defdp; //Ring default DP
        public int ring1DefDR; //Ring default DR
        public int ring1DefHP; //Ring default Max HP
        public int ring1DefMP; //Ring default Max MP
        public int ring1DefST; //Ring default Max stamina

        public int ring1DefHEv;
        public int ring1HEv;

        public int ring1DefAPagainst;
        public int ring1APagaingst;

        public int ring1DefKamaDamage;
        public int ring1KamaDamage;

        public int ring1DefDamageHumans;
        public int ring1DamageHumans;

        public int ring1DefDamageDemihumans;
        public int ring1DamageDemihumans;

        public int ring1DefDamageAllExcept;
        public int ring1DamageAllExcept;

        public int ring1SpiritRage; // Black Spirit's Rage
        public int ring1DefSpiritRage;

        public int ring1Bidding; // Marketplace Bidding Success Rate
        public int ring1DefBidding;

        public int ring1SB; // Ring SetBonus

        //Second Ring stats
        public int ring2ap; //Ring AP
        public int ring2ev; // Ring Evasion
        public int ring2acc;//Ring Accuracy
        public int ring2dp; //Ring DP
        public int ring2DR; //Ring DR
        public int ring2HP; //Ring Max HP
        public int ring2MP; //Ring Max MP
        public int ring2ST; //Ring Max stamina
        public int ring2Id = 0; // Current ring Id
        public int ring2EnchLvl = 0; // Ring's enchant level
        public bool ring2Ench;
        public int ring2Defap; //Ring default AP
        public int ring2Defev; // Ring default Evasion
        public int ring2Defacc;//Ring default Accuracy
        public int ring2Defdp; //Ring default DP
        public int ring2DefDR; //Ring default DR
        public int ring2DefHP; //Ring default Max HP
        public int ring2DefMP; //Ring default Max MP
        public int ring2DefST; //Ring default Max stamina

        public int ring2DefHEv;
        public int ring2HEv;

        public int ring2DefAPagainst;
        public int ring2APagaingst;

        public int ring2DefKamaDamage;
        public int ring2KamaDamage;

        public int ring2DefDamageHumans;
        public int ring2DamageHumans;

        public int ring2DefDamageDemihumans;
        public int ring2DamageDemihumans;

        public int ring2DefDamageAllExcept;
        public int ring2DamageAllExcept;

        public int ring2SpiritRage; // Black Spirit's Rage
        public int ring2DefSpiritRage; 

        public int ring2Bidding; // Marketplace Bidding Success Rate
        public int ring2DefBidding;

        public int ring2SB; // Ring SetBonus

        //First earring stats
        public int ear1ap; //Earring AP
        public int ear1ev; // Earring Evasion
        public int ear1acc;//Earring Accuracy
        public int ear1dp; //Earring DP
        public int ear1DR; //Earring DR
        public int ear1HP; //Earring Max HP
        public int ear1MP; //Earring Max MP
        public int ear1ST; //Earring Max stamina
        public int ear1Id = 0; // Current earring Id
        public int ear1EnchLvl = 0; // Earring's enchant level
        public bool ear1Ench;
        public int ear1Defap; //Earring default AP
        public int ear1Defev; // Earring default Evasion
        public int ear1Defacc;//Earring default Accuracy
        public int ear1Defdp; //Earring default DP
        public int ear1DefDR; //Earring default DR
        public int ear1DefHP; //Earring default Max HP
        public int ear1DefMP; //Earring default Max MP
        public int ear1DefST; //Earring default Max stamina

        public int ear1DefAPagainst;
        public int ear1APagaingst;

        public int ear1DefKamaDamage;
        public int ear1KamaDamage;
        public int ear1SpiritRage; // Black Spirit's Rage
        public int ear1DefSpiritRage;

        public int ear1SB; // Earring SetBonus

        //Second earring stats
        public int ear2ap; //Earring AP
        public int ear2ev; // Earring Evasion
        public int ear2acc;//Earring Accuracy
        public int ear2dp; //Earring DP
        public int ear2DR; //Earring DR
        public int ear2HP; //Earring Max HP
        public int ear2MP; //Earring Max MP
        public int ear2ST; //Earring Max stamina
        public int ear2Id = 0; // Current earring Id
        public int ear2EnchLvl = 0; // Earring's enchant level
        public bool ear2Ench;
        public int ear2Defap; //Earring default AP
        public int ear2Defev; // Earring default Evasion
        public int ear2Defacc;//Earring default Accuracy
        public int ear2Defdp; //Earring default DP
        public int ear2DefDR; //Earring default DR
        public int ear2DefHP; //Earring default Max HP
        public int ear2DefMP; //Earring default Max MP
        public int ear2DefST; //Earring default Max stamina

        public int ear2DefAPagainst;
        public int ear2APagaingst;

        public int ear2DefKamaDamage;
        public int ear2KamaDamage;
        public int ear2SpiritRage; // Black Spirit's Rage
        public int ear2DefSpiritRage;

        public int ear2SB; // Earring SetBonus

        //Armor stats
        public int armdp;// Armor DP
        public int armGems; // Armor gems count
        public int armev;// Armor evasion
        public int armhev;// Armor hiden evasion
        public int armdr;// Armor damage reduction
        public int armhdr;// Armor hiden damage reduction
        public int armHP;
        public int armMP;
        public bool armEnch;
        public int armId = 0; // Current armor Id
        public int armEnchLvl = 0; // Armor's enchant level
        public int armCaphLvl = 0;
        public bool armIsBoss;// Armor is boss item or not
        public int armDefdp; // Armor default DP 
        public int armDefev;// Armor default evasion 
        public int armDefhev;// Armor default hiden evasion 
        public int armDefdr;// Armor default damage reduction 
        public int armDefhdr;// Armor default hiden damage reduction 
        public int armDefHP;
        public int armDefMP;
        public int armSSFRes;
        public int armDefSSFRes;
        public int armWeight;
        public int armDefWeight;
        public int armAcc;
        public int armDefAcc;

        public int armHPRecovery;
        public int armDefHPRecovery;

        public int armMPRecovery;
        public int armDefMPRecovery;
           
        public int armSB; //set bonus

        //Helmet stats
        public int helGems;
        public int heldp;// Helmet DP
        public int helev;// Helmet evasion
        public int helhev;// Helmet hiden evasion
        public int heldr;// Helmet damage reduction
        public int helhdr;// Helmet hiden damage reduction
        public int helHP;
        public int helSSFRes;
        public int helKFRes;
        public int helKBRes;
        public int helGrapleRes;
        public bool helEnch;
        public int helId = 0; // Current Helmet Id
        public int helEnchLvl = 0; // Helmet's enchant level
        public int helCaphLvl = 0;
        public bool helIsBoss;// Helmet is boss item or not
        public int helDefdp; // Helmet default DP 
        public int helDefev;// Helmet default evasion 
        public int helDefhev;// Helmet default hiden evasion 
        public int helDefdr;// Helmet default damage reduction 
        public int helDefhdr;// Helmet default hiden damage reduction 
        public int helDefHP;
        public int helSSFDefRes;
        public int helKFDefRes;
        public int helKBDefRes;
        public int helGrapleDefRes;
        public int helWeight;
        public int helDefWeight;
        public int helST;
        public int helDefST;
        public int helSB; // set bonus
        public int helDefHPRecovery;
        public int helHPRecovery;
        public int helLuck;
        public int helDefLuck;

        //Gloves stats
        public int glovGems;
        public int glovdp;// Gloves DP
        public int glovacc;// Gloves acc
        public int glovev;// Gloves evasion
        public int glovhev;// Gloves hiden evasion
        public int glovdr;// Gloves damage reduction
        public int glovhdr;// Gloves hiden damage reduction
        public bool glovEnch;
        public int glovId = 0; // Current Gloves Id
        public int glovEnchLvl = 0; // Gloves's enchant level
        public int glovCaphLvl = 0;
        public bool glovIsBoss;// Gloves is boss item or not
        public int glovDefdp; // Gloves default DP
        public int glovDefacc;// Gloves acc
        public int glovDefev;// Gloves default evasion 
        public int glovDefhev;// Gloves default hiden evasion 
        public int glovDefdr;// Gloves default damage reduction 
        public int glovDefhdr;// Gloves default hiden damage reduction 
        public int glovSB; // set bonus
        public int glovAtkSpeed;
        public int glovDefAtkSpeed;
        public int glovCastSpeed;
        public int glovDefCastSpeed;
        public int glovCrit;
        public int glovDefCrit;
        public int glovWeight;
        public int glovDefWeight;
        public int glovGrapleRes;
        public int glovDefGrapleRes;

        public int glovDamage;
        public int glovDefDamage;

        //Shoes stats
        public int shGems;
        public int shdp;// Shoes DP
        public int shev;// Shoes evasion
        public int shhev;// Shoes hiden evasion
        public int shdr;// Shoes damage reduction
        public int shhdr;// Shoes hiden damage reduction
        public bool shEnch;
        public int shId = 0; // Current Shoes Id
        public int shEnchLvl = 0; // Shoes's enchant level
        public int shCaphLvl = 0;
        public bool shIsBoss;// Shoes is boss item or not
        public int shDefdp; // Shoes default DP
        public int shDefev;// Shoes default evasion 
        public int shDefhev;// Shoes default hiden evasion 
        public int shDefdr;// Shoes default damage reduction 
        public int shDefhdr;// Shoes default hiden damage reduction
        public int shSB; //Set bonus

        public int shMvs;
        public int shDefMvs;

        public int shKBRes;
        public int shDefKBRes;

        public int shMaxST;
        public int shDefMaxST;

        public int shWeight;
        public int shDefWeight;


        //Awakening Weapons State
        public int awkId = 0;
        public bool awkEnch;
        public int awkEnchLvl = 0;
        public int awkCaphLvl = 0;
        public int awkAPlow;
        public int awkAPhigh;
        public int awkAP;
        public int awkDefAPlow;
        public int awkDefAPhigh;
        public int awkDamageHumans;
        public int awkDefDamageHumans;
        public int awkAPagainst;
        public int awkDefAPagainst;
        public int awkAccuracy;
        public int awkDefAccuracy;
        public int awkDamageAll;
        public int awkDefDamageAll;
        public bool awkCheckHd;
        public bool awkCheckAd;
        public bool awkCheckAg;

        public int awkDefAllEvasion;
        public int awkAllEvasion;

        public int awkDefDPReduction;
        public int awkDPReduction;

        public int awkDefMvsSpeedRed;
        public int awkMvsSpeedRed;

        public int awkDefSpeedIncrease;
        public int awkSpeedIncrease;


        //Main Weapons State
        public int mwGems;
        public int mwId = 0;
        public bool mwEnch;
        public int mwEnchLvl = 0;
        public int mwCaphLvl = 0;
        public int mwAPlow;
        public int mwAPhigh;
        public int mwAP;
        public int mwDefAPlow;
        public int mwDefAPhigh;
        public int mwDamageHumans;
        public int mwDefDamageHumans;
        public int mwAPagainst;
        public int mwDefAPagainst;
        public int mwAccuracy;
        public int mwDefAccuracy;
        public int mwDamageAll;
        public int mwDefDamageAll;
        public int mwCrit;
        public int mwDefCrit;
        public int mwAtkSpeed;
        public int mwCastSpeed;
        public int mwDefAtkSpeed;
        public int mwDefCastSpeed;
        public int mwIgnore;
        public int mwDefIgnore;
        public int mwRecoveryChance;
        public int mwDefRecoveryChance;
        public int mwDamDemi;
        public int mwDefDamDemi;
        public int mwHidenAP;
        public int mwDefHidenAP;
        public int mwSB;


        //Sub-Weapons State
        public int swId = 0;
        public int swGems;
        public bool swEnch;
        public int swEnchLvl = 0;
        public int swCaphLvl = 0;
        public int swAPlow;
        public int swAPhigh;
        public int swAP;
        public int swDefAPlow;
        public int swDefAPhigh;
        public int swAPagainst;
        public int swDefAPagainst;
        public int swAccuracy;
        public int swDefAccuracy;
        public int swIgnore;
        public int swDefIgnore;
        public int swHidenAP;
        public int swDefHidenAP;
        public int swEvasion;
        public int swDefEvasion;
        public int swHEvasion;
        public int swDefHEvasion;
        public int swMaxHP;
        public int swDefMaxHP;
        public int swDR;
        public int swDefDR;
        public int swMaxST;
        public int swDefMaxST;
        public int swSpecialAttackEv;
        public int swDefSpecialAttackEv;
        public int swSpecialAttackDam;
        public int swDefSpecialAttackDam;
        public int swAllRes;
        public int swDefAllRes;
        public int swMaxMP;
        public int swDefMaxMP;
        public int swDP;
        public int swDefDP;
        public int swSB;

        //Alchemy Stones State
        public int asId = 0;
        public bool asEnch;
        public int asAPhigh;
        public int asAPlow;
        public int asAP;
        public int asDefAPhigh;
        public int asDefAPlow;
        public int asHidenAP;
        public int asDefHidenAP;
        public int asAccuracy;
        public int asDefAccuracy;
        public int asIgnore;
        public int asDefIgnore;
        public int asAtkSpeed;
        public int asDefAtkSpeed;
        public int asCastSpeed;
        public int asDefCastSpeed;
        public double asAlchCookTime;
        public double asDefAlchCookTime;
        public int asProcRate;
        public int asDefProcRate;
        public int asWeightLimit;
        public int asDefWeightLimit;
        public int asGathFish;
        public int asDefGathFish;
        public int asGathDropRate;
        public int asDefGathDropRate;
        public int asDR;
        public int asDefDR;
        public int asEvasion;
        public int asDefEvasion;
        public int asMaxHP;
        public int asDefMaxHP;
        public int asAllRes;
        public int asDefAllRes;

        //Weapon Magic Crystal - 1
        public int wmcId = 0;
        public string wmcType = "Weapon";
        public int wmcCrit;
        public int wmcDefCrit;
        public int wmcCastSpeed;
        public int wmcDefCastSpeed;
        public int wmcAtkSpeed;
        public int wmcDefAtkSpeed;
        public int wmcHidenAP;
        public int wmcDefHidenAP;
        public int wmcIgnoreAll;
        public int wmcDefIgnoreAll;
        public int wmcAccuracy;
        public int wmcDefAccuracy;
        public int wmcDmgToHumans;
        public int wmcDefDmgToHumans;
        public int wmcDmgToDemi;
        public int wmcDefDmgToDemi;
        public int wmcWeight;
        public int wmcDefWeight;
        public int wmcAllRes;
        public int wmcDefAllRes;
        public int wmcMaxHP;
        public int wmcDefMaxHP;
        public int wmcMaxST;
        public int wmcDefMaxST;
        public int wmcDR;
        public int wmcDefDR;
        public int wmcLuck;
        public int wmcDefLuck;
        public int wmcCombatEXP;
        public int wmcDefCombatEXP;
        public int wmcSkillEXP;
        public int wmcDefSkillEXP;

        //Weapon Magic Crystal - 2
        public int wmc2Id = 0;
        public string wmc2Type = "Weapon";
        public int wmc2Crit;
        public int wmc2DefCrit;
        public int wmc2CastSpeed;
        public int wmc2DefCastSpeed;
        public int wmc2AtkSpeed;
        public int wmc2DefAtkSpeed;
        public int wmc2HidenAP;
        public int wmc2DefHidenAP;
        public int wmc2IgnoreAll;
        public int wmc2DefIgnoreAll;
        public int wmc2Accuracy;
        public int wmc2DefAccuracy;
        public int wmc2DmgToHumans;
        public int wmc2DefDmgToHumans;
        public int wmc2DmgToDemi;
        public int wmc2DefDmgToDemi;
        public int wmc2Weight;
        public int wmc2DefWeight;
        public int wmc2AllRes;
        public int wmc2DefAllRes;
        public int wmc2MaxHP;
        public int wmc2DefMaxHP;
        public int wmc2MaxST;
        public int wmc2DefMaxST;
        public int wmc2DR;
        public int wmc2DefDR;
        public int wmc2Luck;
        public int wmc2DefLuck;
        public int wmc2CombatEXP;
        public int wmc2DefCombatEXP;
        public int wmc2SkillEXP;
        public int wmc2DefSkillEXP;

        //Sub-Weapon Magic Crystal - 1
        public int swmcId = 0;
        public string swmcType = "Sub-Weapon";
        public int swmcHidenAP;
        public int swmcDefHidenAP;
        public int swmcIgnoreAll;
        public int swmcDefIgnoreAll;
        public int swmcAccuracy;
        public int swmcDefAccuracy;
        public int swmcDmgToHumans;
        public int swmcDefDmgToHumans;
        public int swmcDmgToDemi;
        public int swmcDefDmgToDemi;
        public int swmcWeight;
        public int swmcDefWeight;
        public int swmcAllRes;
        public int swmcDefAllRes;
        public int swmcMaxHP;
        public int swmcDefMaxHP;
        public int swmcMaxST;
        public int swmcDefMaxST;
        public int swmcDR;
        public int swmcDefDR;
        public int swmcLuck;
        public int swmcDefLuck;
        public int swmcCombatEXP;
        public int swmcDefCombatEXP;
        public int swmcSkillEXP;
        public int swmcDefSkillEXP;
        public int swmcCritDmg;
        public int swmcDefCritDmg;
        public int swmcAirDmg;
        public int swmcDefAirDmg;
        public int swmcBackDmg;
        public int swmcDefBackDmg;
        public int swmcCounterDmg;
        public int swmcDefCounterDmg;
        public int swmcSpeedAtkDmg;
        public int swmcDefSpeedAtkDmg;
        public int swmcDownDmg;
        public int swmcDefDownDmg;
        public int swmcGrapResIgnore;
        public int swmcDefGrapResIgnore;
        public int swmcKBResIgnore;
        public int swmcDefKBResIgnore;
        public int swmcKDResIgnore;
        public int swmcDefKDResIgnore;
        public int swmcStunResIgnore;
        public int swmcDefStunResIgnore;
        public int swmcDmgToKama;
        public int swmcDefDmgToKama;

        //Sub-Weapon Magic Crystal - 2
        public int swmc2Id = 0;
        public string swmc2Type = "Sub-Weapon";
        public int swmc2HidenAP;
        public int swmc2DefHidenAP;
        public int swmc2IgnoreAll;
        public int swmc2DefIgnoreAll;
        public int swmc2Accuracy;
        public int swmc2DefAccuracy;
        public int swmc2DmgToHumans;
        public int swmc2DefDmgToHumans;
        public int swmc2DmgToDemi;
        public int swmc2DefDmgToDemi;
        public int swmc2Weight;
        public int swmc2DefWeight;
        public int swmc2AllRes;
        public int swmc2DefAllRes;
        public int swmc2MaxHP;
        public int swmc2DefMaxHP;
        public int swmc2MaxST;
        public int swmc2DefMaxST;
        public int swmc2DR;
        public int swmc2DefDR;
        public int swmc2Luck;
        public int swmc2DefLuck;
        public int swmc2CombatEXP;
        public int swmc2DefCombatEXP;
        public int swmc2SkillEXP;
        public int swmc2DefSkillEXP;

        public int swmc2CritDmg;
        public int swmc2DefCritDmg;
        public int swmc2AirDmg;
        public int swmc2DefAirDmg;
        public int swmc2BackDmg;
        public int swmc2DefBackDmg;
        public int swmc2CounterDmg;
        public int swmc2DefCounterDmg;
        public int swmc2SpeedAtkDmg;
        public int swmc2DefSpeedAtkDmg;
        public int swmc2DownDmg;
        public int swmc2DefDownDmg;
        public int swmc2GrapResIgnore;
        public int swmc2DefGrapResIgnore;
        public int swmc2KBResIgnore;
        public int swmc2DefKBResIgnore;
        public int swmc2KDResIgnore;
        public int swmc2DefKDResIgnore;
        public int swmc2StunResIgnore;
        public int swmc2DefStunResIgnore;
        public int swmc2DmgToKama;
        public int swmc2DefDmgToKama;


        //Helmet Magic Crystal - 1
        public int hmcId = 0;
        public string hmcType = "Helmet";
        public int hmcIgnoreAll;
        public int hmcDefIgnoreAll;
        public int hmcAccuracy;
        public int hmcDefAccuracy;
        public int hmcDmgToHumans;
        public int hmcDefDmgToHumans;
        public int hmcDmgToDemi;
        public int hmcDefDmgToDemi;
        public int hmcWeight;
        public int hmcDefWeight;
        public int hmcAllRes;
        public int hmcDefAllRes;
        public int hmcMaxHP;
        public int hmcDefMaxHP;
        public int hmcMaxST;
        public int hmcDefMaxST;
        public int hmcDR;
        public int hmcDefDR;
        public int hmcLuck;
        public int hmcDefLuck;
        public int hmcCombatEXP;
        public int hmcDefCombatEXP;
        public int hmcSkillEXP;
        public int hmcDefSkillEXP;
        public int hmcHPRecovery;
        public int hmcDefHPRecovery;
        public int hmcEV;
        public int hmcDefEV;
        public int hmcKBRes;
        public int hmcDefKBRes;
        public int hmcSSFRes;
        public int hmcDefSSFRes;
        public int hmcCastSpeed;
        public int hmcDefCastSpeed;
        public int hmcVisionRange;
        public int hmcDefVisionRange;

        //Helmet Magic Crystal - 2
        public int hmc2Id = 0;
        public string hmc2Type = "Helmet";
        public int hmc2IgnoreAll;
        public int hmc2DefIgnoreAll;
        public int hmc2Accuracy;
        public int hmc2DefAccuracy;
        public int hmc2DmgToHumans;
        public int hmc2DefDmgToHumans;
        public int hmc2DmgToDemi;
        public int hmc2DefDmgToDemi;
        public int hmc2Weight;
        public int hmc2DefWeight;
        public int hmc2AllRes;
        public int hmc2DefAllRes;
        public int hmc2MaxHP;
        public int hmc2DefMaxHP;
        public int hmc2MaxST;
        public int hmc2DefMaxST;
        public int hmc2DR;
        public int hmc2DefDR;
        public int hmc2Luck;
        public int hmc2DefLuck;
        public int hmc2CombatEXP;
        public int hmc2DefCombatEXP;
        public int hmc2SkillEXP;
        public int hmc2DefSkillEXP;
        public int hmc2HPRecovery;
        public int hmc2DefHPRecovery;
        public int hmc2EV;
        public int hmc2DefEV;
        public int hmc2KBRes;
        public int hmc2DefKBRes;
        public int hmc2SSFRes;
        public int hmc2DefSSFRes;
        public int hmc2CastSpeed;
        public int hmc2DefCastSpeed;
        public int hmc2VisionRange;
        public int hmc2DefVisionRange;

        //Armor Magic Crystal - 1
        public int amcId = 0;
        public string amcType = "Armor";
        public int amcIgnoreAll;
        public int amcDefIgnoreAll;
        public int amcAccuracy;
        public int amcDefAccuracy;
        public int amcDmgToHumans;
        public int amcDefDmgToHumans;
        public int amcDmgToDemi;
        public int amcDefDmgToDemi;
        public int amcWeight;
        public int amcDefWeight;
        public int amcAllRes;
        public int amcDefAllRes;
        public int amcMaxHP;
        public int amcDefMaxHP;
        public int amcMaxST;
        public int amcDefMaxST;
        public int amcDR;
        public int amcDefDR;
        public int amcLuck;
        public int amcDefLuck;
        public int amcCombatEXP;
        public int amcDefCombatEXP;
        public int amcSkillEXP;
        public int amcDefSkillEXP;

        public int amcMaxMP;
        public int amcDefMaxMP;
        public int amcHPRecovery;
        public int amcDefHPRecovery;
        public int amcMPRecovery;
        public int amcDefMPRecovery;
        public int amcSSFRes;
        public int amcDefSSFRes;
        public int amcSpecialAtkEvRate;
        public int amcDefSpecialAtkEvRate;
        public int amcMagicDR;
        public int amcDefMagicDR;
        public int amcMelleDR;
        public int amcDefMelleDR;
        public int amcRangeDR;
        public int amcDefRangeDR;
        public int amcSiegeWeaponEvRate;
        public int amcDefSiegeWeaponEvRate;

        //Armor Magic Crystal - 2
        public int amc2Id = 0;
        public string amc2Type = "Armor";
        public int amc2IgnoreAll;
        public int amc2DefIgnoreAll;
        public int amc2Accuracy;
        public int amc2DefAccuracy;
        public int amc2DmgToHumans;
        public int amc2DefDmgToHumans;
        public int amc2DmgToDemi;
        public int amc2DefDmgToDemi;
        public int amc2Weight;
        public int amc2DefWeight;
        public int amc2AllRes;
        public int amc2DefAllRes;
        public int amc2MaxHP;
        public int amc2DefMaxHP;
        public int amc2MaxST;
        public int amc2DefMaxST;
        public int amc2DR;
        public int amc2DefDR;
        public int amc2Luck;
        public int amc2DefLuck;
        public int amc2CombatEXP;
        public int amc2DefCombatEXP;
        public int amc2SkillEXP;
        public int amc2DefSkillEXP;

        public int amc2MaxMP;
        public int amc2DefMaxMP;
        public int amc2HPRecovery;
        public int amc2DefHPRecovery;
        public int amc2MPRecovery;
        public int amc2DefMPRecovery;
        public int amc2SSFRes;
        public int amc2DefSSFRes;
        public int amc2SpecialAtkEvRate;
        public int amc2DefSpecialAtkEvRate;
        public int amc2MagicDR;
        public int amc2DefMagicDR;
        public int amc2MelleDR;
        public int amc2DefMelleDR;
        public int amc2RangeDR;
        public int amc2DefRangeDR;
        public int amc2SiegeWeaponEvRate;
        public int amc2DefSiegeWeaponEvRate;


        //Gloves Magic Crystal - 1
        public int gmcId = 0;
        public string gmcType = "Gloves";
        public int gmcIgnoreAll;
        public int gmcDefIgnoreAll;
        public int gmcAccuracy;
        public int gmcDefAccuracy;
        public int gmcDmgToHumans;
        public int gmcDefDmgToHumans;
        public int gmcDmgToDemi;
        public int gmcDefDmgToDemi;
        public int gmcWeight;
        public int gmcDefWeight;
        public int gmcAllRes;
        public int gmcDefAllRes;
        public int gmcMaxHP;
        public int gmcDefMaxHP;
        public int gmcMaxST;
        public int gmcDefMaxST;
        public int gmcDR;
        public int gmcDefDR;
        public int gmcLuck;
        public int gmcDefLuck;
        public int gmcCombatEXP;
        public int gmcDefCombatEXP;
        public int gmcSkillEXP;
        public int gmcDefSkillEXP;

        public int gmcAtkSpeed;
        public int gmcDefAtkSpeed;
        public int gmcCastSpeed;
        public int gmcDefCastSpeed;
        public int gmcCrit;
        public int gmcDefCrit;
        public int gmcGrapRes;
        public int gmcDefGrapRes;
        public int gmcKFRes;
        public int gmcDefKFRes;
        public int gmcHidenAP;
        public int gmcDefHidenAP;
        public int gmcMagicAP;
        public int gmcDefMagicAP;
        public int gmcMelleAP;
        public int gmcDefMelleAP;
        public int gmcRangedAP;
        public int gmcDefRangedAP;

        //Gloves Magic Crystal - 2
        public int gmc2Id = 0;
        public string gmc2Type = "Gloves";
        public int gmc2IgnoreAll;
        public int gmc2DefIgnoreAll;
        public int gmc2Accuracy;
        public int gmc2DefAccuracy;
        public int gmc2DmgToHumans;
        public int gmc2DefDmgToHumans;
        public int gmc2DmgToDemi;
        public int gmc2DefDmgToDemi;
        public int gmc2Weight;
        public int gmc2DefWeight;
        public int gmc2AllRes;
        public int gmc2DefAllRes;
        public int gmc2MaxHP;
        public int gmc2DefMaxHP;
        public int gmc2MaxST;
        public int gmc2DefMaxST;
        public int gmc2DR;
        public int gmc2DefDR;
        public int gmc2Luck;
        public int gmc2DefLuck;
        public int gmc2CombatEXP;
        public int gmc2DefCombatEXP;
        public int gmc2SkillEXP;
        public int gmc2DefSkillEXP;

        public int gmc2AtkSpeed;
        public int gmc2DefAtkSpeed;
        public int gmc2CastSpeed;
        public int gmc2DefCastSpeed;
        public int gmc2Crit;
        public int gmc2DefCrit;
        public int gmc2GrapRes;
        public int gmc2DefGrapRes;
        public int gmc2KFRes;
        public int gmc2DefKFRes;
        public int gmc2HidenAP;
        public int gmc2DefHidenAP;
        public int gmc2MagicAP;
        public int gmc2DefMagicAP;
        public int gmc2MelleAP;
        public int gmc2DefMelleAP;
        public int gmc2RangedAP;
        public int gmc2DefRangedAP;

        //Shoes Magic Crystal - 1
        public int smcId = 0;
        public string smcType = "Shoes";
        public int smcIgnoreAll;
        public int smcDefIgnoreAll;
        public int smcAccuracy;
        public int smcDefAccuracy;
        public int smcDmgToHumans;
        public int smcDefDmgToHumans;
        public int smcDmgToDemi;
        public int smcDefDmgToDemi;
        public int smcWeight;
        public int smcDefWeight;
        public int smcAllRes;
        public int smcDefAllRes;
        public int smcMaxHP;
        public int smcDefMaxHP;
        public int smcMaxST;
        public int smcDefMaxST;
        public int smcDR;
        public int smcDefDR;
        public int smcLuck;
        public int smcDefLuck;
        public int smcCombatEXP;
        public int smcDefCombatEXP;
        public int smcSkillEXP;
        public int smcDefSkillEXP;

        public int smcMVSpeed;
        public int smcDefMVSpeed;
        public int smcKBRes;
        public int smcDefKBRes;
        public int smcKFRes;
        public int smcDefKFRes;
        public int smcSSFRes;
        public int smcDefSSFRes;
        public int smcJump;
        public int smcDefJump;
        public int smcFallDamage;
        public int smcDefFallDamage;
        public int smcUnderWaterBreath;
        public int smcDefUnderWaterBreath;
        public int smcMaxEnergy;
        public int smcDefMaxEnergy;

        //Shoes Magic Crystal - 2
        public int smc2Id = 0;
        public string smc2Type = "Shoes";
        public int smc2IgnoreAll;
        public int smc2DefIgnoreAll;
        public int smc2Accuracy;
        public int smc2DefAccuracy;
        public int smc2DmgToHumans;
        public int smc2DefDmgToHumans;
        public int smc2DmgToDemi;
        public int smc2DefDmgToDemi;
        public int smc2Weight;
        public int smc2DefWeight;
        public int smc2AllRes;
        public int smc2DefAllRes;
        public int smc2MaxHP;
        public int smc2DefMaxHP;
        public int smc2MaxST;
        public int smc2DefMaxST;
        public int smc2DR;
        public int smc2DefDR;
        public int smc2Luck;
        public int smc2DefLuck;
        public int smc2CombatEXP;
        public int smc2DefCombatEXP;
        public int smc2SkillEXP;
        public int smc2DefSkillEXP;

        public int smc2MVSpeed;
        public int smc2DefMVSpeed;
        public int smc2KBRes;
        public int smc2DefKBRes;
        public int smc2KFRes;
        public int smc2DefKFRes;
        public int smc2SSFRes;
        public int smc2DefSSFRes;
        public int smc2Jump;
        public int smc2DefJump;
        public int smc2FallDamage;
        public int smc2DefFallDamage;
        public int smc2UnderWaterBreath;
        public int smc2DefUnderWaterBreath;
        public int smc2MaxEnergy;
        public int smc2DefMaxEnergy;

        readonly SqlCommand cmd = Base_Connect.Connection.CreateCommand();
        

        public void BeltState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Belts where Id='" + beltId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (beltEnch == true & beltEnchLvl >= 1)
            {
                cap -= beltap;
                caap -= beltap;
                cdp -= beltdp;
                cev -= beltev;
                cacc -= beltacc;
                cRes1 -= beltResis;
                cRes2 -= beltResis;
                cRes3 -= beltResis;
                cRes4 -= beltResis;
                cDR -= beltDR;
                cMaxHP -= beltHP;
                cWeight -= beltWeight;
                cSpiritRage -= beltSpiritRage;
                ceapa -= beltAPagaingst;

                if(beltId == 6)
                {
                    if (beltEnchLvl == 2 | beltEnchLvl == 3) beltap = 15;
                    else if (beltEnchLvl == 4 ) beltap = 16;
                    else if (beltEnchLvl == 5 ) beltap = 17;
                }
                else beltap = beltDefap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);

                if (beltId == 29)
                {
                    if (beltEnchLvl == 1 | beltEnchLvl == 2) beltdp = 1;
                    else if (beltEnchLvl == 3 | beltEnchLvl == 4) beltdp = 2;
                    else if (beltEnchLvl == 5) beltdp = 3;
                }
                
                else beltdp = beltDefdp + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);

                if (beltId == 29)
                {
                    if (beltEnchLvl == 1) beltacc = 0;
                    else if (beltEnchLvl == 2 | beltEnchLvl == 3) beltacc = 2;
                    else if (beltEnchLvl == 4 | beltEnchLvl == 5) beltacc = 4;
                }
                else if (beltId == 6)
                {
                    if (beltEnchLvl == 1| beltEnchLvl == 2) beltacc = 9;
                    else if (beltEnchLvl == 3 | beltEnchLvl == 4 | beltEnchLvl == 5) beltacc = 10;
                }
                else beltacc = beltDefacc + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                beltev = beltDefev + beltEnchLvl* Convert.ToInt32(dt.Rows[0]["Evsh"]);
                beltResis = beltDefResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);

                if (beltId == 29)
                {
                    if (beltEnchLvl == 1 | beltEnchLvl == 2) beltDR = 1;
                    else if (beltEnchLvl == 3 | beltEnchLvl == 4) beltDR = 2;
                    else if (beltEnchLvl == 5) beltDR = 3;
                }
                else beltDR = beltDefDR + beltEnchLvl* Convert.ToInt32(dt.Rows[0]["DRsh"]);
                beltHP = beltDefHP + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                beltWeight = beltDefWeight + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Wgsh"]);

                if (beltId == 11)
                {
                    if (beltEnchLvl == 1) beltAPagaingst = 6;
                    else if (beltEnchLvl == 2) beltAPagaingst = 8;
                    else if (beltEnchLvl == 3) beltAPagaingst = 9;
                    else if (beltEnchLvl == 4) beltAPagaingst = 10;
                    else if (beltEnchLvl == 5) beltAPagaingst = 12;
                }
                else beltAPagaingst = beltDefAPagainst + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);
                beltSpiritRage = beltDefSpiritRage;

                cap += beltap ;
                caap += beltap ;
                cdp += beltdp;
                cev += beltev;
                cacc += beltacc;
                cRes1 += beltResis;
                cRes2 += beltResis;
                cRes3 += beltResis;
                cRes4 += beltResis ;
                cDR += beltDR;
                cMaxHP += beltHP;
                cWeight += beltWeight;
                cSpiritRage += beltSpiritRage;
                ceapa += beltAPagaingst;
            }

            else
            {
                cap -= beltap;
                caap -= beltap;
                cdp -= beltdp;
                cev -= beltev;
                cacc -= beltacc;
                cRes1 -= beltResis;
                cRes2 -= beltResis;
                cRes3 -= beltResis;
                cRes4 -= beltResis;
                cDR -= beltDR;
                cMaxHP -= beltHP;
                cWeight -= beltWeight;
                cSpiritRage -= beltSpiritRage;
                ceapa -= beltAPagaingst;

                beltap = beltDefap;
                beltdp = beltDefdp;
                beltacc = beltDefacc;
                beltev = beltDefev;
                beltResis = beltDefResis;
                beltDR = beltDefDR;
                beltHP = beltDefHP;
                beltWeight = beltDefWeight;
                beltSpiritRage = beltDefSpiritRage;
                beltAPagaingst = beltDefAPagainst;

                cap += beltap;
                caap += beltap;
                cdp += beltdp;
                cev += beltev;
                cacc += beltacc;
                cRes1 += beltResis;
                cRes2 += beltResis;
                cRes3 += beltResis;
                cRes4 += beltResis;
                cDR += beltDR;
                cMaxHP += beltHP;
                cWeight += beltWeight;
                cSpiritRage += beltSpiritRage;
                ceapa += beltAPagaingst;
            }
        }

        public void NeckState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Neck where Id='" + neckId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (neckEnch == true & neckEnchLvl >= 1)
            {
                cap -= neckap;
                caap -= neckap;
                cdp -= neckdp;
                cev -= neckev ;
                cacc -= neckacc;
                cRes1 -= neckSSF ;
                cRes2 -= neckKB ;
                cRes3 -= neckG ;
                cRes4 -= neckKF ;
                cDR -= neckDR ;
                cMaxHP -= neckHP;
                cRes1 -= neckAllRes ;
                cRes2 -= neckAllRes ;
                cRes3 -= neckAllRes ;
                cRes4 -= neckAllRes ;
                ceapa -= neckAPagaingst;
                cSpiritRage -= neckSpiritRage;

                neckap = neckDefap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);

                if (neckId == 26)
                {
                    if (neckEnchLvl == 1 | neckEnchLvl == 2) neckdp = 4;
                    else if (neckEnchLvl == 3 | neckEnchLvl == 4) neckdp = 5;
                    else if (neckEnchLvl == 5) neckdp = 6;
                }
                else neckdp = neckDefdp + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DPSh"]);

               
                if (neckId == 26)
                {
                    if (neckEnchLvl == 1) neckacc = 0;
                    else if (neckEnchLvl == 2 | neckEnchLvl == 3) neckacc = 2;
                    else if (neckEnchLvl == 4 | neckEnchLvl == 5) neckacc = 4;
                }
                else if (neckId == 5)
                {
                    if (neckEnchLvl == 1) neckacc = 16;
                    else if (neckEnchLvl == 2) neckacc = 17;
                    else if (neckEnchLvl == 3) neckacc = 18;
                    else if (neckEnchLvl == 4) neckacc = 19;
                    else if (neckEnchLvl == 5) neckacc = 20;
                }
                else neckacc = neckDefacc + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AccuracySh"]);
                neckev = neckDefev + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["EvSh"]);
                neckAllRes = neckDefAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);

                if (neckId == 26)
                {
                    if (neckEnchLvl == 1 | neckEnchLvl == 2) neckDR = 4;
                    else if (neckEnchLvl == 3 | neckEnchLvl == 4) neckDR = 5;
                    else if (neckEnchLvl == 5) neckDR = 6;
                }
                else neckDR = neckDefDR + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DRSh"]);
                neckSSF = neckDefSSF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["SSFSh"]);
                neckKB = neckDefKB + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KBSh"]);
                neckG = neckDefG + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["GrapSh"]);
                neckKF = neckDefKF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KFSh"]);
                neckHP = neckDefHP;

                neckAPagaingst = neckDefAPagainst + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);
                neckSpiritRage = neckDefSpiritRage;

                cap += neckap;
                caap += neckap;
                cdp += neckdp;
                cev += neckev;
                cacc += neckacc;
                cRes1 += neckSSF;
                cRes2 += neckKB;
                cRes3 += neckG;
                cRes4 += neckKF;
                cDR += neckDR;
                cRes1 += neckAllRes;
                cRes2 += neckAllRes;
                cRes3 += neckAllRes;
                cRes4 += neckAllRes;
                cMaxHP += neckHP;
                ceapa += neckAPagaingst;
                cSpiritRage += neckSpiritRage;
            }

            else
            {
                cap -= neckap;
                caap -= neckap;
                cdp -= neckdp;
                cev -= neckev;
                cacc -= neckacc;
                cRes1 -= neckSSF;
                cRes2 -= neckKB;
                cRes3 -= neckG;
                cRes4 -= neckKF;
                cDR -= neckDR;
                cRes1 -= neckAllRes;
                cRes2 -= neckAllRes;
                cRes3 -= neckAllRes;
                cRes4 -= neckAllRes;
                cMaxHP -= neckHP;
                ceapa -= neckAPagaingst;
                cedKama -= neckKamaDamage;
                cSpiritRage -= neckSpiritRage;
                cEDtoBack -= neckBackDamage;

                neckap = neckDefap;
                neckdp = neckDefdp;
                neckacc = neckDefacc;
                neckev = neckDefev;
                neckAllRes = neckDefAllRes;
                neckDR = neckDefDR;
                neckSSF = neckDefSSF;
                neckKB = neckDefKB;
                neckG = neckDefG;
                neckKF = neckDefKF;
                neckHP = neckDefHP;
                neckSpiritRage = neckDefSpiritRage;
                neckAPagaingst = neckDefAPagainst;
                neckKamaDamage = neckDefKamaDamage;
                neckBackDamage = neckDefBackDamage;


                cap += neckap;
                caap += neckap;
                cdp += neckdp;
                cev += neckev;
                cacc += neckacc;
                cRes1 += neckSSF;
                cRes2 += neckKB;
                cRes3 += neckG;
                cRes4 += neckKF;
                cDR += neckDR;
                cRes1 += neckAllRes;
                cRes2 += neckAllRes;
                cRes3 += neckAllRes;
                cRes4 += neckAllRes;
                cMaxHP += neckHP;
                ceapa += neckAPagaingst;
                cedKama += neckKamaDamage;
                cSpiritRage += neckSpiritRage;
                cEDtoBack += neckBackDamage;
            }
        }

        public void Ring1State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rings where Id='" + ring1Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ring1Ench == true & ring1EnchLvl >= 1)
            {
                cap -= ring1ap;
                caap -= ring1ap;
                cdp -= ring1dp;
                cev -= ring1ev;
                cacc -= ring1acc;
                cDR -= ring1DR;
                cMaxHP -= ring1HP;
                cMaxMP -= ring1MP;
                cMaxST -= ring1ST;
                chev -= ring1HEv;
                ceapa -= ring1APagaingst;
                cedh -= ring1DamageHumans;
                cADtDemiH -= ring1DamageDemihumans;
                cADtoAllWithExcept -= ring1DamageAllExcept;
                cSpiritRage -= ring1SpiritRage;

                if (ring1Id == 3)
                {
                    if (ring1EnchLvl == 1) ring1ap = 14;
                    else if (ring1EnchLvl == 2 | ring1EnchLvl == 3) ring1ap = 15;
                    else if (ring1EnchLvl == 4 ) ring1ap = 16;
                    else if (ring1EnchLvl == 5) ring1ap = 17;
                }
                   else ring1ap = ring1Defap + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                if(ring1Id == 25)
                {
                    if (ring1EnchLvl == 1 | ring1EnchLvl == 2) ring1dp = 3;
                    else if (ring1EnchLvl == 3 | ring1EnchLvl == 4) ring1dp = 4;
                    else if (ring1EnchLvl == 5) ring1dp = 5;
                }
                else ring1dp = ring1Defdp + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);


                if(ring1Id == 10)
                {
                    if (ring1EnchLvl == 1) ring1acc = 6;
                    else if (ring1EnchLvl == 2) ring1acc = 8;
                    else if (ring1EnchLvl == 3) ring1acc = 9;
                    else if (ring1EnchLvl == 4) ring1acc = 10;
                    else if (ring1EnchLvl == 5) ring1acc = 12;
                }
                else if(ring1Id == 25)
                {
                    if (ring1EnchLvl == 1) ring1acc = 0;
                    else if (ring1EnchLvl == 2 | ring1EnchLvl == 3) ring1acc = 2;
                    else if (ring1EnchLvl == 4 | ring1EnchLvl == 5) ring1acc = 4;
                }
                else if (ring1Id == 3)
                {
                    if (ring1EnchLvl == 1 | ring1EnchLvl == 2) ring1acc = 9;
                    else if (ring1EnchLvl == 3 | ring1EnchLvl == 4 |ring1EnchLvl == 5) ring1acc = 10;
                }
                else ring1acc = ring1Defacc + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);

                    ring1ev = ring1Defev + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);

                if(ring1Id == 25)
                {
                    if (ring1EnchLvl == 1| ring1EnchLvl == 2) ring1DR = 3;
                    else if (ring1EnchLvl == 3 | ring1EnchLvl == 4) ring1DR = 4;
                    else if (ring1EnchLvl == 5) ring1DR = 5;
                }
                   else ring1DR = ring1DefDR + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                    ring1HP = ring1DefHP + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                    ring1MP = ring1DefMP + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                    ring1ST = ring1DefST + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);
                ring1HEv = ring1DefHEv;

                if(ring1Id == 10)
                {
                    if (ring1EnchLvl == 1) ring1APagaingst = 2;
                    else if (ring1EnchLvl == 2) ring1APagaingst = 3;
                    else if (ring1EnchLvl == 3) ring1APagaingst = 4;
                    else if (ring1EnchLvl == 4) ring1APagaingst = 5;
                    else if (ring1EnchLvl == 5) ring1APagaingst = 7;
                }
                else ring1APagaingst = ring1DefAPagainst + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);

                //Extra Damage to Humans
                ring1DamageHumans = ring1DefDamageHumans + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["shHumanDamage"]);
                //Additional damage to Demihumans
                ring1DamageDemihumans = ring1DefDamageDemihumans + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["shDemiHumanDamage"]);
                //Extra damage to all species except Humans and demihumans
                ring1DamageAllExcept = ring1DefDamageAllExcept + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["shDamAllExHuman"]);
                ring1SpiritRage = ring1DefSpiritRage;

                cap += ring1ap;
                caap += ring1ap;
                cdp += ring1dp;
                cev += ring1ev;
                cacc += ring1acc;
                cDR += ring1DR;
                cMaxHP += ring1HP;
                cMaxMP += ring1MP;
                cMaxST += ring1ST;
                chev += ring1HEv;
                ceapa += ring1APagaingst;
                cedh += ring1DamageHumans;
                cADtDemiH += ring1DamageDemihumans;
                cADtoAllWithExcept += ring1DamageAllExcept;
                cSpiritRage += ring1SpiritRage;

            }

            else
            {
                cap -= ring1ap;
                caap -= ring1ap;
                cdp -= ring1dp;
                cev -= ring1ev;
                cacc -= ring1acc;
                cDR -= ring1DR;
                cMaxHP -= ring1HP;
                cMaxMP -= ring1MP;
                cMaxST -= ring1ST;
                chev -= ring1HEv;
                ceapa -= ring1APagaingst;
                cedKama -= ring1KamaDamage;
                cedh -= ring1DamageHumans;
                cADtDemiH -= ring1DamageDemihumans;
                cADtoAllWithExcept -= ring1DamageAllExcept;
                cSpiritRage -= ring1SpiritRage;
                cBidding -= ring1Bidding;


                ring1ap = ring1Defap;
                ring1dp = ring1Defdp;
                ring1acc = ring1Defacc;
                ring1ev = ring1Defev;
                ring1DR = ring1DefDR;
                ring1HP = ring1DefHP;
                ring1MP = ring1DefMP;
                ring1ST = ring1DefST;
                ring1HEv = ring1DefHEv;
                ring1APagaingst = ring1DefAPagainst;
                ring1KamaDamage = ring1DefKamaDamage;
                ring1DamageHumans = ring1DefDamageHumans;
                ring1DamageDemihumans = ring1DefDamageDemihumans;
                ring1DamageAllExcept = ring1DefDamageAllExcept;
                ring1SpiritRage = ring1DefSpiritRage;
                ring1Bidding = ring1DefBidding;

                cap += ring1ap;
                caap += ring1ap;
                cdp += ring1dp;
                cev += ring1ev;
                cacc += ring1acc;
                cDR += ring1DR;
                cMaxHP += ring1HP;
                cMaxMP += ring1MP;
                cMaxST += ring1ST;
                chev += ring1HEv;
                ceapa += ring1APagaingst;
                cedKama += ring1KamaDamage;
                cedh += ring1DamageHumans;
                cADtDemiH += ring1DamageDemihumans;
                cADtoAllWithExcept += ring1DamageAllExcept;
                cSpiritRage += ring1SpiritRage;
                cBidding += ring1Bidding;

            }
        }

        public void Ring2State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rings where Id='" + ring2Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ring2Ench == true & ring2EnchLvl >= 1)
            {
                cap -= ring2ap;
                caap -= ring2ap;
                cdp -= ring2dp;
                cev -= ring2ev;
                cacc -= ring2acc;
                cDR -= ring2DR;
                cMaxHP -= ring2HP;
                cMaxMP -= ring2MP;
                cMaxST -= ring2ST;
                chev -= ring2HEv;
                ceapa -= ring2APagaingst;
                cedh -= ring2DamageHumans;
                cADtDemiH -= ring2DamageDemihumans;
                cADtoAllWithExcept -= ring2DamageAllExcept;
                cSpiritRage -= ring2SpiritRage;

                if (ring2Id == 3)
                {
                    if (ring2EnchLvl == 1) ring2ap = 14;
                    else if (ring2EnchLvl == 2 | ring2EnchLvl == 3) ring2ap = 15;
                    else if (ring2EnchLvl == 4) ring2ap = 16;
                    else if (ring2EnchLvl == 5) ring2ap = 17;
                }
                else ring2ap = ring2Defap + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                if (ring2Id == 25)
                {
                    if (ring2EnchLvl == 1 | ring2EnchLvl == 2) ring2dp = 3;
                    else if (ring2EnchLvl == 3 | ring2EnchLvl == 4) ring2dp = 4;
                    else if (ring2EnchLvl == 5) ring2dp = 5;
                }
                else ring2dp = ring2Defdp + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);


                if (ring2Id == 10)
                {
                    if (ring2EnchLvl == 1) ring2acc = 6;
                    else if (ring2EnchLvl == 2) ring2acc = 8;
                    else if (ring2EnchLvl == 3) ring2acc = 9;
                    else if (ring2EnchLvl == 4) ring2acc = 10;
                    else if (ring2EnchLvl == 5) ring2acc = 12;
                }
                else if (ring2Id == 25)
                {
                    if (ring2EnchLvl == 1) ring2acc = 0;
                    else if (ring2EnchLvl == 2 | ring2EnchLvl == 3) ring2acc = 2;
                    else if (ring2EnchLvl == 4 | ring2EnchLvl == 5) ring2acc = 4;
                }
                else if (ring2Id == 3)
                {
                    if (ring2EnchLvl == 1 | ring2EnchLvl == 2) ring2acc = 9;
                    else if (ring2EnchLvl == 3 | ring2EnchLvl == 4 | ring2EnchLvl == 5) ring2acc = 10;
                }
                else ring2acc = ring2Defacc + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);

                ring2ev = ring2Defev + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);

                if (ring2Id == 25)
                {
                    if (ring2EnchLvl == 1 | ring2EnchLvl == 2) ring2DR = 3;
                    else if (ring2EnchLvl == 3 | ring2EnchLvl == 4) ring2DR = 4;
                    else if (ring2EnchLvl == 5) ring2DR = 5;
                }
                else ring2DR = ring2DefDR + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ring2HP = ring2DefHP + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ring2MP = ring2DefMP + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ring2ST = ring2DefST + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);
                ring2HEv = ring2DefHEv;

                if (ring2Id == 10)
                {
                    if (ring2EnchLvl == 1) ring2APagaingst = 2;
                    else if (ring2EnchLvl == 2) ring2APagaingst = 3;
                    else if (ring2EnchLvl == 3) ring2APagaingst = 4;
                    else if (ring2EnchLvl == 4) ring2APagaingst = 5;
                    else if (ring2EnchLvl == 5) ring2APagaingst = 7;
                }
                else ring2APagaingst = ring2DefAPagainst + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);

                //Extra Damage to Humans
                ring2DamageHumans = ring2DefDamageHumans + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["shHumanDamage"]);
                //Additional damage to Demihumans
                ring2DamageDemihumans = ring2DefDamageDemihumans + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["shDemiHumanDamage"]);
                //Extra damage to all species except Humans and demihumans
                ring2DamageAllExcept = ring2DefDamageAllExcept + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["shDamAllExHuman"]);
                ring2SpiritRage = ring2DefSpiritRage;

                cap += ring2ap;
                caap += ring2ap;
                cdp += ring2dp;
                cev += ring2ev;
                cacc += ring2acc;
                cDR += ring2DR;
                cMaxHP += ring2HP;
                cMaxMP += ring2MP;
                cMaxST += ring2ST;
                chev += ring2HEv;
                ceapa += ring2APagaingst;
                cedh += ring2DamageHumans;
                cADtDemiH += ring2DamageDemihumans;
                cADtoAllWithExcept += ring2DamageAllExcept;
                cSpiritRage += ring2SpiritRage;

            }

            else
            {
                cap -= ring2ap;
                caap -= ring2ap;
                cdp -= ring2dp;
                cev -= ring2ev;
                cacc -= ring2acc;
                cDR -= ring2DR;
                cMaxHP -= ring2HP;
                cMaxMP -= ring2MP;
                cMaxST -= ring2ST;
                chev -= ring2HEv;
                ceapa -= ring2APagaingst;
                cedKama -= ring2KamaDamage;
                cedh -= ring2DamageHumans;
                cADtDemiH -= ring2DamageDemihumans;
                cADtoAllWithExcept -= ring2DamageAllExcept;
                cSpiritRage -= ring2SpiritRage;
                cBidding -= ring2Bidding;


                ring2ap = ring2Defap;
                ring2dp = ring2Defdp;
                ring2acc = ring2Defacc;
                ring2ev = ring2Defev;
                ring2DR = ring2DefDR;
                ring2HP = ring2DefHP;
                ring2MP = ring2DefMP;
                ring2ST = ring2DefST;
                ring2HEv = ring2DefHEv;
                ring2APagaingst = ring2DefAPagainst;
                ring2KamaDamage = ring2DefKamaDamage;
                ring2DamageHumans = ring2DefDamageHumans;
                ring2DamageDemihumans = ring2DefDamageDemihumans;
                ring2DamageAllExcept = ring2DefDamageAllExcept;
                ring2SpiritRage = ring2DefSpiritRage;
                ring2Bidding = ring2DefBidding;

                cap += ring2ap;
                caap += ring2ap;
                cdp += ring2dp;
                cev += ring2ev;
                cacc += ring2acc;
                cDR += ring2DR;
                cMaxHP += ring2HP;
                cMaxMP += ring2MP;
                cMaxST += ring2ST;
                chev += ring2HEv;
                ceapa += ring2APagaingst;
                cedKama += ring2KamaDamage;
                cedh += ring2DamageHumans;
                cADtDemiH += ring2DamageDemihumans;
                cADtoAllWithExcept += ring2DamageAllExcept;
                cSpiritRage += ring2SpiritRage;
                cBidding += ring2Bidding;

            }
        }

        public void Earring1State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Earrings where Id='" + ear1Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ear1Ench == true & ear1EnchLvl >= 1)
            {
                cap -= ear1ap;
                caap -= ear1ap;
                cdp -= ear1dp;
                cev -= ear1ev;
                cacc -= ear1acc;
                cDR -= ear1DR;
                cMaxHP -= ear1HP;
                cMaxMP -= ear1MP;
                cMaxST -= ear1ST;

                ceapa -= ear1APagaingst;
                cedKama -= ear1KamaDamage;
                cSpiritRage -= ear1SpiritRage;

                ear1ap = ear1Defap + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);

                if (ear1Id == 25)
                {
                    if (ear1EnchLvl == 1 | ear1EnchLvl == 2) ear1dp = 1;
                    else if (ear1EnchLvl == 3 | ear1EnchLvl == 4) ear1dp = 2;
                    else if (ear1EnchLvl == 5) ear1dp = 3;
                }
                else if(ear1Id == 6)
                {
                    if (ear1EnchLvl == 2) ear1dp = 1;
                    else if (ear1EnchLvl == 3) ear1dp = 2;
                    else if (ear1EnchLvl == 4) ear1dp = 3;
                    else if (ear1EnchLvl == 5) ear1dp = 4;
                }
                else ear1dp = ear1Defdp + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);

                if (ear1Id == 9)
                {
                    if (ear1EnchLvl == 1) ear1acc = 2;
                    else if (ear1EnchLvl == 2) ear1acc = 3;
                    else if (ear1EnchLvl == 3) ear1acc = 4;
                    else if (ear1EnchLvl == 4) ear1acc = 5;
                    else if (ear1EnchLvl == 5) ear1acc = 7;
                }
                else if (ear1Id == 25)
                {
                    if (ear1EnchLvl == 1) ear1acc = 0;
                    else if (ear1EnchLvl == 2 | ear1EnchLvl == 3) ear1acc = 2;
                    else if (ear1EnchLvl == 4 | ear1EnchLvl == 5) ear1acc = 4;
                }
                else if (ear1Id == 6)
                {
                    if (ear1EnchLvl == 1) ear1acc = 9;
                    else if (ear1EnchLvl == 2) ear1acc = 10;
                    else if (ear1EnchLvl == 3) ear1acc = 11;
                    else if (ear1EnchLvl == 4 | ear1EnchLvl == 5) ear1acc = 12;
                }
                else ear1acc = ear1Defacc + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);

                ear1ev = ear1Defev + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                if(ear1Id == 25)
                {
                    if (ear1EnchLvl == 1 | ear1EnchLvl == 2) ear1DR = 1;
                    else if (ear1EnchLvl == 3 | ear1EnchLvl == 4) ear1DR = 2;
                    else if (ear1EnchLvl == 5) ear1DR = 3;
                }
                else ear1DR = ear1DefDR + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ear1HP = ear1DefHP + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ear1MP = ear1DefMP + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ear1ST = ear1DefST + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);

                if (ear1Id == 9)
                {
                    if (ear1EnchLvl == 1) ear1APagaingst = 6;
                    else if (ear1EnchLvl == 2) ear1APagaingst = 8;
                    else if (ear1EnchLvl == 3) ear1APagaingst = 9;
                    else if (ear1EnchLvl == 4) ear1APagaingst = 10;
                    else if (ear1EnchLvl == 5) ear1APagaingst = 12;
                }
                else ear1APagaingst = ear1DefAPagainst + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);
                ear1SpiritRage = ear1DefSpiritRage;

                ear1KamaDamage = ear1DefKamaDamage + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["shKamaDamage"]);

                cap += ear1ap;
                caap += ear1ap;
                cdp += ear1dp;
                cev += ear1ev;
                cacc += ear1acc;
                cDR += ear1DR;
                cMaxHP += ear1HP;
                cMaxMP += ear1MP;
                cMaxST += ear1ST;
                ceapa += ear1APagaingst;
                cedKama += ear1KamaDamage;
                cSpiritRage += ear1SpiritRage;
            }

            else
            {
                cap -= ear1ap;
                caap -= ear1ap;
                cdp -= ear1dp;
                cev -= ear1ev;
                cacc -= ear1acc;
                cDR -= ear1DR;
                cMaxHP -= ear1HP;
                cMaxMP -= ear1MP;
                cMaxST -= ear1ST;
                ceapa -= ear1APagaingst;
                cedKama -= ear1KamaDamage;
                cSpiritRage -= ear1SpiritRage;

                ear1ap = ear1Defap;
                ear1dp = ear1Defdp;
                ear1acc = ear1Defacc;
                ear1ev = ear1Defev;
                ear1DR = ear1DefDR;
                ear1HP = ear1DefHP;
                ear1MP = ear1DefMP;
                ear1ST = ear1DefST;
                ear1SpiritRage = ear1DefSpiritRage;
                ear1APagaingst = ear1DefAPagainst;
                ear1KamaDamage = ear1DefKamaDamage;

                cap += ear1ap;
                caap += ear1ap;
                cdp += ear1dp;
                cev += ear1ev;
                cacc += ear1acc;
                cDR += ear1DR;
                cMaxHP += ear1HP;
                cMaxMP += ear1MP;
                cMaxST += ear1ST;
                ceapa += ear1APagaingst;
                cedKama += ear1KamaDamage;
                cSpiritRage += ear1SpiritRage;
            }
        }

        public void Earring2State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Earrings where Id='" + ear2Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ear2Ench == true & ear2EnchLvl >= 1)
            {
                cap -= ear2ap;
                caap -= ear2ap;
                cdp -= ear2dp;
                cev -= ear2ev;
                cacc -= ear2acc;
                cDR -= ear2DR;
                cMaxHP -= ear2HP;
                cMaxMP -= ear2MP;
                cMaxST -= ear2ST;

                ceapa -= ear2APagaingst;
                cedKama -= ear2KamaDamage;
                cSpiritRage -= ear2SpiritRage;

                ear2ap = ear2Defap + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);

                if (ear2Id == 25)
                {
                    if (ear2EnchLvl == 1 | ear2EnchLvl == 2) ear2dp = 1;
                    else if (ear2EnchLvl == 3 | ear2EnchLvl == 4) ear2dp = 2;
                    else if (ear2EnchLvl == 5) ear2dp = 3;
                }
                else if (ear2Id == 6)
                {
                    if (ear2EnchLvl == 2) ear2dp = 1;
                    else if (ear2EnchLvl == 3) ear2dp = 2;
                    else if (ear2EnchLvl == 4) ear2dp = 3;
                    else if (ear2EnchLvl == 5) ear2dp = 4;
                }
                else ear2dp = ear2Defdp + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);

                if (ear2Id == 9)
                {
                    if (ear2EnchLvl == 1) ear2acc = 2;
                    else if (ear2EnchLvl == 2) ear2acc = 3;
                    else if (ear2EnchLvl == 3) ear2acc = 4;
                    else if (ear2EnchLvl == 4) ear2acc = 5;
                    else if (ear2EnchLvl == 5) ear2acc = 7;
                }
                else if (ear2Id == 25)
                {
                    if (ear2EnchLvl == 1) ear2acc = 0;
                    else if (ear2EnchLvl == 2 | ear2EnchLvl == 3) ear2acc = 2;
                    else if (ear2EnchLvl == 4 | ear2EnchLvl == 5) ear2acc = 4;
                }
                else if (ear2Id == 6)
                {
                    if (ear2EnchLvl == 1) ear2acc = 9;
                    else if (ear2EnchLvl == 2) ear2acc = 10;
                    else if (ear2EnchLvl == 3) ear2acc = 11;
                    else if (ear2EnchLvl == 4 | ear2EnchLvl == 5) ear2acc = 12;
                }
                else ear2acc = ear2Defacc + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);

                ear2ev = ear2Defev + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                if (ear2Id == 25)
                {
                    if (ear2EnchLvl == 1 | ear2EnchLvl == 2) ear2DR = 1;
                    else if (ear2EnchLvl == 3 | ear2EnchLvl == 4) ear2DR = 2;
                    else if (ear2EnchLvl == 5) ear2DR = 3;
                }
                else ear2DR = ear2DefDR + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ear2HP = ear2DefHP + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ear2MP = ear2DefMP + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ear2ST = ear2DefST + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);

                if (ear2Id == 9)
                {
                    if (ear2EnchLvl == 1) ear2APagaingst = 6;
                    else if (ear2EnchLvl == 2) ear2APagaingst = 8;
                    else if (ear2EnchLvl == 3) ear2APagaingst = 9;
                    else if (ear2EnchLvl == 4) ear2APagaingst = 10;
                    else if (ear2EnchLvl == 5) ear2APagaingst = 12;
                }
                else ear2APagaingst = ear2DefAPagainst + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["shApAgainst"]);
                ear2SpiritRage = ear2DefSpiritRage;

                ear2KamaDamage = ear2DefKamaDamage + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["shKamaDamage"]);

                cap += ear2ap;
                caap += ear2ap;
                cdp += ear2dp;
                cev += ear2ev;
                cacc += ear2acc;
                cDR += ear2DR;
                cMaxHP += ear2HP;
                cMaxMP += ear2MP;
                cMaxST += ear2ST;
                ceapa += ear2APagaingst;
                cedKama += ear2KamaDamage;
                cSpiritRage += ear2SpiritRage;
            }

            else
            {
                cap -= ear2ap;
                caap -= ear2ap;
                cdp -= ear2dp;
                cev -= ear2ev;
                cacc -= ear2acc;
                cDR -= ear2DR;
                cMaxHP -= ear2HP;
                cMaxMP -= ear2MP;
                cMaxST -= ear2ST;
                ceapa -= ear2APagaingst;
                cedKama -= ear2KamaDamage;
                cSpiritRage -= ear2SpiritRage;

                ear2ap = ear2Defap;
                ear2dp = ear2Defdp;
                ear2acc = ear2Defacc;
                ear2ev = ear2Defev;
                ear2DR = ear2DefDR;
                ear2HP = ear2DefHP;
                ear2MP = ear2DefMP;
                ear2ST = ear2DefST;
                ear2SpiritRage = ear2DefSpiritRage;
                ear2APagaingst = ear2DefAPagainst;
                ear2KamaDamage = ear2DefKamaDamage;

                cap += ear2ap;
                caap += ear2ap;
                cdp += ear2dp;
                cev += ear2ev;
                cacc += ear2acc;
                cDR += ear2DR;
                cMaxHP += ear2HP;
                cMaxMP += ear2MP;
                cMaxST += ear2ST;
                ceapa += ear2APagaingst;
                cedKama += ear2KamaDamage;
                cSpiritRage += ear2SpiritRage;
            }
        }

        public void ArmorState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Armors where Id='" + armId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (armEnch == true & armIsBoss == true | armId ==23)
            {
                if(armEnchLvl >= 1 & armEnchLvl <= 5)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + armEnchLvl * 3;
                    armev = armDefev + armEnchLvl * 1;
                    armhev = armDefhev + armEnchLvl * 3;
                    armdr = armDefdr + armEnchLvl * 2;
                    armhdr = armDefhdr + armEnchLvl * 0;
                    armMP = armDefMP;
                    armHP = armDefHP;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl >= 6 & armEnchLvl <= 15)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    armhev = armDefhev + 15 + (armEnchLvl - 5) * 6;
                    armdr = armDefdr + armEnchLvl * 2;
                    armhdr = armDefhdr;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl >= 16 & armEnchLvl <= 17)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 55 +(armEnchLvl-15) * 5;
                    armev = armDefev + 25+ (armEnchLvl - 15) * 2;
                    armhev = armDefhev + 75+ (armEnchLvl - 15) * 6;
                    armdr = armDefdr + 30 +(armEnchLvl - 15) * 3;
                    armhdr = armDefhdr + (armEnchLvl - 15) * 1;
                    armMP = armDefMP;
                    armHP = armDefHP;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 18)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 73;
                    armev = armDefev + 31;
                    armhev = armDefhev + 93;
                    armdr = armDefdr + 42;
                    armhdr = armDefhdr + 4;
                    armMP = armDefMP;
                    armHP = armDefHP;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 19)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 78;
                    armev = armDefev + 33;
                    armhev = armDefhev + 99;
                    armdr = armDefdr + 45;
                    armhdr = armDefhdr + 8;
                    armMP = armDefMP;
                    armHP = armDefHP;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 20)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 83;
                    armev = armDefev + 35;
                    armhev = armDefhev + 105;
                    armdr = armDefdr + 48;
                    armhdr = armDefhdr + 14;
                    armMP = armDefMP;
                    armHP = armDefHP;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }
            }

            else if(armEnch == true & armIsBoss == false)
            {
                if (armEnchLvl == 1)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;


                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 3;
                    else armdp = armDefdp +  4;
                    //EV
                    armev = armDefev + 1;
                    //HEV
                    if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 7;
                    else armhev = armDefhev + 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 3;
                    //HDR
                    armhdr = armDefhdr;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;

                }

                if (armEnchLvl >= 2 & armEnchLvl <= 3)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;

                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + armEnchLvl * 3;
                    else armdp = armDefdp + 4 + (armEnchLvl-1) * 3;
                    //EV
                    armev = armDefev +armEnchLvl * 1;
                    //HEV
                    if(armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl == 2) armhev = armDefhev + 9;
                        else if (armEnchLvl == 3) armhev = armDefhev + 12;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr +3 +(armEnchLvl-1) * 2;
                    //HDR
                    armhdr = armDefhdr;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl >= 4 & armEnchLvl <= 5)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DP
                    if (armId == 10 | armId == 19 ) armdp = armDefdp + armEnchLvl * 3;
                    else armdp = armDefdp + 10 + (armEnchLvl - 3) * 2;
                    //EV
                    armev = armDefev + armEnchLvl * 1;
                    //HEV
                    if(armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl == 4) armhev = armDefhev + 14;
                        else if (armEnchLvl == 5) armhev = armDefhev + 17;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 7 + (armEnchLvl - 3) * 1;
                    //HDR
                    armhdr = armDefhdr;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl >= 6 & armEnchLvl <= 15)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 14 + (armEnchLvl - 5) * 3;

                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + armEnchLvl * 1;

                    //HEV
                    if(armId == 10 | armId == 19) 
                    {
                        if (armEnchLvl <= 10) armhev = armDefhev + 15 + (armEnchLvl - 5) * 6;
                        else if (armEnchLvl == 11) armhev = armDefhev + 50;
                        else if (armEnchLvl >= 12) armhev = armDefhev + 50 + (armEnchLvl - 11) * 6;
                    } //Akum
                    else if(armId == 9| armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl ==6) armhev = armDefhev + 21;
                        else if (armEnchLvl == 7) armhev = armDefhev + 24;
                        else if (armEnchLvl == 8) armhev = armDefhev + 28;
                        else if (armEnchLvl == 9) armhev = armDefhev + 31;
                        else if (armEnchLvl >= 10) armhev = armDefhev + 31 + (armEnchLvl - 9) * 3;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;

                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 9 + (armEnchLvl - 5) * 2;

                    //HDR
                    if (armId == 10 & armEnchLvl >= 11 | armId == 19 & armEnchLvl >= 11) armhdr = armDefhdr + (armEnchLvl-10) * 1;
                    else armhdr = armDefhdr;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl == 16)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DR
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 49;
                    //Ev
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 17;

                    //Hev
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79; //Akum
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 55; //Agerian, Taritas, Zereth
                    else armhev = armDefhev + 55;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 32;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + (armEnchLvl - 10) * 1;
                    else armhdr = armDefhdr + 1;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl == 17)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 54;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 19;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 61;
                    else armhev = armDefhev + 61;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 35;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + (armEnchLvl - 10) * 1;
                    else armhdr = armDefhdr + 2;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl == 18)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 70;
                    else armdp = armDefdp + 62;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 21;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 67;
                    else armhev = armDefhev + 67;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + (armEnchLvl-1) * 2 + 5;
                    else  if (armId == 9 | armId == 24) armdr = armDefdr + 41;
                    else armdr = armDefdr + 41;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + 9;
                    else armhdr = armDefhdr + 3;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }

                if (armEnchLvl >= 19 & armEnchLvl <= 20)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;
                    chpr -= armHPRecovery;
                    cmpr -= armMPRecovery;
                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 70 + (armEnchLvl-18) * 4;
                    else armdp = armDefdp + 62 + (armEnchLvl-18)  * 5;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 21 + (armEnchLvl - 18) * 2;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 67 + (armEnchLvl -18) * 6;
                    else armhev = armDefhev + 67+ (armEnchLvl - 18) * 6;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + 39 + (armEnchLvl-18) * 2;
                    else if (armId == 9 | armId == 24) armdr = armDefdr + 41 + (armEnchLvl - 18) * 3;
                    else armdr = armDefdr + 41+ (armEnchLvl - 18) * 3;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + 9+(armEnchLvl - 18) * 2;
                    else armhdr = armDefhdr + 3+ (armEnchLvl - 18) * 1;
                    armWeight = armDefWeight;
                    armHP = armDefHP;
                    armMP = armDefMP;
                    armHPRecovery = armDefHPRecovery;
                    armMPRecovery = armDefMPRecovery;
                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;
                    chpr += armHPRecovery;
                    cmpr += armMPRecovery;
                }
            }

            if (armEnch == false | armEnch == true & armEnchLvl == 0)
            {

                cdp -= armdp;
                cev -= armev;
                chev -= armhev;
                cDR -= armdr;
                chdr -= armhdr;
                cMaxHP -= armHP;
                cMaxMP -= armMP;
                cRes1 -= armSSFRes;
                cWeight -= armWeight;
                cacc -= armAcc;
                chpr -= armHPRecovery;
                cmpr -= armMPRecovery;

                armdp = armDefdp;
                armev = armDefev;
                armhev = armDefhev;
                armdr = armDefdr;
                armhdr = armDefhdr;
                armHP = armDefHP;
                armMP = armDefMP;
                armWeight = armDefWeight;
                armAcc = armDefAcc;
                armHPRecovery = armDefHPRecovery;
                armMPRecovery = armDefMPRecovery;


                cdp += armdp;
                cev += armev;
                chev += armhev;
                cDR += armdr;
                chdr += armhdr;
                cMaxHP += armHP;
                cMaxMP += armMP;
                cRes1 += armSSFRes;
                cWeight += armWeight;
                cacc += armAcc;
                chpr += armHPRecovery;
                cmpr += armMPRecovery;
            }
        }

        public void HelmetState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Helmets where Id='" + helId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (helEnch == true & helIsBoss == true | helId == 21)
            {
                if (helEnchLvl >= 1 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + helEnchLvl * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 2;
                    heldr = helDefdr + helEnchLvl * 2;
                    helhdr = helDefhdr + helEnchLvl * 0;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 50;
                    helev = helDefev + 17;
                    helhev = helDefhev + 38;
                    heldr = helDefdr + 33;
                    helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 55;
                    helev = helDefev + 19;
                    helhev = helDefhev + 42;
                    heldr = helDefdr + 36;
                    if (helId == 0 | helId == 21) helhdr = helDefhdr + 2;
                    else helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 63;
                    helev = helDefev + 21;
                    helhev = helDefhev + 46;
                    heldr = helDefdr + 42;
                    if (helId == 0 | helId == 21) helhdr = helDefhdr + 4;
                    else helhdr = helDefhdr + 6;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 19)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 68;
                    helev = helDefev + 23;
                    helhev = helDefhev + 50;
                    heldr = helDefdr + 45;
                    if (helId == 0 | helId == 21) helhdr = helDefhdr + 8;
                    else helhdr = helDefhdr + 11;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 73;
                    helev = helDefev + 25;
                    helhev = helDefhev + 54;
                    heldr = helDefdr + 48;
                    if (helId == 0 | helId == 21)  helhdr = helDefhdr + 14;
                    else helhdr = helDefhdr + 17;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

            }

            else if (helEnch == true & helIsBoss == false)
            {
                if (helEnchLvl >= 1 & helEnchLvl <=2)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl == 1) heldp = helDefdp + 2;
                        else heldp = helDefdp + 5;
                    }
                    else heldp = helDefdp + helEnchLvl * 3;

                    helev = helDefev + helEnchLvl * 1;

                    if(helId == 8 | helId == 13 | helId == 14  | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 1) helhev = helDefhev + 7;
                        else helhev = helDefhev + 9;
                    }
                    else if(helId == 9 | helId == 19) helhev = helDefhev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl == 1) heldr = helDefdr + 1;
                        else heldr = helDefdr + 3;
                    }
                    else heldr = helDefdr + helEnchLvl * 2;

                    helhdr = helDefhdr;

                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 3 & helEnchLvl <= 5)
                {
                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 2 + (helEnchLvl-2) *3;
                    else heldp = helDefdp + 6 + (helEnchLvl - 2) * 3;
                    helev = helDefev + helEnchLvl * 1;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 3) helhev = helDefhev + 10;
                        else if (helEnchLvl == 4) helhev = helDefhev + 12;
                        else helhev = helDefhev + 15;
                    }
                    else if (helId == 9 | helId == 19) helhev = helDefhev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 1 + (helEnchLvl-1) * 2 ;
                    else heldr = helDefdr + 4 + (helEnchLvl - 2) * 2;

                    helhdr = helDefhdr;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 6 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 14 + (helEnchLvl - 5) * 3;
                    else heldp = helDefdp + 12 + (helEnchLvl - 5) * 3;

                    helev = helDefev + helEnchLvl * 1;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 6) helhev = helDefhev + 21;
                        else if (helEnchLvl == 7) helhev = helDefhev + 24;
                        else if (helEnchLvl == 8) helhev = helDefhev + 28;
                        else if (helEnchLvl == 9) helhev = helDefhev + 31;
                        else if (helEnchLvl >= 10) helhev = helDefhev + 31 + (helEnchLvl - 9) * 3;
                    }
                    else if (helId == 9 | helId == 19) helhev = helDefhev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 1 + (helEnchLvl - 1) * 2;
                    else heldr = helDefdr + 7 + (helEnchLvl - 5) * 2;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl >= 11) helhdr = helDefhdr + (helEnchLvl - 10) * 1;
                        else helhdr = helDefhdr;
                    }
                    else helhdr = helDefhdr;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 48;
                    else heldp = helDefdp + 47 ;

                    helev = helDefev + 17;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 55;
                    else if (helId == 9 | helId == 19) helhev = helDefhev + 36;
                    else helhev = helDefhev + 55;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 31;
                    else heldr = helDefdr + 30;

                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 1;
                    else helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 52;
                    else heldp = helDefdp + 52;
                    helev = helDefev + 19;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 61;
                    else if (helId == 9 | helId == 19) helhev = helDefhev + 40;
                    else helhev = helDefhev + 61;
                    if (helId == 9 | helId == 19) heldr = helDefdr + 33;
                    else heldr = helDefdr + 33;
                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 1;
                    else helhdr = helDefhdr + 2;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 59;
                    else heldp = helDefdp + 60;
                    helev = helDefev + 21;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 67;
                    else if (helId == 9 | helId == 19) helhev = helDefhev + 44;
                    else helhev = helDefhev + 67;
                    if (helId == 9 | helId == 19) heldr = helDefdr + 38;
                    else heldr = helDefdr + 39;
                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 1;
                    else helhdr = helDefhdr + 3;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 19 & helEnchLvl <= 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 59 + (helEnchLvl - 18) * 4;
                    else heldp = helDefdp + 60 + (helEnchLvl - 18) * 5;
                    helev = helDefev + 21 + (helEnchLvl - 18) * 2;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 67 + (helEnchLvl - 18) * 6;
                    else if (helId == 9 | helId == 19) helhev = helDefhev + 44 + (helEnchLvl - 18) * 4;
                    else helhev = helDefhev + 67 + (helEnchLvl - 18) * 6;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 38 + (helEnchLvl - 18) * 2;
                    else heldr = helDefdr + 39 + (helEnchLvl - 18) * 3;

                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 1;
                    else helhdr = helDefhdr + 3 + (helEnchLvl - 18) * 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }
            }

            if (helEnch == false | helEnch == true & helEnchLvl == 0)
            {

                cdp -= heldp;
                cev -= helev;
                chev -= helhev;
                cDR -= heldr;
                chdr -= helhdr;
                cMaxHP -= helHP;
                cRes1 -= helSSFRes;
                cRes2 -= helKBRes;
                cRes3 -= helGrapleRes;
                cRes4 -= helKFRes;
                cWeight -= helWeight;
                cMaxST -= helST;
                chpr -= helHPRecovery;
                cluck -= helLuck;



                heldp = helDefdp;
                helev = helDefev;
                helhev = helDefhev;
                heldr = helDefdr;
                helhdr = helDefhdr;
                helHP = helDefHP;
                helSSFRes = helSSFDefRes;
                helKBRes = helKBDefRes;
                helGrapleRes = helGrapleDefRes;
                helKFRes = helKFDefRes;
                helWeight = helDefWeight;
                helST = helDefST;
                helLuck = helDefLuck;
                helHPRecovery = helDefHPRecovery;


                cdp += heldp;
                cev += helev;
                chev += helhev;
                cDR += heldr;
                chdr += helhdr;
                cMaxHP += helHP;
                cRes1 += helSSFRes;
                cRes2 += helKBRes;
                cRes3 += helGrapleRes;
                cRes4 += helKFRes;
                cWeight += helWeight;
                cMaxST += helST;
                chpr += helHPRecovery;
                cluck += helLuck;
            }
        }

        public void GlovesState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Gloves where Id='" + glovId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (glovEnch == true & glovIsBoss == true | glovId == 21)
            {
                if (glovEnchLvl >= 1 & glovEnchLvl <= 5)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if (glovId == 0 ) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + glovEnchLvl * 1;
                    else glovacc = glovDefacc;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if(glovId == 21) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl >= 6 & glovEnchLvl <= 15)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21)
                    {
                        if (glovEnchLvl >= 15) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                        else glovacc = glovDefacc + glovEnchLvl * 1;
                    }
                    else glovacc = glovDefacc + (glovEnchLvl-5) * 1;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if (glovId == 21) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 16 )
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 35;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = glovDefev +17;
                    else  glovev = glovDefev + 18;

                    if (glovId == 0 | glovId == 21) glovhev = 54;
                    else glovhev = 61;

                    if (glovId == 0) glovdr = 19;
                    else if (glovId == 21) glovdr = 18;
                    else glovdr = 18;

                    if (glovId == 21) glovhdr = glovDefhdr + 6;
                    else glovhdr = glovDefhdr + 1;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 17)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 40;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 20;
                    else glovev = glovDefev + 21;

                    if (glovId == 0 | glovId == 21) glovhev = 60;
                    else glovhev = 70;

                    if (glovId == 0) glovdr = 22;
                    else if (glovId == 21) glovdr = 21;
                    else glovdr = 20;

                    if (glovId == 0) glovhdr = 7;
                    else if (glovId == 21) glovhdr = glovDefhdr + 7;
                    else glovhdr = 8;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 18)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 48;

                    if (glovId == 0 ) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 22;
                    else glovev = glovDefev +24;

                    if (glovId == 0 | glovId == 21) glovhev = 66;
                    else glovhev = 79;

                    if (glovId == 0) glovdr = 28;
                    else if (glovId == 21) glovdr = 27;
                    else glovdr = 25;

                    if (glovId == 0) glovhdr = 9;
                    else if (glovId == 21) glovhdr = glovDefhdr + 9;
                    else glovhdr = 11;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 19)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    if (glovId == 0) glovdp = 55;
                    else if (glovId == 21) glovdp = 54;
                    else glovdp = 56;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 24;
                    else glovev = glovDefev + 28;

                    if (glovId == 0 | glovId == 21) glovhev = 72;
                    else glovhev = 91;

                    if (glovId == 0 ) glovdr = 31;
                    else if (glovId == 21) glovdr = 30;
                    else glovdr = 27;

                    if (glovId == 0 | glovId == 21) glovhdr = 13;
                    else if (glovId == 21) glovhdr = glovDefhdr + 13;
                    else glovhdr = 14;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 20)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    if (glovId == 0) glovdp = 60;
                    else if (glovId == 21) glovdp = 59;
                    else glovdp = 62;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 26;
                    else glovev = glovDefev + 32;

                    if (glovId == 0 | glovId == 21) glovhev = 78;
                    else glovhev = 103;

                    if (glovId == 0 ) glovdr = 34;
                    else if (glovId == 21) glovdr = 33;
                    else glovdr = 29;

                    if (glovId == 0) glovhdr = 19;
                    else if (glovId == 21) glovhdr = glovDefhdr + 19;
                    else glovhdr = 17;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

            }

            else if (glovEnch == true & glovIsBoss == false)
            {
                if (glovEnchLvl >= 1 & glovEnchLvl <= 15)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;
                    ceda -= glovDamage;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if(glovId == 9 | glovId == 19)
                    {
                        if (glovEnchLvl <= 5) glovacc = glovDefacc;
                        else if (glovEnchLvl >= 6 & glovEnchLvl <= 10) glovacc = glovDefacc + 3;
                        else if (glovEnchLvl >= 11) glovacc = glovDefacc + 3 + (glovEnchLvl - 10) * 2;
                    }
                    glovev = glovDefev + glovEnchLvl * 1;
                    if(glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33)
                    {
                        if (glovEnchLvl == 1) glovhev = glovDefhev + 7;
                        else if (glovEnchLvl == 2) glovhev = glovDefhev + 9;
                        else if (glovEnchLvl == 3) glovhev = glovDefhev + 12;
                        else if (glovEnchLvl == 4) glovhev = glovDefhev + 14;
                        else if (glovEnchLvl == 5) glovhev = glovDefhev + 17;
                        else if (glovEnchLvl == 6) glovhev = glovDefhev + 21;
                        else if (glovEnchLvl == 7) glovhev = glovDefhev + 24;
                        else if (glovEnchLvl == 8) glovhev = glovDefhev + 28;
                        else glovhev = glovDefhev + 28 + (glovEnchLvl-8) * 3;
                    }
                     else if (glovId == 9| glovId == 19)
                     {
                        if (glovEnchLvl <= 10) glovhev = glovDefhev + glovEnchLvl * 2;
                        else if (glovEnchLvl == 11) glovhev = glovDefhev + 23;
                        else glovhev = glovDefhev + 23 + (glovEnchLvl - 11) * 2;
                     }
                    else glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if(glovId == 9| glovId == 19)
                    {
                        if (glovEnchLvl <= 5) glovhdr = glovDefhdr;
                        else glovhdr = glovDefhdr + 3;
                    }
                    else glovhdr = glovDefhdr;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;
                    glovacc = glovDefacc;
                    glovDamage = glovDefDamage;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                    ceda += glovDamage;

                }

                if (glovEnchLvl == 16)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;
                    ceda -= glovDamage;

                    glovdp = glovDefdp + (glovEnchLvl -1) * 2 + 5;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 16;
                    glovev = glovDefev + (glovEnchLvl-1) * 1 + 2;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 55;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 39;
                    else glovhev = glovDefhev + (glovEnchLvl - 1) * 3 + 10;
                    glovdr = glovDefdr + (glovEnchLvl - 1) * 1 + 3;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 4;
                    else glovhdr = glovDefhdr + 1;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;
                    glovacc = glovDefacc;
                    glovDamage = glovDefDamage;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                    ceda += glovDamage;
                }

                if (glovEnchLvl ==17)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;
                    ceda -= glovDamage;

                    glovdp = glovDefdp + 40;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 19;
                    glovev = glovDefev + 19;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 61;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 45;
                    else glovhev = glovDefhev + 61;
                    glovdr = glovDefdr + 21;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr+2;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;
                    glovacc = glovDefacc;
                    glovDamage = glovDefDamage;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                    ceda += glovDamage;

                }

                if (glovEnchLvl == 18)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;
                    ceda -= glovDamage;

                    glovdp = glovDefdp + 48;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 22;
                    glovev = glovDefev + 21;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 67;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 51;
                    else glovhev = glovDefhev + 67;
                    glovdr = glovDefdr + 27;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 6;
                    else glovhdr = glovDefhdr + 3;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;
                    glovacc = glovDefacc;
                    glovDamage = glovDefDamage;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                    ceda += glovDamage;

                }

                if (glovEnchLvl >= 19 & glovEnchLvl <= 20)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;
                    ceda -= glovDamage;

                    glovdp = glovDefdp + 48 + (glovEnchLvl-18) * 5;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 22 + (glovEnchLvl -18) * 3;
                    glovev = glovDefev + 21 + (glovEnchLvl - 18) * 2;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 67 + (glovEnchLvl-18) * 6;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 51 + (glovEnchLvl-18) * 6;
                    else glovhev = glovDefhev + 67 + (glovEnchLvl - 18)*6;
                    glovdr = glovDefdr + 27 + (glovEnchLvl - 18) * 3;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 6 + (glovEnchLvl-18) * 1;
                    else glovhdr = glovDefhdr + 3 + (glovEnchLvl - 18)*1;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;
                    glovacc = glovDefacc;
                    glovDamage = glovDefDamage;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                    ceda += glovDamage;

                }


            }

            if (glovEnch == false | glovEnch == true & glovEnchLvl == 0)
            {

                cdp -= glovdp;
                cev -= glovev;
                chev -= glovhev;
                cDR -= glovdr;
                chdr -= glovhdr;
                cacc -= glovacc;
                cAtkSpeed -= glovAtkSpeed;
                cCastSpeed -= glovCastSpeed;
                ccr -= glovCrit;
                cWeight -= glovWeight;
                cRes3 -= glovGrapleRes;
                ceda -= glovDamage;


                glovdp = glovDefdp;
                glovacc = glovDefacc;
                glovev = glovDefev;
                glovhev = glovDefhev;
                glovdr = glovDefdr;
                glovhdr = glovDefhdr;
                glovAtkSpeed = glovDefAtkSpeed;
                glovCastSpeed = glovDefCastSpeed;
                glovCrit = glovDefCrit;
                glovWeight = glovDefWeight;
                glovGrapleRes = glovDefGrapleRes;
                glovacc = glovDefacc;
                glovDamage = glovDefDamage;

                cdp += glovdp;
                cev += glovev;
                chev += glovhev;
                cDR += glovdr;
                chdr += glovhdr;
                cacc += glovacc;
                cAtkSpeed += glovAtkSpeed;
                cCastSpeed += glovCastSpeed;
                ccr += glovCrit;
                cWeight += glovWeight;
                cRes3 += glovGrapleRes;
                ceda += glovDamage;


            }
        }

        public void ShoesState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Shoes where Id='" + shId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (shEnch == true & shIsBoss == true | shId == 25)
            {

                if (shEnchLvl >= 1 & shEnchLvl <= 15)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + shEnchLvl * 3;
                    shev = shDefev + shEnchLvl * 2;
                    if (shId == 0 | shId == 25) shhev = shDefhev + shEnchLvl * 4;
                    else shhev = shDefev + shEnchLvl * 2;

                    shdr = shDefdr + shEnchLvl * 1;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr;
                    else if (shId == 1 & shEnchLvl <= 5) shhdr = shDefhdr + shEnchLvl * 1;
                    else shhdr = shDefhdr + 5 + (shEnchLvl - 5) * 2;

                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 50;


                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 68;
                    else if (shId == 25) shhev = shDefhev + 67;
                    else shhev = shDefhev + 34;

                    shdr = shDefdr + 18;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr+1;
                    else shhdr = shDefhdr + 28;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                }

                if (shEnchLvl == 17)
                {
                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 55;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0 ) shhev = shDefhev + 72;
                    else if (shId == 25) shhev = shDefhev + 71;
                    else shhev = shDefhev + 36;

                    shdr = shDefdr + 21;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 2;
                    else shhdr = shDefhdr + 31;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 63;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 76;
                    else if (shId == 25) shhev = shDefhev + 75;
                    else shhev = shDefhev + 38;

                    shdr = shDefdr + 27;


                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 4;
                    else shhdr = shDefhdr + 34;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 19)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 68;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0 ) shhev = shDefhev + 80;
                    else if (shId == 25) shhev = shDefhev + 79;
                    else shhev = shDefhev + 40;

                    shdr = shDefdr + 30;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 8;
                    else shhdr = shDefhdr + 37;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 73;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 84;
                    else if (shId == 25) shhev = shDefhev + 83;
                    else shhev = shDefhev + 42;

                    shdr = shDefdr + 33;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 14;
                    else shhdr = shDefhdr + 40;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

            }

            else if (shEnch == true & shIsBoss == false)
            {
                if (shEnchLvl >= 1 & shEnchLvl <= 15)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shdp = shDefdp + shEnchLvl * 2;
                        else shdp = shDefdp + 10 + (shEnchLvl - 5) * 3;
                    }
                    else shdp = shDefdp + shEnchLvl * 2;

                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shev = shDefev + shEnchLvl * 1;
                        else shev = shDefev + 5 + (shEnchLvl - 5) * 2;
                    }
                    else shev = shDefev + shEnchLvl * 1;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37)
                    {
                        if (shEnchLvl == 1) shhev = shDefhev + 7;
                        else if (shEnchLvl == 2) shhev = shDefhev + 9;
                        else if (shEnchLvl == 3) shhev = shDefhev + 12;
                        else if (shEnchLvl == 4) shhev = shDefhev + 14;
                        else if (shEnchLvl == 5) shhev = shDefhev + 17;
                        else if (shEnchLvl == 6) shhev = shDefhev + 21;
                        else if (shEnchLvl == 7) shhev = shDefhev + 24;
                        else if (shEnchLvl == 8) shhev = shDefhev + 28;
                        else shhev = shDefhev + 28 + (shEnchLvl - 8) * 3;
                    }
                    else if (shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shhev = shDefhev + shEnchLvl * 2;
                        else shhev = shDefhev + 10 + (shEnchLvl - 5) * 4;
                    }
                    else shhev = shDefhev + shEnchLvl * 3;

                    shdr = shDefdr + shEnchLvl * 1;
                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 10) shhdr = shDefhdr;
                        else shhdr = shDefhdr + (shEnchLvl - 10) * 1;
                    }
                    else shhdr = shDefhdr;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 45;
                    else shdp = shDefdp + (shEnchLvl - 1) * 2 + 5;

                    if (shId == 11 | shId == 23) shev = shDefev + 27;
                    else shev = shDefev + (shEnchLvl - 1) * 1 + 2;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 55;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 57;
                    else shhev = shDefhev + (shEnchLvl - 1) * 3 + 10;

                    shdr = shDefdr + (shEnchLvl - 1) * 1 + 3;
                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 6;
                    else shhdr = shDefhdr + 1;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 17)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 50;
                    else shdp = shDefdp + 40;

                    if (shId == 11 | shId == 23) shev = shDefev + 29;
                    else shev = shDefev + 19;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 61;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 63;
                    else shhev = shDefhev + 61;

                    shdr = shDefdr + 21;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 7;
                    else shhdr = shDefhdr + 2;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 58;
                    else shdp = shDefdp + 48;

                    if (shId == 11 | shId == 23) shev = shDefev + 31;
                    else shev = shDefev + 21;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 67;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 69;
                    else shhev = shDefhev + 67;

                    shdr = shDefdr + 27;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 8;
                    else shhdr = shDefhdr + 3;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl >= 19 & shEnchLvl <= 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 58 + (shEnchLvl- 18) * 5;
                    else shdp = shDefdp + 48 + (shEnchLvl - 18) * 5;

                    if (shId == 11 | shId == 23) shev = shDefev + 31 + (shEnchLvl - 18) * 2;
                    else shev = shDefev + 21 + (shEnchLvl - 18) * 2;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 67 + (shEnchLvl - 18) * 6;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 69 + (shEnchLvl - 18) * 6;
                    else shhev = shDefhev + 67 + (shEnchLvl - 18) * 6;

                    shdr = shDefdr + 27 + (shEnchLvl - 18) * 3;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 8 +(shEnchLvl - 18) * 1;
                    else shhdr = shDefhdr + 3 + (shEnchLvl - 18) * 1;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }


            }

            if (shEnch == false | shEnch == true & shEnchLvl == 0)
            {

                cdp -= shdp;
                cev -= shev;
                chev -= shhev;
                cDR -= shdr;
                chdr -= shhdr;
                cmvs -= shMvs;
                cRes2 -= shKBRes;
                cMaxST -= shMaxST;
                cWeight -= shWeight;



                shdp = shDefdp;
                shev = shDefev;
                shhev = shDefhev;
                shdr = shDefdr;
                shhdr = shDefhdr;
                shMvs = shDefMvs;
                shKBRes = shDefKBRes;
                shMaxST = shDefMaxST;
                shWeight = shDefWeight;

                cdp += shdp;
                cev += shev;
                chev += shhev;
                cDR += shdr;
                chdr += shhdr;
                cmvs += shMvs;
                cRes2 += shKBRes;
                cMaxST += shMaxST;
                cWeight += shWeight;

            }
        }

        public void BossSetBonusCheck()
        {
            b_sb -= b_asb; // Boss (1)
            b_sb -= b_hsb;
            b_sb -= b_bsb;
            b_sb -= b_gsb;
            l_sb -= l_asb; // Lemoria (2)
            l_sb -= l_hsb;
            l_sb -= l_bsb;
            l_sb -= l_gsb;
            a_sb -= a_asb; // Akum (3)
            a_sb -= a_hsb;
            a_sb -= a_bsb;
            a_sb -= a_gsb;
            gr_sb -= gr_asb; // Grunil (4)
            gr_sb -= gr_hsb;
            gr_sb -= gr_bsb;
            gr_sb -= gr_gsb;
            tr_sb -= tr_asb; // Taritas (5)
            tr_sb -= tr_hsb;
            tr_sb -= tr_bsb;
            tr_sb -= tr_gsb;
            rc_sb -= rc_asb; // Rocaba (6)
            rc_sb -= rc_hsb;
            rc_sb -= rc_bsb;
            rc_sb -= rc_gsb;
            ag_sb -= ag_asb; // Agerian (7)
            ag_sb -= ag_hsb;
            ag_sb -= ag_bsb;
            ag_sb -= ag_gsb;
            zr_sb -= zr_asb; // Zereth (8)
            zr_sb -= zr_hsb;
            zr_sb -= zr_bsb;
            zr_sb -= zr_gsb;
            tl_sb -= tl_asb; // Talis (9)
            tl_sb -= tl_hsb;
            tl_sb -= tl_bsb;
            tl_sb -= tl_gsb;
            sh_sb -= sh_asb; // SH (10)
            sh_sb -= sh_hsb;
            sh_sb -= sh_bsb;
            sh_sb -= sh_gsb;
            hm_sb -= hm_asb; // HM (11)
            hm_sb -= hm_hsb;
            hm_sb -= hm_bsb;
            hm_sb -= hm_gsb;
            lf_sb -= lf_asb; // LF (12)
            lf_sb -= lf_hsb;
            lf_sb -= lf_bsb;
            lf_sb -= lf_gsb;

            // Boss
            if (armSB == 1) { b_asb = 1; }
            if (armSB != 1 && b_asb > 0) { b_asb -= 1; }
            if (helSB == 1) { b_hsb = 1; }
            if (helSB != 1 && b_hsb > 0) { b_hsb -= 1; }
            if (shSB == 1) { b_bsb = 1; }
            if (shSB != 1 && b_bsb > 0) { b_bsb -= 1; }
            if (glovSB == 1) { b_gsb = 1; }
            if (glovSB != 1 && b_gsb > 0) { b_gsb -= 1; }
            // Lemoria
            if (armSB == 2) { l_asb = 1; }
            if (armSB != 2 && l_asb > 0) { l_asb -= 1; }
            if (helSB == 2) { l_hsb = 1; }
            if (helSB != 2 && l_hsb > 0) { l_hsb -= 1; }
            if (shSB == 2) { l_bsb = 1; }
            if (shSB != 2 && l_bsb > 0) { l_bsb -= 1; }
            if (glovSB == 2) { l_gsb = 1; }
            if (glovSB != 2 && l_gsb > 0) { l_gsb -= 1; }
            // Akum
            if (armSB == 3) { a_asb = 1; }
            if (armSB != 3 && a_asb > 0) { a_asb -= 1; }
            if (helSB == 3) { a_hsb = 1; }
            if (helSB != 3 && a_hsb > 0) { a_hsb -= 1; }
            if (shSB == 3) { a_bsb = 1; }
            if (shSB != 3 && a_bsb > 0) { a_bsb -= 1; }
            if (glovSB == 3) { a_gsb = 1; }
            if (glovSB != 3 && a_gsb > 0) { a_gsb -= 1; }
            // Grunil
            if (armSB == 4) { gr_asb = 1; }
            if (armSB != 4 && gr_asb > 0) { gr_asb -= 1; }
            if (helSB == 4) { gr_hsb = 1; }
            if (helSB != 4 && gr_hsb > 0) { gr_hsb -= 1; }
            if (shSB == 4) { gr_bsb = 1; }
            if (shSB != 4 && gr_bsb > 0) { gr_bsb -= 1; }
            if (glovSB == 4) { gr_gsb = 1; }
            if (glovSB != 4 && gr_gsb > 0) { gr_gsb -= 1; }
            // Taritas
            if (armSB == 5) { tr_asb = 1; }
            if (armSB != 5 && tr_asb > 0) { tr_asb -= 1; }
            if (helSB == 5) { tr_hsb = 1; }
            if (helSB != 5 && tr_hsb > 0) { tr_hsb -= 1; }
            if (shSB == 5) { tr_bsb = 1; }
            if (shSB != 5 && tr_bsb > 0) { tr_bsb -= 1; }
            if (glovSB == 5) { tr_gsb = 1; }
            if (glovSB != 5 && tr_gsb > 0) { tr_gsb -= 1; }
            // Rocaba
            if (armSB == 6) { rc_asb = 1; }
            if (armSB != 6 && rc_asb > 0) { rc_asb -= 1; }
            if (helSB == 6) { rc_hsb = 1; }
            if (helSB != 6 && rc_hsb > 0) { rc_hsb -= 1; }
            if (shSB == 6) { rc_bsb = 1; }
            if (shSB != 6 && rc_bsb > 0) { rc_bsb -= 1; }
            if (glovSB == 6) { rc_gsb = 1; }
            if (glovSB != 6 && rc_gsb > 0) { rc_gsb -= 1; }
            // Agerian
            if (armSB == 7) { ag_asb = 1; }
            if (armSB != 7 && ag_asb > 0) { ag_asb -= 1; }
            if (helSB == 7) { ag_hsb = 1; }
            if (helSB != 7 && ag_hsb > 0) { ag_hsb -= 1; }
            if (shSB == 7) { ag_bsb = 1; }
            if (shSB != 7 && ag_bsb > 0) { ag_bsb -= 1; }
            if (glovSB == 7) { ag_gsb = 1; }
            if (glovSB != 7 && ag_gsb > 0) { ag_gsb -= 1; }
            // Zereth
            if (armSB == 8) { zr_asb = 1; }
            if (armSB != 8 && zr_asb > 0) { zr_asb -= 1; }
            if (helSB == 8) { zr_hsb = 1; }
            if (helSB != 8 && zr_hsb > 0) { zr_hsb -= 1; }
            if (shSB == 8) { zr_bsb = 1; }
            if (shSB != 8 && zr_bsb > 0) { zr_bsb -= 1; }
            if (glovSB == 8) { zr_gsb = 1; }
            if (glovSB != 8 && zr_gsb > 0) { zr_gsb -= 1; }
            // Talis
            if (armSB == 9) { tl_asb = 1; }
            if (armSB != 9 && tl_asb > 0) { tl_asb -= 1; }
            if (helSB == 9) { tl_hsb = 1; }
            if (helSB != 9 && tl_hsb > 0) { tl_hsb -= 1; }
            if (shSB == 9) { tl_bsb = 1; }
            if (shSB != 9 && tl_bsb > 0) { tl_bsb -= 1; }
            if (glovSB == 9) { tl_gsb = 1; }
            if (glovSB != 9 && tl_gsb > 0) { tl_gsb -= 1; }
            // SH
            if (armSB == 10) { sh_asb = 1; }
            if (armSB != 10 && sh_asb > 0) { sh_asb -= 1; }
            if (helSB == 10) { sh_hsb = 1; }
            if (helSB != 10 && sh_hsb > 0) { sh_hsb -= 1; }
            if (shSB == 10) { sh_bsb = 1; }
            if (shSB != 10 && sh_bsb > 0) { sh_bsb -= 1; }
            if (glovSB == 10) { sh_gsb = 1; }
            if (glovSB != 10 && sh_gsb > 0) { sh_gsb -= 1; }
            // HM
            if (armSB == 11) { hm_asb = 1; }
            if (armSB != 11 && hm_asb > 0) { hm_asb -= 1; }
            if (helSB == 11) { hm_hsb = 1; }
            if (helSB != 11 && hm_hsb > 0) { hm_hsb -= 1; }
            if (shSB == 11) { hm_bsb = 1; }
            if (shSB != 11 && hm_bsb > 0) { hm_bsb -= 1; }
            if (glovSB == 11) { hm_gsb = 1; }
            if (glovSB != 11 && hm_gsb > 0) { hm_gsb -= 1; }
            // LF
            if (armSB == 12) { lf_asb = 1; }
            if (armSB != 12 && lf_asb > 0) { lf_asb -= 1; }
            if (helSB == 12) { lf_hsb = 1; }
            if (helSB != 12 && lf_hsb > 0) { lf_hsb -= 1; }
            if (shSB == 12) { lf_bsb = 1; }
            if (shSB != 12 && lf_bsb > 0) { lf_bsb -= 1; }
            if (glovSB == 12) { lf_gsb = 1; }
            if (glovSB != 12 && lf_gsb > 0) { lf_gsb -= 1; }

            b_sb += b_asb; // Boss
            b_sb += b_hsb;
            b_sb += b_bsb;
            b_sb += b_gsb;
            l_sb += l_asb; // Lemoria
            l_sb += l_hsb;
            l_sb += l_bsb;
            l_sb += l_gsb;
            a_sb += a_asb; // Akum
            a_sb += a_hsb;
            a_sb += a_bsb;
            a_sb += a_gsb;
            gr_sb += gr_asb; // Grunil
            gr_sb += gr_hsb;
            gr_sb += gr_bsb;
            gr_sb += gr_gsb;
            tr_sb += tr_asb; // Taritas
            tr_sb += tr_hsb;
            tr_sb += tr_bsb;
            tr_sb += tr_gsb;
            rc_sb += rc_asb; // Rocaba
            rc_sb += rc_hsb;
            rc_sb += rc_bsb;
            rc_sb += rc_gsb;
            ag_sb += ag_asb; // Agerian
            ag_sb += ag_hsb;
            ag_sb += ag_bsb;
            ag_sb += ag_gsb;
            zr_sb += zr_asb; // Zereth
            zr_sb += zr_hsb;
            zr_sb += zr_bsb;
            zr_sb += zr_gsb;
            tl_sb += tl_asb; // Talis
            tl_sb += tl_hsb;
            tl_sb += tl_bsb;
            tl_sb += tl_gsb;
            sh_sb += sh_asb; // SH
            sh_sb += sh_hsb;
            sh_sb += sh_bsb;
            sh_sb += sh_gsb;
            hm_sb += hm_asb; // HM
            hm_sb += hm_hsb;
            hm_sb += hm_bsb;
            hm_sb += hm_gsb;
            lf_sb += lf_asb; // LF
            lf_sb += lf_hsb;
            lf_sb += lf_bsb;
            lf_sb += lf_gsb;
        }
        public void BossSetBonus()
        {
            //BossSet
            if (b_sb <= 2) { cMaxST -= b_b3; b_b3 = 0; }
            if (b_sb == 3 && b_b3 == 0) { b_b3 = 200; cMaxST += b_b3; }
            if (b_sb == 3) { cAtkSpeed -= b_b4; cCastSpeed -= b_b4; b_b4 = 0; }
            if (b_sb == 4 && b_b4 == 0) { b_b4 = 1; cAtkSpeed += b_b4; cCastSpeed += b_b4; }
            //Lemoria
            if (l_sb < 2) { cmvs -= l_b2; ccr -= l_b2; l_b2 = 0; }
            if (l_sb == 2 && l_b2 == 0) { l_b2 = 1; cmvs += l_b2; ccr += l_b2; }
            if (l_sb == 3) { cAtkSpeed -= l_b4; cCastSpeed -= l_b4; l_b4 = 0; }
            if (l_sb == 4 && l_b4 == 0) { l_b4 = 2; cAtkSpeed += l_b4; cCastSpeed += l_b4; }
            //Akum
            if (a_sb < 2) { cev -= a_b2; a_b2 = 0; }
            if (a_sb == 2 && a_b2 == 0) { a_b2 = 1; cev += a_b2; }
            if (a_sb == 2) { cDR -= a_b3a; cMaxHP -= a_b3b; a_b3a = 0; a_b3b = 0; }
            if (a_sb == 3 && a_b3a == 0) { a_b3a = 5; a_b3b = 150; cDR += a_b3a; cMaxHP += a_b3b; }
            if (a_sb == 3) { chap -= a_b4; a_b4 = 0; }
            if (a_sb == 4 && a_b4 == 0) { a_b4 = 7; chap += a_b4; }
            //Grunil
            if (gr_sb < 2) { chap -= gr_b2; gr_b2 = 0; }
            if (gr_sb == 2 && gr_b2 == 0) { gr_b2 = 5; chap += gr_b2; }
            if (gr_sb == 2) { cMaxHP -= gr_b3; gr_b3 = 0; }
            if (gr_sb == 3 && gr_b3 == 0) { gr_b3 = 150; cMaxHP += gr_b3; }
            if (gr_sb == 3) { chap -= gr_b4; gr_b4 = 0; }
            if (gr_sb == 4 && gr_b4 == 0) { gr_b4 = 2; chap += gr_b4; }
            //Taritas 
            if (tr_sb < 2) { cMaxMP -= tr_b2; tr_b2 = 0; }
            if (tr_sb == 2 && tr_b2 == 0) { tr_b2 = 100; cMaxMP += tr_b2; }
            if (tr_sb == 2) { cacc -= tr_b3; tr_b3 = 0; }
            if (tr_sb == 3 && tr_b3 == 0) { tr_b3 = 20; cacc += tr_b3; }
            //Rocaba
            if (rc_sb < 2) { cev -= rc_b2; rc_b2 = 0; }
            if (rc_sb == 2 && rc_b2 == 0) { rc_b2 = 5; cev += rc_b2; }
            if (rc_sb == 2) { cMaxMP -= rc_b3; cMaxHP -= rc_b3; rc_b3 = 0; }
            if (rc_sb == 3 && rc_b3 == 0) { rc_b3 = 75; cMaxMP += rc_b3; ; cMaxHP += rc_b3; }
            if (rc_sb == 3) { cev -= rc_b4; rc_b4 = 0; }
            if (rc_sb == 4 && rc_b4 == 0) { rc_b4 = 2; cev += rc_b4; }
            //Agerian
            if (ag_sb < 2) { cMaxMP -= ag_b2; ag_b2 = 0; }
            if (ag_sb == 2 && ag_b2 == 0) { ag_b2 = 100; cMaxMP += ag_b2; }
            if (ag_sb == 2) { cAtkSpeed -= ag_b3; cCastSpeed -= ag_b3; ag_b3 = 0; }
            if (ag_sb == 3 && ag_b3 == 0) { ag_b3 = 2; cAtkSpeed += ag_b3; cCastSpeed += ag_b3; }
            //Zereth
            if (zr_sb < 2) { cMaxST -= zr_b2; zr_b2 = 0; }
            if (zr_sb == 2 && zr_b2 == 0) { zr_b2 = 200; cMaxST += zr_b2; }
            if (zr_sb == 2) { ceda -= zr_b3; zr_b3 = 0; }
            if (zr_sb == 3 && zr_b3 == 0) { zr_b3 = 5; ceda += zr_b3; }
            //Talis
            if (tl_sb < 2) { cmvs -= tl_b2; tl_b2 = 0; }
            if (tl_sb == 2 && tl_b2 == 0) { tl_b2 = 1; cmvs += tl_b2; }
            if (tl_sb == 2) { cmvs -= tl_b3; tl_b3 = 0; }
            if (tl_sb == 3 && tl_b3 == 0) { tl_b3 = 2; cmvs += tl_b3; }
            //Strength "" of Heve 
            if (sh_sb < 2) { cMaxHP -= sh_b2; sh_b2 = 0; }
            if (sh_sb == 2 && sh_b2 == 0) { sh_b2 = 250; cMaxHP += sh_b2; }
            if (sh_sb == 2) { cMaxHP -= sh_b3; sh_b3 = 0; }
            if (sh_sb == 3 && sh_b3 == 0) { sh_b3 = 50; cMaxHP += sh_b3; }
            //Hercules' Might
            if (hm_sb < 2) { cWeight -= hm_b2; hm_b2 = 0; }
            if (hm_sb == 2 && hm_b2 == 0) { hm_b2 = 150; cWeight += hm_b2; }
            if (hm_sb == 2) { cWeight -= hm_b3; hm_b3 = 0; }
            if (hm_sb == 3 && hm_b3 == 0) { hm_b3 = 50; cWeight += hm_b3; }
            //Luck "" of Fortuna
            if (lf_sb < 2) { cluck -= lf_b2; lf_b2 = 0; }
            if (lf_sb == 2 && lf_b2 == 0) { lf_b2 = 2; cluck += lf_b2; }
            if (lf_sb == 2) { cmvs -= lf_b3; lf_b3 = 0; }
            if (lf_sb == 3 && lf_b3 == 0) { lf_b3 = 3; cmvs += lf_b3; }
        }
        public void AccSetBonusCheck()
        {
            a_g_sb -= a_g_bsb; // Grána (1)
            a_g_sb -= a_g_nsb;
            a_g_sb -= a_g_e1sb;
            a_g_sb -= a_g_e2sb;
            a_g_sb -= a_g_r1sb;
            a_g_sb -= a_g_r2sb;
            a_a_sb -= a_a_bsb; // Asula (2)
            a_a_sb -= a_a_nsb;
            a_a_sb -= a_a_e1sb;
            a_a_sb -= a_a_e2sb;
            a_a_sb -= a_a_r1sb;
            a_a_sb -= a_a_r2sb;
            a_j_sb -= a_j_bsb; // Jarette (3)
            a_j_sb -= a_j_nsb;
            a_j_sb -= a_j_e1sb;
            a_j_sb -= a_j_e2sb;
            a_j_sb -= a_j_r1sb;
            a_j_sb -= a_j_r2sb;
            a_ts_sb -= a_ts_bsb; // Treant Spirit (4)
            a_ts_sb -= a_ts_nsb;
            a_ts_sb -= a_ts_e1sb;
            a_ts_sb -= a_ts_e2sb;
            a_ts_sb -= a_ts_r1sb;
            a_ts_sb -= a_ts_r2sb;
            a_rt_sb -= a_rt_bsb; // Root Treant  (5)
            a_rt_sb -= a_rt_nsb;
            a_rt_sb -= a_rt_e1sb;
            a_rt_sb -= a_rt_e2sb;
            a_rt_sb -= a_rt_r1sb;
            a_rt_sb -= a_rt_r2sb;
            a_va_sb -= a_va_bsb; // Val AP  (6)
            a_va_sb -= a_va_nsb;
            a_va_sb -= a_va_e1sb;
            a_va_sb -= a_va_e2sb;
            a_va_sb -= a_va_r1sb;
            a_va_sb -= a_va_r2sb;
            a_vd_sb -= a_vd_bsb; // Val DP  (7)
            a_vd_sb -= a_vd_nsb;
            a_vd_sb -= a_vd_e1sb;
            a_vd_sb -= a_vd_e2sb;
            a_vd_sb -= a_vd_r1sb;
            a_vd_sb -= a_vd_r2sb;

            // Grána
            if (beltSB == 1) { a_g_bsb = 1; }
            if (beltSB != 1 && a_g_bsb > 0) { a_g_bsb -= 1; }
            if (neckSB == 1) { a_g_nsb = 1; }
            if (neckSB != 1 && a_g_nsb > 0) { a_g_nsb -= 1; }
            if (ear1SB == 1) { a_g_e1sb = 1; }
            if (ear1SB != 1 && a_g_e1sb > 0) { a_g_e1sb -= 1; }
            if (ear2SB == 1) { a_g_e2sb = 1; }
            if (ear2SB != 1 && a_g_e2sb > 0) { a_g_e2sb -= 1; }
            if (ring1SB == 1) { a_g_r1sb = 1; }
            if (ring1SB != 1 && a_g_r1sb > 0) { a_g_r1sb -= 1; }
            if (ring2SB == 1) { a_g_r2sb = 1; }
            if (ring2SB != 1 && a_g_r2sb > 0) { a_g_r2sb -= 1; }
            // Asula
            if (beltSB == 2) { a_a_bsb = 1; }
            if (beltSB != 2 && a_a_bsb > 0) { a_a_bsb -= 1; }
            if (neckSB == 2) { a_a_nsb = 1; }
            if (neckSB != 2 && a_a_nsb > 0) { a_a_nsb -= 1; }
            if (ear1SB == 2) { a_a_e1sb = 1; }
            if (ear1SB != 2 && a_a_e1sb > 0) { a_a_e1sb -= 1; }
            if (ear2SB == 2) { a_a_e2sb = 1; }
            if (ear2SB != 2 && a_a_e2sb > 0) { a_a_e2sb -= 1; }
            if (ring1SB == 2) { a_a_r1sb = 1; }
            if (ring1SB != 2 && a_a_r1sb > 0) { a_a_r1sb -= 1; }
            if (ring2SB == 2) { a_a_r2sb = 1; }
            if (ring2SB != 2 && a_a_r2sb > 0) { a_a_r2sb -= 1; }
            // Jarette
            if (beltSB == 3) { a_j_bsb = 1; }
            if (beltSB != 3 && a_j_bsb > 0) { a_j_bsb -= 1; }
            if (neckSB == 3) { a_j_nsb = 1; }
            if (neckSB != 3 && a_j_nsb > 0) { a_j_nsb -= 1; }
            if (ear1SB == 3) { a_j_e1sb = 1; }
            if (ear1SB != 3 && a_j_e1sb > 0) { a_j_e1sb -= 1; }
            if (ear2SB == 3) { a_j_e2sb = 1; }
            if (ear2SB != 3 && a_j_e2sb > 0) { a_j_e2sb -= 1; }
            if (ring1SB == 3) { a_j_r1sb = 1; }
            if (ring1SB != 3 && a_j_r1sb > 0) { a_j_r1sb -= 1; }
            if (ring2SB == 3) { a_j_r2sb = 1; }
            if (ring2SB != 3 && a_j_r2sb > 0) { a_j_r2sb -= 1; }
            // Treant Spirit
            if (beltSB == 4) { a_ts_bsb = 1; }
            if (beltSB != 4 && a_ts_bsb > 0) { a_ts_bsb -= 1; }
            if (neckSB == 4) { a_ts_nsb = 1; }
            if (neckSB != 4 && a_ts_nsb > 0) { a_ts_nsb -= 1; }
            if (ear1SB == 4) { a_ts_e1sb = 1; }
            if (ear1SB != 4 && a_ts_e1sb > 0) { a_ts_e1sb -= 1; }
            if (ear2SB == 4) { a_ts_e2sb = 1; }
            if (ear2SB != 4 && a_ts_e2sb > 0) { a_ts_e2sb -= 1; }
            if (ring1SB == 4) { a_ts_r1sb = 1; }
            if (ring1SB != 4 && a_ts_r1sb > 0) { a_ts_r1sb -= 1; }
            if (ring2SB == 4) { a_ts_r2sb = 1; }
            if (ring2SB != 4 && a_ts_r2sb > 0) { a_ts_r2sb -= 1; }
            // Root Treant
            if (beltSB == 5) { a_rt_bsb = 1; }
            if (beltSB != 5 && a_rt_bsb > 0) { a_rt_bsb -= 1; }
            if (neckSB == 5) { a_rt_nsb = 1; }
            if (neckSB != 5 && a_rt_nsb > 0) { a_rt_nsb -= 1; }
            if (ear1SB == 5) { a_rt_e1sb = 1; }
            if (ear1SB != 5 && a_rt_e1sb > 0) { a_rt_e1sb -= 1; }
            if (ear2SB == 5) { a_rt_e2sb = 1; }
            if (ear2SB != 5 && a_rt_e2sb > 0) { a_rt_e2sb -= 1; }
            if (ring1SB == 5) { a_rt_r1sb = 1; }
            if (ring1SB != 5 && a_rt_r1sb > 0) { a_rt_r1sb -= 1; }
            if (ring2SB == 5) { a_rt_r2sb = 1; }
            if (ring2SB != 5 && a_rt_r2sb > 0) { a_rt_r2sb -= 1; }
            // Val AP
            if (beltSB == 6) { a_va_bsb = 1; }
            if (beltSB != 6 && a_va_bsb > 0) { a_va_bsb -= 1; }
            if (neckSB == 6) { a_va_nsb = 1; }
            if (neckSB != 6 && a_va_nsb > 0) { a_va_nsb -= 1; }
            if (ear1SB == 6) { a_va_e1sb = 1; }
            if (ear1SB != 6 && a_va_e1sb > 0) { a_va_e1sb -= 1; }
            if (ear2SB == 6) { a_va_e2sb = 1; }
            if (ear2SB != 6 && a_va_e2sb > 0) { a_va_e2sb -= 1; }
            if (ring1SB == 6) { a_va_r1sb = 1; }
            if (ring1SB != 6 && a_va_r1sb > 0) { a_va_r1sb -= 1; }
            if (ring2SB == 6) { a_va_r2sb = 1; }
            if (ring2SB != 6 && a_va_r2sb > 0) { a_va_r2sb -= 1; }
            // Val DP
            if (beltSB == 7) { a_vd_bsb = 1; }
            if (beltSB != 7 && a_vd_bsb > 0) { a_vd_bsb -= 1; }
            if (neckSB == 7) { a_vd_nsb = 1; }
            if (neckSB != 7 && a_vd_nsb > 0) { a_vd_nsb -= 1; }
            if (ear1SB == 7) { a_vd_e1sb = 1; }
            if (ear1SB != 7 && a_vd_e1sb > 0) { a_vd_e1sb -= 1; }
            if (ear2SB == 7) { a_vd_e2sb = 1; }
            if (ear2SB != 7 && a_vd_e2sb > 0) { a_vd_e2sb -= 1; }
            if (ring1SB == 7) { a_vd_r1sb = 1; }
            if (ring1SB != 7 && a_vd_r1sb > 0) { a_vd_r1sb -= 1; }
            if (ring2SB == 7) { a_vd_r2sb = 1; }
            if (ring2SB != 7 && a_vd_r2sb > 0) { a_vd_r2sb -= 1; }

            a_g_sb += a_g_bsb; // Grána
            a_g_sb += a_g_nsb;
            a_g_sb += a_g_e1sb;
            a_g_sb += a_g_e2sb;
            a_g_sb += a_g_r1sb;
            a_g_sb += a_g_r2sb;
            a_a_sb += a_a_bsb; // Asula
            a_a_sb += a_a_nsb;
            a_a_sb += a_a_e1sb;
            a_a_sb += a_a_e2sb;
            a_a_sb += a_a_r1sb;
            a_a_sb += a_a_r2sb;
            a_j_sb += a_j_bsb; // Jarette
            a_j_sb += a_j_nsb;
            a_j_sb += a_j_e1sb;
            a_j_sb += a_j_e2sb;
            a_j_sb += a_j_r1sb;
            a_j_sb += a_j_r2sb;
            a_ts_sb += a_ts_bsb; // Treant Spirit
            a_ts_sb += a_ts_nsb;
            a_ts_sb += a_ts_e1sb;
            a_ts_sb += a_ts_e2sb;
            a_ts_sb += a_ts_r1sb;
            a_ts_sb += a_ts_r2sb;
            a_rt_sb += a_rt_bsb; // Root Treant
            a_rt_sb += a_rt_nsb;
            a_rt_sb += a_rt_e1sb;
            a_rt_sb += a_rt_e2sb;
            a_rt_sb += a_rt_r1sb;
            a_rt_sb += a_rt_r2sb;
            a_va_sb += a_va_bsb; // Val AP
            a_va_sb += a_va_nsb;
            a_va_sb += a_va_e1sb;
            a_va_sb += a_va_e2sb;
            a_va_sb += a_va_r1sb;
            a_va_sb += a_va_r2sb;
            a_vd_sb += a_vd_bsb; // Val DP
            a_vd_sb += a_vd_nsb;
            a_vd_sb += a_vd_e1sb;
            a_vd_sb += a_vd_e2sb;
            a_vd_sb += a_vd_r1sb;
            a_vd_sb += a_vd_r2sb;
        }
        public void AccSetBonus()
        {
            //Grána
            if (a_g_sb <= 2) { cedKama -= a_g_b3a; cMaxHP -= a_g_b3b; cMaxST -= a_g_b3b; a_g_b3a = 0; a_g_b3b = 0; }
            if (a_g_sb == 3 && a_g_b3a == 0) { a_g_b3a = 5; a_g_b3b = 50; cedKama += a_g_b3a; cMaxHP += a_g_b3b; cMaxST += a_g_b3b; }
            //Asula
            if (a_a_sb <= 2) { cMaxHP -= a_a_b3; a_a_b3 = 0; }
            if (a_a_sb == 3 && a_a_b3 == 0) { a_a_b3 = 300; cMaxHP += a_a_b3; }
            if (a_a_sb <=4) { cacc -= a_a_b5; a_a_b5 = 0; }
            if (a_a_sb == 5 && a_a_b5 == 0) { a_a_b5 = 20; cacc += a_a_b5; }
            //Jarrete
            if (a_j_sb <= 2) { chap -= a_j_b3; a_j_b3 = 0; }
            if (a_j_sb == 3 && a_j_b3 == 0) { a_j_b3 = 5; chap += a_j_b3; }
            if (a_j_sb <= 4) { chap -= a_j_b5; a_j_b5 = 0; }
            if (a_j_sb == 5 && a_j_b5 == 0) { a_j_b5 = 10; chap += a_j_b5; }
            //Treant Spirit
            if (a_ts_sb <= 2) { chdr -= a_ts_b3; a_ts_b3 = 0; }
            if (a_ts_sb == 3 && a_ts_b3 == 0) { a_ts_b3 = 5; chdr += a_ts_b3; }
            if (a_ts_sb <= 4) { cWeight -= a_ts_b5; a_ts_b5 = 0; }
            if (a_ts_sb == 5 && a_ts_b5 == 0) { a_ts_b5 = 100; cWeight += a_ts_b5; }
            //Root Treant
            if (a_rt_sb <= 2) { chdr -= a_rt_b3; a_rt_b3 = 0; }
            if (a_rt_sb == 3 && a_rt_b3 == 0) { a_rt_b3 = 5; chdr += a_rt_b3; }
            if (a_rt_sb <= 4) { cWeight -= a_rt_b5; a_rt_b5 = 0; }
            if (a_rt_sb == 5 && a_rt_b5 == 0) { a_rt_b5 = 100; cWeight += a_rt_b5; }
            //Val AP
            if (a_va_sb <= 1) { ceapa -= a_va_b2; a_va_b2 = 0; }
            if (a_va_sb == 2 && a_va_b2 == 0) { a_va_b2 = 7; ceapa += a_va_b2; }
            //Val DP
            if (a_vd_sb <= 1) { cdfm += a_vd_b2; a_vd_b2 = 0; }
            if (a_vd_sb == 2 && a_vd_b2 == 0) { a_vd_b2 = 5; cdfm -= a_vd_b2; }
        }

        public void WeaponSetBonusCheck()
        {
            k_sb -= k_mwb; // Krea (1)
            k_sb -= k_swb;
            r_sb -= r_mwb; // Rosar (2)
            r_sb -= r_swb;

            //Krea
            if (mwSB == 1) { k_mwb = 1; }
            if (mwSB != 1 && k_mwb > 0) { k_mwb -= 1; }
            if (swSB == 1) { k_swb = 1; }
            if (swSB != 1 && k_swb > 0) { k_swb -= 1; }
            //Rosar
            if (mwSB == 2) { r_mwb = 1; }
            if (mwSB != 2 && r_mwb > 0) { r_mwb -= 1; }
            if (swSB == 2) { r_swb = 1; }
            if (swSB != 2 && r_swb > 0) { r_swb -= 1; }

            k_sb += k_mwb;
            k_sb += k_swb;
            r_sb += r_mwb;
            r_sb += r_swb;
        }

        public void WeaponSetBonus()
        {
            //Krea
            if (k_sb < 2) { cacc -= k_b2; k_b2 = 0; }
            if (k_sb == 2 && k_b2 == 0) { k_b2 = 20; cacc += k_b2; }
            //Rosar
            if (r_sb < 2) { cResistIgnore -= r_b2; r_b2 = 0; }
            if (r_sb == 2 && r_b2 == 0) { r_b2 = 10; cResistIgnore += r_b2; }
        }

            public void AwakeningState(string chClass)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [" + chClass + " Awakening Weapons] where Id='" + awkId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (awkEnch == true & awkEnchLvl == 1)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                //AP High
                awkAPhigh = awkDefAPhigh + 4;
                //AP Low
                awkAPlow = awkDefAPlow + 4;
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                awkAPagainst = awkDefAPagainst;
                //Extra damage tp Humans
                awkDamageHumans = awkDefDamageHumans;
                //Extra Damage to All Species
                awkDamageAll = awkDefDamageAll;

                if(chClass == "Shai")
                {
                    awkDPReduction = 1;
                    awkAllEvasion = 1;
                    awkMvsSpeedRed = 1;
                    awkSpeedIncrease = 1;

                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 2 & awkEnchLvl <= 3)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                //AP High
                awkAPhigh = awkDefAPhigh + 4 + (awkEnchLvl - 1) * 3;
                //AP Low
                awkAPlow = awkDefAPlow + 4 + (awkEnchLvl - 1) * 3;
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                awkAPagainst = awkDefAPagainst;
                //Extra damage tp Humans
                awkDamageHumans = awkDefDamageHumans;
                //Extra Damage to All Species
                awkDamageAll = awkDefDamageAll;

                if (chClass == "Shai")
                {
                    awkDPReduction = 1;
                    awkAllEvasion = 1;
                    awkMvsSpeedRed = 1;
                    awkSpeedIncrease = 1;

                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 4 & awkEnchLvl <= 5)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                //AP High
                awkAPhigh = awkDefAPhigh + 10 + (awkEnchLvl - 3) * 2;
                //AP Low
                awkAPlow = awkDefAPlow + 10 + (awkEnchLvl - 3) * 2;
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                awkAPagainst = awkDefAPagainst;
                //Extra damage tp Humans
                awkDamageHumans = awkDefDamageHumans;
                //Extra Damage to All Species
                awkDamageAll = awkDefDamageAll;
                if (chClass == "Shai")
                {
                    awkDPReduction = 1;
                    awkAllEvasion = 1;
                    awkMvsSpeedRed = 1;
                    awkSpeedIncrease = 1;

                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 6 & awkEnchLvl <= 7)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                //AP High
                awkAPhigh = awkDefAPhigh + 14 + (awkEnchLvl - 5) * 3;
                //AP Low
                awkAPlow = awkDefAPlow + 14 + (awkEnchLvl - 5) * 3;
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                awkAPagainst = awkDefAPagainst;
                //Extra damage tp Humans
                if (awkCheckHd == true) awkDamageHumans = awkDefDamageHumans + 1;
                //Extra Damage to All Species
                if (awkCheckAd == true) awkDamageAll = awkDefDamageAll + 1;
                if (chClass == "Shai")
                {
                    awkDPReduction = 1;
                    awkAllEvasion = 1;
                    awkMvsSpeedRed = 1;
                    awkSpeedIncrease = 1;

                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 8 & awkEnchLvl <= 15)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                if (awkId == 3 | awkId == 2 | chClass == "Shai" & awkId == 0)
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 20 + (awkEnchLvl - 7) * 5;
                    //AP Low
                    awkAPlow = awkDefAPlow + 20 + (awkEnchLvl - 7) * 5;
                }
                else
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 20 + (awkEnchLvl - 7) * 4;
                    //AP Low
                    awkAPlow = awkDefAPlow + 20 + (awkEnchLvl - 7) * 4;
                }
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                awkAPagainst = awkDefAPagainst;
                //Extra damage tp Humans
                if (awkCheckHd == true)
                {
                    if (awkEnchLvl >= 6 & awkEnchLvl <= 9) awkDamageHumans = awkDefDamageHumans + 1;
                    else if (awkEnchLvl >= 10 & awkEnchLvl <= 12) awkDamageHumans = awkDefDamageHumans + 2;
                    else if (awkEnchLvl >= 13 & awkEnchLvl <= 15) awkDamageHumans = awkDefDamageHumans + 3;

                }
                //Extra Damage to All Species
                if (awkCheckAd == true)
                {
                    if (awkEnchLvl >= 6 & awkEnchLvl <= 9) awkDamageAll = awkDefDamageAll + 1;
                    else if (awkEnchLvl >= 10 & awkEnchLvl <= 12) awkDamageAll = awkDefDamageAll + 2;
                    else if (awkEnchLvl >= 13 & awkEnchLvl <= 15) awkDamageAll = awkDefDamageAll + 3;
                }
                if (chClass == "Shai")
                { 
                  if(awkEnchLvl >= 8 & awkEnchLvl <= 10)
                    {
                    awkDPReduction = 2;
                    awkAllEvasion = 2;
                    awkMvsSpeedRed = 2;
                    awkSpeedIncrease = 2;
                    }
                   else if (awkEnchLvl >= 11 & awkEnchLvl <= 12)
                    {
                        awkDPReduction = 3;
                        awkAllEvasion = 3;
                        awkMvsSpeedRed = 3;
                        awkSpeedIncrease = 3;
                    }

                    else if (awkEnchLvl == 13)
                    {
                        awkDPReduction = 4;
                        awkAllEvasion = 4;
                        awkMvsSpeedRed = 4;
                        awkSpeedIncrease = 4;
                    }

                    else if (awkEnchLvl == 14)
                    {
                        awkDPReduction = 5;
                        awkAllEvasion = 5;
                        awkMvsSpeedRed = 5;
                        awkSpeedIncrease = 5;
                    }

                    else if (awkEnchLvl == 15)
                    {
                        awkDPReduction = 6;
                        awkAllEvasion = 6;
                        awkMvsSpeedRed = 6;
                        awkSpeedIncrease = 6;
                    }

                }


                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 16 & awkEnchLvl <= 17)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                if (awkId == 3 | awkId == 2 | chClass == "Shai" & awkId == 0)
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 60 + (awkEnchLvl - 15) * 8;
                    //AP Low
                    awkAPlow = awkDefAPlow + 60 + (awkEnchLvl - 15) * 8;
                }
                else
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 52 + (awkEnchLvl - 15) * 8;
                    //AP Low
                    awkAPlow = awkDefAPlow + 52 + (awkEnchLvl - 15) * 8;
                }
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                if (awkCheckAg == true) awkAPagainst = awkDefAPagainst + (awkEnchLvl - 15);
                //Extra damage tp Humans
                if (awkCheckHd == true) awkDamageHumans = awkDefDamageHumans + 4;
                //Extra Damage to All Species
                if (awkCheckAd == true) awkDamageAll = awkDefDamageAll + 4;

                if (chClass == "Shai")
                {
                    awkDPReduction = 6 + (awkEnchLvl-15);
                    awkAllEvasion = 6 + (awkEnchLvl - 15);
                    awkMvsSpeedRed = 6 + (awkEnchLvl - 15);
                    awkSpeedIncrease = 6 + (awkEnchLvl - 15);
                }
                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl == 18)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                if (awkId == 3 | awkId == 2 | chClass == "Shai" & awkId == 0)
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 88;
                    //AP Low
                    awkAPlow = awkDefAPlow + 88;
                }
                else
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 80;
                    //AP Low
                    awkAPlow = awkDefAPlow + 80;
                }
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                if (awkCheckAg == true) awkAPagainst = awkDefAPagainst + 4;
                //Extra damage tp Humans
                if (awkCheckHd == true) awkDamageHumans = awkDefDamageHumans + 4;
                //Extra Damage to All Species
                if (awkCheckAd == true) awkDamageAll = awkDefDamageAll + 4;

                if (chClass == "Shai")
                {
                    awkDPReduction = 9;
                    awkAllEvasion = 9;
                    awkMvsSpeedRed = 9;
                    awkSpeedIncrease =9;
                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else if (awkEnch == true & awkEnchLvl >= 19 & awkEnchLvl <= 20)
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                if (awkId == 3 | awkId == 2 | chClass == "Shai" & awkId == 0)
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 88 + (awkEnchLvl - 18) * 8;
                    //AP Low
                    awkAPlow = awkDefAPlow + 88 + (awkEnchLvl - 18) * 8;
                }
                else
                {
                    //AP High
                    awkAPhigh = awkDefAPhigh + 80 + (awkEnchLvl - 18) * 8;
                    //AP Low
                    awkAPlow = awkDefAPlow + 80 + (awkEnchLvl - 18) * 8;
                }
                //Main AP
                awkAP = (awkAPhigh + awkAPlow) / 2;
                //AP against monsters
                if (awkCheckAg == true) awkAPagainst = awkDefAPagainst + 10;
                //Extra damage tp Humans
                if (awkCheckHd == true) awkDamageHumans = awkDefDamageHumans + 5;
                //Extra Damage to All Species
                if (awkCheckAd == true) awkDamageAll = awkDefDamageAll + 5;

                if (chClass == "Shai")
                {
                    if (awkEnchLvl == 19)
                    {
                    awkDPReduction = 11;
                    awkAllEvasion = 11;
                    awkMvsSpeedRed = 11;
                    awkSpeedIncrease = 11;
                    }

                   else  if (awkEnchLvl == 20)
                    {
                        awkDPReduction = 15;
                        awkAllEvasion = 15;
                        awkMvsSpeedRed = 15;
                        awkSpeedIncrease = 15;
                    }

                }

                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

            else
            {
                caap -= awkAP;
                cacc -= awkAccuracy;
                ceapa -= awkAPagainst;
                cedh -= awkDamageHumans;
                ceda -= awkDamageAll;
                shaiDP -= awkDPReduction;
                shaiEv -= awkAllEvasion;
                shaiMvs -= awkMvsSpeedRed;
                shaiSpeed -= awkSpeedIncrease;

                awkAPhigh = awkDefAPhigh;
                awkAPlow = awkDefAPlow;
                awkAP = (awkAPhigh + awkAPlow) / 2;
                awkAPagainst = awkDefAPagainst;
                awkDamageHumans = awkDefDamageHumans;
                awkAccuracy = awkDefAccuracy;
                awkDamageAll = awkDefDamageAll;
                awkDPReduction = awkDefDPReduction;
                awkAllEvasion = awkDefAllEvasion;
                awkMvsSpeedRed = awkDefMvsSpeedRed;
                awkSpeedIncrease = awkDefSpeedIncrease;


                caap += awkAP;
                cacc += awkAccuracy;
                ceapa += awkAPagainst;
                cedh += awkDamageHumans;
                ceda += awkDamageAll;
                shaiDP += awkDPReduction;
                shaiEv += awkAllEvasion;
                shaiMvs += awkMvsSpeedRed;
                shaiSpeed += awkSpeedIncrease;
            }

        }
        public void MainWeaponState(string weapon)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [" + weapon + " Main Weapon] where Id='" + mwId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if(mwEnch == true & mwEnchLvl >= 1)
            {
                cap -= mwAP;
                cacc -= mwAccuracy;
                ceapa -= mwAPagainst;
                cedh -= mwDamageHumans;
                ceda -= mwDamageAll;
                cADtDemiH -= mwDamDemi;
                cAtkSpeed -= mwAtkSpeed;
                cCastSpeed -= mwCastSpeed;
                ccr -= mwCrit;
                chap -= mwHidenAP;
                cResistIgnore -= mwIgnore;
                cHPrecoveryChance -= mwRecoveryChance;

                //High and low AP
                if(mwId == 3 | mwId == 6 | mwId == 7 | mwId == 21)
                {
                    if(mwEnchLvl == 1)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 4;
                        //AP Low
                        mwAPlow = mwDefAPlow + 4;
                    }

                    else if (mwEnchLvl >= 2 & mwEnchLvl<=3)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 4 + (mwEnchLvl-1) * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + 4 + (mwEnchLvl - 1) * 3;
                    }

                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 10 + (mwEnchLvl - 3) * 2;
                        //AP Low
                        mwAPlow = mwDefAPlow + 10 + (mwEnchLvl - 3) * 2;
                    }

                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 14 + (mwEnchLvl - 5) * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + 14 + (mwEnchLvl - 5) * 3;
                    }

                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 15)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 20 + (mwEnchLvl - 7) * 5;
                        //AP Low
                        mwAPlow = mwDefAPlow + 20 + (mwEnchLvl - 7) * 5;
                    }

                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 17)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 60 + (mwEnchLvl - 15) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 60 + (mwEnchLvl - 15) * 8;
                    }

                    else if (mwEnchLvl == 18 )
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 88 ;
                        //AP Low
                        mwAPlow = mwDefAPlow + 88;
                    }

                    else if (mwEnchLvl >= 19 & mwEnchLvl <= 20)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 88 + (mwEnchLvl - 18) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 88 + (mwEnchLvl - 18) * 8;
                    }

                }
                else if (mwId == 0)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 2)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + mwEnchLvl * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + mwEnchLvl * 3;
                    }

                    else if (mwEnchLvl >= 3 & mwEnchLvl <= 4)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 6 + (mwEnchLvl - 2) * 2;
                        //AP Low
                        mwAPlow = mwDefAPlow + 6 + (mwEnchLvl - 2) * 2;
                    }

                    else if (mwEnchLvl >= 5 & mwEnchLvl <= 6)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 10 + (mwEnchLvl - 4) * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + 10 + (mwEnchLvl - 4) * 3;
                    }

                    else if (mwEnchLvl >= 7 & mwEnchLvl <= 14)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 16 + (mwEnchLvl - 6) * 5;
                        //AP Low
                        mwAPlow = mwDefAPlow + 16 + (mwEnchLvl - 6) * 5;
                    }

                    else if (mwEnchLvl >= 15 & mwEnchLvl <= 16)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 56 + (mwEnchLvl - 14) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 56 + (mwEnchLvl - 14) * 8;
                    }

                    else if (mwEnchLvl == 17)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 84 ;
                        //AP Low
                        mwAPlow = mwDefAPlow + 84;
                    }

                    else if (mwEnchLvl >= 18 & mwEnchLvl <= 19)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 84 + (mwEnchLvl - 17) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 84 + (mwEnchLvl - 17) * 8;
                    }

                    else if (mwEnchLvl == 20)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 110;
                        //AP Low
                        mwAPlow = mwDefAPlow + 110;
                    }

                }
                else
                {
                    if (mwEnchLvl == 1)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 4;
                        //AP Low
                        mwAPlow = mwDefAPlow + 4;
                    }

                    else if (mwEnchLvl >= 2 & mwEnchLvl <= 3)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 4 + (mwEnchLvl - 1) * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + 4 + (mwEnchLvl - 1) * 3;
                    }

                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 10 + (mwEnchLvl - 3) * 2;
                        //AP Low
                        mwAPlow = mwDefAPlow + 10 + (mwEnchLvl - 3) * 2;
                    }

                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 14 + (mwEnchLvl - 5) * 3;
                        //AP Low
                        mwAPlow = mwDefAPlow + 14 + (mwEnchLvl - 5) * 3;
                    }

                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 15)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 20 + (mwEnchLvl - 7) * 4;
                        //AP Low
                        mwAPlow = mwDefAPlow + 20 + (mwEnchLvl - 7) * 4;
                    }

                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 17)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 52 + (mwEnchLvl - 15) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 52 + (mwEnchLvl - 15) * 8;
                    }

                    else if (mwEnchLvl == 18)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 80;
                        //AP Low
                        mwAPlow = mwDefAPlow + 80;
                    }

                    else if (mwEnchLvl >= 19 & mwEnchLvl <= 20)
                    {
                        //AP High
                        mwAPhigh = mwDefAPhigh + 80 + (mwEnchLvl - 18) * 8;
                        //AP Low
                        mwAPlow = mwDefAPlow + 80 + (mwEnchLvl - 18) * 8;
                    }
                }
                //Main AP
                mwAP = (mwAPhigh + mwAPlow) / 2;
                //Accuracy
                if(mwId == 6 |mwId ==8 | mwId == 30)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 15) mwAccuracy = mwDefAccuracy + mwEnchLvl * 10;
                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 20) mwAccuracy = mwDefAccuracy + 150 + (mwEnchLvl - 15) * 8;

                }
                else if(mwId == 0)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 14) mwAccuracy = mwDefAccuracy + mwEnchLvl * 10;
                    else if (mwEnchLvl >= 15 & mwEnchLvl <= 19) mwAccuracy = mwDefAccuracy + 140 + (mwEnchLvl - 14) * 8;
                    else if (mwEnchLvl == 20) mwAccuracy = mwDefAccuracy + 192;
                }
                else if( mwId == 3)
                {
                    if (mwEnchLvl == 1) mwAccuracy = mwDefAccuracy + 6;
                    else if (mwEnchLvl == 2) mwAccuracy = mwDefAccuracy + 12;
                    else if (mwEnchLvl == 3) mwAccuracy = mwDefAccuracy + 18;
                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5) mwAccuracy = mwDefAccuracy + 18 + (mwEnchLvl - 3) * 4;
                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7) mwAccuracy = mwDefAccuracy + 26 + (mwEnchLvl - 5) * 6;
                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 10) mwAccuracy = mwDefAccuracy + 38 + (mwEnchLvl - 7) * 8;
                    else if (mwEnchLvl == 11 ) mwAccuracy = mwDefAccuracy + 74;
                    else if (mwEnchLvl >= 12 & mwEnchLvl <= 15) mwAccuracy = mwDefAccuracy + 74 + (mwEnchLvl - 11) * 14;
                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 19) mwAccuracy = mwDefAccuracy + 130 + (mwEnchLvl - 15) * 10;
                }
                else if(mwId == 7)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 3) mwAccuracy = mwDefAccuracy + mwEnchLvl * 5;                    
                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 15) mwAccuracy = mwDefAccuracy + 15 + (mwEnchLvl-3) * 10;
                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 20) mwAccuracy = mwDefAccuracy + 135 + (mwEnchLvl-15) * 8;

                }
                else if(mwId == 21)
                {
                    if (mwEnchLvl == 1) mwAccuracy = mwDefAccuracy + 8;
                    else if (mwEnchLvl >= 2 & mwEnchLvl <= 3) mwAccuracy = mwDefAccuracy + 8 + (mwEnchLvl - 1) * 6;
                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5) mwAccuracy = mwDefAccuracy + 20 + (mwEnchLvl - 3) * 4;
                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7) mwAccuracy = mwDefAccuracy + 28 + (mwEnchLvl - 5) * 6;
                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 10) mwAccuracy = mwDefAccuracy + 40 + (mwEnchLvl - 7) * 8;
                    else if (mwEnchLvl == 11) mwAccuracy = mwDefAccuracy + 76;
                    else if (mwEnchLvl >= 12 & mwEnchLvl <= 15) mwAccuracy = mwDefAccuracy + 76 + (mwEnchLvl - 11) * 14;
                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 20) mwAccuracy = mwDefAccuracy + 132 + (mwEnchLvl - 15) * 10;

                }
                else if(mwId == 25)
                {
                    if (mwEnchLvl == 1) mwAccuracy = mwDefAccuracy + 8;
                    else if (mwEnchLvl >= 2 & mwEnchLvl <= 3) mwAccuracy = mwDefAccuracy + 8 + (mwEnchLvl - 1) * 6;
                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5) mwAccuracy = mwDefAccuracy + 20 + (mwEnchLvl - 3) * 4;
                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7) mwAccuracy = mwDefAccuracy + 28 + (mwEnchLvl - 5) * 6;
                    else if (mwEnchLvl == 8) mwAccuracy = mwDefAccuracy + 44;
                    else if (mwEnchLvl >= 9 & mwEnchLvl <= 10) mwAccuracy = mwDefAccuracy + 44 + (mwEnchLvl - 8) * 8;
                    else if (mwEnchLvl >= 11 & mwEnchLvl <= 20) mwAccuracy = mwDefAccuracy + 60 + (mwEnchLvl - 10) * 12;

                }

                else
                {
                    if (mwEnchLvl == 1) mwAccuracy = mwDefAccuracy + 8;
                    else if (mwEnchLvl >= 2 & mwEnchLvl <= 3) mwAccuracy = mwDefAccuracy + 8 + (mwEnchLvl - 1) * 6;
                    else if (mwEnchLvl >= 4 & mwEnchLvl <= 5) mwAccuracy = mwDefAccuracy + 20 + (mwEnchLvl - 3) * 4;
                    else if (mwEnchLvl >= 6 & mwEnchLvl <= 7) mwAccuracy = mwDefAccuracy + 28 + (mwEnchLvl - 5) * 6;
                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 10) mwAccuracy = mwDefAccuracy + 40 + (mwEnchLvl - 7) * 4;
                    else if(mwId ==31| mwId == 32 | mwId == 33 | mwId == 34 | mwId == 36 | mwId ==22|mwId == 27)
                    {
                        if(mwEnchLvl == 11) mwAccuracy = mwDefAccuracy + 40 + (mwEnchLvl - 7) * 4;
                        else mwAccuracy = mwDefAccuracy + 56 + (mwEnchLvl - 11) * 6;
                    }
                    else if (mwEnchLvl == 11) mwAccuracy = mwDefAccuracy + 64;
                    else if (mwEnchLvl >= 12 & mwEnchLvl <= 15) mwAccuracy = mwDefAccuracy + 64 + (mwEnchLvl - 11) * 14;
                    else if (mwEnchLvl >= 16 & mwEnchLvl <= 20) mwAccuracy = mwDefAccuracy + 120 + (mwEnchLvl - 15) * 10;
                }
                //AP against monsters
                if(mwId == 0)
                {
                    if(mwEnchLvl== 16) mwAPagainst = mwDefAPagainst +5;
                    else if (mwEnchLvl == 17) mwAPagainst = mwDefAPagainst + 12;
                    else if (mwEnchLvl == 18) mwAPagainst = mwDefAPagainst + 21;
                    else if (mwEnchLvl == 19) mwAPagainst = mwDefAPagainst + 32;
                    else if (mwEnchLvl == 20) mwAPagainst = mwDefAPagainst + 48;
                }
                else
                {
                    if (mwEnchLvl == 16) mwAPagainst = mwDefAPagainst + 1;
                    else if (mwEnchLvl == 17) mwAPagainst = mwDefAPagainst + 3;
                    else if (mwEnchLvl == 18) mwAPagainst = mwDefAPagainst + 6;
                    else if (mwEnchLvl == 19) mwAPagainst = mwDefAPagainst + 10;
                    else if (mwEnchLvl == 20) mwAPagainst = mwDefAPagainst + 15;
                }
                //Extra damage tp Humans
                if(mwId == 36| mwId == 13)
                {
                    mwDamageHumans = mwDefDamageHumans + mwEnchLvl;
                }
                else if(mwId == 34 | mwId == 12)
                {
                    if(mwEnchLvl >=1 & mwEnchLvl <= 15) mwDamageHumans = mwDefDamageHumans + mwEnchLvl;
                    else mwDamageHumans = mwDefDamageHumans + 15 +(mwEnchLvl-15)*2;

                }
                else mwDamageHumans = mwDefDamageHumans;

                //Extra Damage to All Species
                if ( mwId == 0)
                {
                    if(mwEnchLvl >= 1 & mwEnchLvl <=12) mwDamageAll = mwDefDamageAll;
                    else if (mwEnchLvl >= 13 & mwEnchLvl <= 20) mwDamageAll = mwDefDamageAll + (mwEnchLvl-12) * 1;
                }

                else if(mwId == 6|mwId == 7)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 10) mwDamageAll = mwDefDamageAll;
                    else if (mwEnchLvl >= 11 & mwEnchLvl <= 20) mwDamageAll = mwDefDamageAll + (mwEnchLvl - 10) * 1;
                }
                else if (mwId == 8 | mwId == 30)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 7) mwDamageAll = mwDefDamageAll;
                    else if (mwEnchLvl >= 8 & mwEnchLvl <= 20) mwDamageAll = mwDefDamageAll + (mwEnchLvl - 7) * 1;
                }
                else if (mwId == 26 | mwId == 28)
                {
                     mwDamageAll = mwDefDamageAll + mwEnchLvl * 1;
                }
                else mwDamageAll = mwDefDamageAll;
                
                //Extra damage tp DemiHumans
                if (mwId == 24 | mwId == 22)
                {
                    if (mwEnchLvl >= 1 & mwEnchLvl <= 15) mwDamDemi = mwDefDamDemi + mwEnchLvl;
                    else if(mwEnchLvl>= 16 & mwEnchLvl<=20) mwDamDemi = mwDefDamDemi +15+ (mwEnchLvl-15) * 2;
                }
                else mwDamDemi = mwDefDamDemi;
                
                mwAtkSpeed = mwDefAtkSpeed;
                mwCastSpeed = mwDefCastSpeed;
                mwIgnore = mwDefIgnore;
                mwCrit = mwDefCrit;
                mwHidenAP = mwDefHidenAP;
                mwRecoveryChance = mwDefRecoveryChance;


                cap += mwAP;
                cacc += mwAccuracy;
                ceapa += mwAPagainst;
                cedh += mwDamageHumans;
                ceda += mwDamageAll;
                cADtDemiH += mwDamDemi;
                cAtkSpeed += mwAtkSpeed;
                cCastSpeed += mwCastSpeed;
                ccr += mwCrit;
                chap += mwHidenAP;
                cResistIgnore += mwIgnore;
                cHPrecoveryChance += mwRecoveryChance;
            }
            else
            {
                cap -= mwAP;
                cacc -= mwAccuracy;
                ceapa -= mwAPagainst;
                cedh -= mwDamageHumans;
                ceda -= mwDamageAll;
                cADtDemiH -= mwDamDemi;
                cAtkSpeed -= mwAtkSpeed;
                cCastSpeed -= mwCastSpeed;
                ccr -= mwCrit;
                chap -= mwHidenAP;
                cResistIgnore -= mwIgnore;
                cHPrecoveryChance -= mwRecoveryChance;

                
                
                //AP High
                mwAPhigh = mwDefAPhigh;
                //AP Low
                mwAPlow = mwDefAPlow;
                //Main AP
                mwAP = (mwAPhigh + mwAPlow) / 2;
                //Accuracy
                mwAccuracy = mwDefAccuracy;
                //AP against monsters
                mwAPagainst = mwDefAPagainst;
                //Extra damage tp Humans
                 mwDamageHumans = mwDefDamageHumans;

                //Extra Damage to All Species
               mwDamageAll = mwDefDamageAll;

                //Extra damage tp DemiHumans
                 mwDamDemi = mwDefDamDemi;

                mwAtkSpeed = mwDefAtkSpeed;
                mwCastSpeed = mwDefCastSpeed;
                mwIgnore = mwDefIgnore;
                mwCrit = mwDefCrit;
                mwHidenAP = mwDefHidenAP;
                mwRecoveryChance = mwDefRecoveryChance;


                cap += mwAP;
                cacc += mwAccuracy;
                ceapa += mwAPagainst;
                cedh += mwDamageHumans;
                ceda += mwDamageAll;
                cADtDemiH += mwDamDemi;
                cAtkSpeed += mwAtkSpeed;
                cCastSpeed += mwCastSpeed;
                ccr += mwCrit;
                chap += mwHidenAP;
                cResistIgnore += mwIgnore;
                cHPrecoveryChance += mwRecoveryChance;
            }
        }
        public void SubWeaponState(string SubWeapon)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [" + SubWeapon + " Sub-Weapons] where Id='" + swId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (swEnch == true & swEnchLvl >= 1)
            {
                cap -= swAP;
                caap -= swAP;
                cacc -= swAccuracy;
                ceapa -= swAPagainst;
                chap -= swHidenAP;
                cResistIgnore -= swIgnore;
                cev -= swEvasion;
                chev -= swHEvasion;
                cDR -= swDR;
                cMaxHP -= swMaxHP;
                cMaxST -= swMaxST;
                cMaxMP -= swMaxMP;
                cRes1 -= swAllRes;
                cRes2 -= swAllRes;
                cRes3 -= swAllRes;
                cRes4 -= swAllRes;
                cdp -= swDP;
                cSpecialAttackEv -= swSpecialAttackEv;
                cSpecialAttackDam -= swSpecialAttackDam;


                //High and low AP
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 15)
                    {
                        swAPhigh = swDefAPhigh + swEnchLvl * 1;
                        swAPlow = swDefAPlow + swEnchLvl * 1;
                    }
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17)
                    {
                        swAPhigh = swDefAPhigh + 15 + (swEnchLvl - 15) * 2;
                        swAPlow = swDefAPlow + 15 + (swEnchLvl - 15) * 2;
                    }
                    else if (swEnchLvl == 18)
                    {
                        swAPhigh = swDefAPhigh + 23;
                        swAPlow = swDefAPlow + 23;
                    }
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20)
                    {
                        swAPhigh = swDefAPhigh + 23 + (swEnchLvl - 18) * 2;
                        swAPlow = swDefAPlow + 23 + (swEnchLvl - 18) * 2;
                    }

                }
                else if (swId == 2 | swId == 3 | swId == 33 | swId == 34)
                {
                    if (swEnchLvl <= 10)
                    {
                        swAPhigh = swDefAPhigh + swEnchLvl * 1;
                        swAPlow = swDefAPlow + swEnchLvl * 1;
                    }
                    else if (swEnchLvl >= 11 & swEnchLvl <= 15)
                    {
                        swAPhigh = swDefAPhigh + 10 + (swEnchLvl - 10) * 2;
                        swAPlow = swDefAPlow + 10 + (swEnchLvl - 10) * 2;
                    }
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17)
                    {
                        swAPhigh = swDefAPhigh + 20 + (swEnchLvl - 15) * 3;
                        swAPlow = swDefAPlow + 20 + (swEnchLvl - 15) * 3;
                    }
                    else if (swEnchLvl == 18)
                    {
                        swAPhigh = swDefAPhigh + 32;
                        swAPlow = swDefAPlow + 32;
                    }
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20)
                    {
                        swAPhigh = swDefAPhigh + 32 + (swEnchLvl - 18) * 3;
                        swAPlow = swDefAPlow + 32 + (swEnchLvl - 18) * 3;
                    }

                }
                else if (swId == 7 | swId == 11 | swId == 12 | swId == 38 | swId == 42 | swId == 43)
                {
                    if (swEnchLvl <= 15)
                    {
                        swAPhigh = swDefAPhigh + swEnchLvl * 1;
                        swAPlow = swDefAPlow + swEnchLvl * 1;
                    }
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17)
                    {
                        swAPhigh = swDefAPhigh + 15 + (swEnchLvl - 15) * 3;
                        swAPlow = swDefAPlow + 15 + (swEnchLvl - 15) * 3;
                    }
                    else if (swEnchLvl == 18)
                    {
                        swAPhigh = swDefAPhigh + 27;
                        swAPlow = swDefAPlow + 27;
                    }
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20)
                    {
                        swAPhigh = swDefAPhigh + 27 + (swEnchLvl - 18) * 3;
                        swAPlow = swDefAPlow + 27 + (swEnchLvl - 18) * 3;
                    }

                }
                else
                {
                    if (swEnchLvl <= 7)
                    {
                        swAPhigh = swDefAPhigh;
                        swAPlow = swDefAPlow;
                    }
                    else
                    {
                        swAPhigh = swDefAPhigh + (swEnchLvl - 7) * 1;
                        swAPlow = swDefAPlow + (swEnchLvl - 7) * 1;
                    }
                }
                //Main AP
                swAP = (swAPhigh + swAPlow) / 2;
                //Accuracy
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl == 1) swAccuracy = swDefAccuracy;
                    else if (swEnchLvl >= 2 & swEnchLvl <= 3) swAccuracy = swDefAccuracy + 1;
                    else if (swEnchLvl >= 4 & swEnchLvl <= 5) swAccuracy = swDefAccuracy + 2;
                    else if (swEnchLvl >= 6 & swEnchLvl <= 7) swAccuracy = swDefAccuracy + 3;
                    else if (swEnchLvl >= 8 & swEnchLvl <= 9) swAccuracy = swDefAccuracy + 4;
                    else if (swEnchLvl >= 10 & swEnchLvl <= 11) swAccuracy = swDefAccuracy + 5;
                    else if (swEnchLvl >= 12 & swEnchLvl <= 13) swAccuracy = swDefAccuracy + 6;
                    else if (swEnchLvl >= 14 & swEnchLvl <= 15) swAccuracy = swDefAccuracy + 7;
                    else swAccuracy = swDefAccuracy + 7 + (swEnchLvl - 15);
                }
                else if (swId == 19 | swId == 20 | swId == 50 | swId == 51)
                {
                    if (swEnchLvl == 1) swAccuracy = swDefAccuracy + 4;
                    else if (swEnchLvl >= 2 & swEnchLvl <= 3) swAccuracy = swDefAccuracy + 4 + (swEnchLvl - 1) * 3;
                    else if (swEnchLvl >= 4 & swEnchLvl <= 7) swAccuracy = swDefAccuracy + 10 + (swEnchLvl - 3) * 2;
                    else if (swEnchLvl >= 8 & swEnchLvl <= 9) swAccuracy = swDefAccuracy + 18 + (swEnchLvl - 7) * 3;
                    else swAccuracy = swDefAccuracy + 24 + (swEnchLvl - 9) * 4;
                }
                else swAccuracy = swDefAccuracy;
                //DP
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 7) swDP = swDefDP;
                    else if (swEnchLvl >= 8 & swEnchLvl <= 9) swDP = swDefDP + 1;
                    else if (swEnchLvl >= 10 & swEnchLvl <= 12) swDP = swDefDP + 1 + (swEnchLvl - 9);
                    else if (swEnchLvl == 13) swDP = swDefDP + 4;
                    else if (swEnchLvl >= 14 & swEnchLvl <= 15) swDP = swDefDP + 5;
                    else if (swEnchLvl == 16) swDP = swDefDP + 6;
                    else if (swEnchLvl == 17) swDP = swDefDP + 8;
                    else if (swEnchLvl == 18) swDP = swDefDP + 11;
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20) swDP = swDefDP + 11 + (swEnchLvl - 18) * 2;
                }
                else if (swId == 2 | swId == 3 | swId == 33 | swId == 34)
                {
                    if (swEnchLvl <= 15) swDP = swDefDP;
                    else if (swEnchLvl == 16) swDP = swDefDP + 3;
                    else swDP = swDefDP + 3 + (swEnchLvl - 16);
                }
                else if (swId == 7 | swId == 11 | swId == 12 | swId == 38 | swId == 42 | swId == 43)
                {
                    if (swEnchLvl <= 15) swDP = swDefDP;
                    else swDP = swDefDP + (swEnchLvl - 15);
                }
                else
                {
                    if (swEnchLvl <= 15) swDP = swDefDP + swEnchLvl;
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17) swDP = swDefDP + 15 + (swEnchLvl - 15) * 2;
                    else if (swEnchLvl == 18) swDP = swDefDP + 24;
                    else swDP = swDefDP + 24 + (swEnchLvl - 18) * 2;
                }

                //Damage Reduction
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 10) swDR = swDefDR;
                    else if (swEnchLvl >= 11 & swEnchLvl <= 16) swDR = swDefDR + 1;
                    else if (swEnchLvl == 17) swDR = swDefDR + 2;
                    else if (swEnchLvl == 18) swDR = swDefDR + 4;
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20) swDR = swDefDR + 4 + (swEnchLvl - 18);
                }
                else if (swId == 2 | swId == 3 | swId == 33 | swId == 34)
                {
                    if (swEnchLvl <= 15) swDR = swDefDR;
                    else if (swEnchLvl == 16) swDR = swDefDR + 3;
                    else swDR = swDefDR + 3 + (swEnchLvl - 16);
                }
                else if (swId == 7 | swId == 11 | swId == 12 | swId == 19 | swId == 20 | swId == 38 | swId == 42 | swId == 43 | swId == 50 | swId == 51)
                {
                    if (swEnchLvl <= 15) swDR = swDefDR;
                    else swDR = swDefDR + (swEnchLvl - 15);
                }
                else if (swId == 13 & SubWeapon == "Shield" | swId == 14 & SubWeapon == "Shield" | swId == 13 & SubWeapon == "Ornamental Knot" | swId == 14 & SubWeapon == "Ornamental Knot" | swId == 13 & SubWeapon == "Vambrace" | swId == 14 & SubWeapon == "Vambrace" | swId == 13 & SubWeapon == "Noble Sword" | swId == 14 & SubWeapon == "Noble Sword" | swId == 13 & SubWeapon == "Vitclari" | swId == 14 & SubWeapon == "Vitclari")
                {
                    if (swEnchLvl <= 15) swDR = swDefDR + swEnchLvl;
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17) swDR = swDefDR + 15 + (swEnchLvl - 15) * 2;
                    else if (swEnchLvl == 18) swDR = swDefDR + 24;
                    else swDR = swDefDR + 24 + (swEnchLvl - 18) * 2;
                }
                else swDR = swDefDR;
                //Evasion
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 7) swEvasion = swDefEvasion;
                    else if (swEnchLvl >= 8 & swEnchLvl <= 9) swEvasion = swDefEvasion + 1;
                    else if (swEnchLvl >= 10 & swEnchLvl <= 11) swEvasion = swDefEvasion + 2;
                    else if (swEnchLvl >= 12 & swEnchLvl <= 13) swEvasion = swDefEvasion + 3;
                    else if (swEnchLvl >= 14 & swEnchLvl <= 15) swEvasion = swDefEvasion + 4;
                    else swEvasion = swDefEvasion + 4 + (swEnchLvl - 15);
                }
                else if (swId >= 15 & swId <= 18 | swId == 13 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId == 14 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId >= 46 & swId <= 49 | swId == 44 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId == 45 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari")
                {
                    if (swEnchLvl <= 15) swEvasion = swDefEvasion + swEnchLvl;
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17) swEvasion = swDefEvasion + 15 + (swEnchLvl - 15) * 2;
                    else if (swEnchLvl == 18) swEvasion = swDefEvasion + 24;
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20) swEvasion = swDefEvasion + 24 + (swEnchLvl - 18) * 2;
                }
                else if (swId == 19 | swId == 20 | swId == 50 | swId == 51)
                {
                    if (swEnchLvl <= 17) swEvasion = swDefEvasion + swEnchLvl;
                    else if (swEnchLvl == 18) swEvasion = swDefEvasion + 21;
                    else swEvasion = swDefEvasion + 21 + (swEnchLvl - 18);

                }
                else swEvasion = swDefEvasion;
                //Hiden Evasion
                if (swId == 0 | swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 7) swHEvasion = swDefHEvasion;
                    else if (swEnchLvl >= 8 & swEnchLvl <= 9) swHEvasion = swDefHEvasion + 3;
                    else if (swEnchLvl >= 10 & swEnchLvl <= 11) swHEvasion = swDefHEvasion + 6;
                    else if (swEnchLvl >= 12 & swEnchLvl <= 13) swHEvasion = swDefHEvasion + 9;
                    else if (swEnchLvl >= 14 & swEnchLvl <= 15) swHEvasion = swDefHEvasion + 12;
                    else swHEvasion = swDefHEvasion + 12 + (swEnchLvl - 15) * 3;
                }
                else if (swId == 13 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId == 14 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId == 44 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari" | swId == 45 & SubWeapon != "Shield" & SubWeapon != "Ornamental Knot" & SubWeapon != "Vambrace" & SubWeapon != "Noble Sword" & SubWeapon != "Vitclari")
                {
                    if (swEnchLvl <= 15) swHEvasion = swDefHEvasion + swEnchLvl * 3;
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17) swHEvasion = swDefHEvasion + 45 + (swEnchLvl - 15) * 6;
                    else if (swEnchLvl == 18) swHEvasion = swDefHEvasion + 72;
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20) swHEvasion = swDefHEvasion + 72 + (swEnchLvl - 18) * 6;
                }
                else if (swId >= 15 & swId <= 18 | swId >= 46 & swId <= 49)
                {
                    if (swEnchLvl <= 15) swHEvasion = swDefHEvasion + swEnchLvl *2;
                    else if (swEnchLvl >= 16 & swEnchLvl <= 17) swHEvasion = swDefHEvasion + 30 + (swEnchLvl - 15) * 4;
                    else if (swEnchLvl == 18) swHEvasion = swDefHEvasion + 48;
                    else if (swEnchLvl >= 19 & swEnchLvl <= 20) swHEvasion = swDefHEvasion + 48 + (swEnchLvl - 18) * 4;
                }
                else if (swId == 19 | swId == 20 | swId == 50 | swId == 51)
                {
                    if (swEnchLvl <= 17) swHEvasion = swDefHEvasion + swEnchLvl;
                    else if (swEnchLvl == 18) swHEvasion = swDefHEvasion + 21;
                    else swHEvasion = swDefHEvasion + 21 + (swEnchLvl - 18);

                }
                else swHEvasion = swDefHEvasion;

                //AP against monsters
                if (swId == 0|swId == 1 | swId == 31 | swId == 32)
                {
                    if (swEnchLvl <= 15) swAPagainst = swDefAPagainst + swEnchLvl;
                    else if (swEnchLvl == 16) swAPagainst = swDefAPagainst + 23;
                    else if (swEnchLvl == 17) swAPagainst = swDefAPagainst + 28;
                    else if (swEnchLvl == 18) swAPagainst = swDefAPagainst + 38;
                    else if (swEnchLvl == 19) swAPagainst = swDefAPagainst + 53;
                    else if (swEnchLvl == 20) swAPagainst = swDefAPagainst + 57;
                }
                else
                {
                    if (swEnchLvl <= 15) swAPagainst = swDefAPagainst;
                    else swAPagainst = swDefAPagainst + (swEnchLvl-15);
                }
                //Max HP
                swMaxHP = swDefMaxHP;
                //Max Stamina
                swMaxST = swDefMaxST;
                //Max MP
                swMaxMP = swDefMaxMP;
                //All Resistance
                swAllRes = swDefAllRes;
                //Special attack Evasion Rate
                swSpecialAttackEv = swDefSpecialAttackEv;
                //Special attack extra damage
                swSpecialAttackDam = swDefSpecialAttackDam;
                //Ignore all resistance
                swIgnore = swDefIgnore;
                //Hiden AP
                swHidenAP = swDefHidenAP;

                cap += swAP;
                caap += swAP;
                cacc += swAccuracy;
                ceapa += swAPagainst;
                chap += swHidenAP;
                cResistIgnore += swIgnore;
                cev += swEvasion;
                chev += swHEvasion;
                cDR += swDR;
                cMaxHP += swMaxHP;
                cMaxST += swMaxST;
                cMaxMP += swMaxMP;
                cRes1 += swAllRes;
                cRes2 += swAllRes;
                cRes3 += swAllRes;
                cRes4 += swAllRes;
                cdp += swDP;
                cSpecialAttackEv += swSpecialAttackEv;
                cSpecialAttackDam += swSpecialAttackDam;
            }
            else
            {
                cap -= swAP;
                caap -= swAP;
                cacc -= swAccuracy;
                ceapa -= swAPagainst;
                chap -= swHidenAP;
                cResistIgnore -= swIgnore;
                cev -= swEvasion;
                chev -= swHEvasion;
                cDR -= swDR;
                cMaxHP -= swMaxHP;
                cMaxST -= swMaxST;
                cMaxMP -= swMaxMP;
                cRes1 -= swAllRes;
                cRes2 -= swAllRes;
                cRes3 -= swAllRes;
                cRes4 -= swAllRes;
                cdp -= swDP;
                cSpecialAttackEv -= swSpecialAttackEv;
                cSpecialAttackDam -= swSpecialAttackDam;



                //AP High
                swAPhigh = swDefAPhigh;
                //AP Low
                swAPlow = swDefAPlow;
                //Main AP
                swAP = (swAPhigh + swAPlow) / 2;
                //Accuracy
                swAccuracy = swDefAccuracy;
                //AP against monsters
                swAPagainst = swDefAPagainst;
                //Ignore all resistance
                swIgnore = swDefIgnore;
                //Hiden AP
                swHidenAP = swDefHidenAP;
                //Evasion
                swEvasion = swDefEvasion;
                //Hiden Evasion
                swHEvasion = swDefHEvasion;
                //Damage Reduction
                swDR = swDefDR;
                //Max HP
                swMaxHP = swDefMaxHP;
                //Max Stamina
                swMaxST = swDefMaxST;
                //Max MP
                swMaxMP = swDefMaxMP;
                //All Resistance
                swAllRes = swDefAllRes;
                //Special attack Evasion Rate
                swSpecialAttackEv = swDefSpecialAttackEv;
                //Special attack extra damage
                swSpecialAttackDam = swDefSpecialAttackDam;
                //DP
                swDP = swDefDP;

                cap += swAP;
                caap += swAP;
                cacc += swAccuracy;
                ceapa += swAPagainst;
                chap += swHidenAP;
                cResistIgnore += swIgnore;
                cev += swEvasion;
                chev += swHEvasion;
                cDR += swDR;
                cMaxHP += swMaxHP;
                cMaxST += swMaxST;
                cMaxMP += swMaxMP;
                cRes1 += swAllRes;
                cRes2 += swAllRes;
                cRes3 += swAllRes;
                cRes4 += swAllRes;
                cdp += swDP;
                cSpecialAttackEv += swSpecialAttackEv;
                cSpecialAttackDam += swSpecialAttackDam;
            }
        }

        public void AlchemyStoneState()
        {
            cap -= asAP;
            caap -= asAP;
            chap -= asHidenAP;
            cacc -= asAccuracy;
            cResistIgnore -= asIgnore;
            cAtkSpeedRate -= asAtkSpeed;
            cCastSpeedRate -= asCastSpeed;
            cAlchCookTime -= asAlchCookTime;
            cProccesingRate -= asProcRate;
            cWeight -= asWeightLimit;
            cGathering -= asGathFish;
            cFishing -= asGathFish;
            cGathDropRate -= asGathDropRate;
            cDR -= asDR;
            cev -= asEvasion;
            cMaxHP -= asMaxHP;
            cRes1 -= asAllRes;
            cRes2 -= asAllRes;
            cRes3 -= asAllRes;
            cRes4 -= asAllRes;

            asAPhigh = asDefAPhigh;
            asAPlow = asDefAPlow;
            asAP = (asAPhigh + asAPlow) / 2;
            asHidenAP = asDefHidenAP;
            asAccuracy = asDefAccuracy;
            asIgnore = asDefIgnore;
            asAtkSpeed = asDefAtkSpeed;
            asCastSpeed = asDefCastSpeed;
            asAlchCookTime = asDefAlchCookTime;
            asProcRate = asDefProcRate;
            asWeightLimit = asDefWeightLimit;
            asGathFish = asDefGathFish;
            asGathDropRate = asDefGathDropRate;
            asDR = asDefDR;
            asEvasion = asDefEvasion;
            asMaxHP = asDefMaxHP;
            asAllRes = asDefAllRes;

            caap += asAP;
            cap += asAP;
            chap += asHidenAP;
            cacc += asAccuracy;
            cResistIgnore += asIgnore;
            cAtkSpeedRate += asAtkSpeed;
            cCastSpeedRate += asCastSpeed;
            cAlchCookTime += asAlchCookTime;
            cProccesingRate += asProcRate;
            cWeight += asWeightLimit;
            cGathering += asGathFish;
            cFishing += asGathFish;
            cGathDropRate += asGathDropRate;
            cDR += asDR;
            cev += asEvasion;
            cMaxHP += asMaxHP;
            cRes1 += asAllRes;
            cRes2 += asAllRes;
            cRes3 += asAllRes;
            cRes4 += asAllRes;

        }

        public void AllArmorCaphState() //allArmCaphLvl
        {
            if (sgn == 7)
            {
                if (armEnchLvl == 18 | armEnchLvl == 19)
                {
                    cMaxHP -= c_armHP;
                    cdp -= c_armdp;
                    cev -= c_armev;
                    chev -= c_armhev;
                    cDR -= c_armdr;
                    cMaxMP -= c_armMP;
                    chdr -= c_armhdr;

                    if (armCaphLvl == 0) { c_armHP = 0; c_armdp = 0; c_armev = 0; c_armhev = 0; c_armdr = 0; c_armMP = 0; c_armhdr = 0; }
                    if (armCaphLvl == 1) { c_armHP = 10; }
                    if (armCaphLvl == 2) { c_armHP = 20; c_armdp = 1; c_armev = 1; c_armhev = 2; }
                    if (armCaphLvl == 3) { c_armHP = 30; c_armdp = 3; c_armev = 2; c_armhev = 3; c_armdr = 1; }
                    if (armCaphLvl == 4) { c_armHP = 50; c_armdp = 4; c_armev = 3; c_armhev = 4; c_armdr = 1; }
                    if (armCaphLvl == 5) { c_armHP = 50; c_armdp = 4; c_armev = 3; c_armhev = 4; c_armdr = 1; c_armMP = 5; }
                    if (armCaphLvl == 6) { c_armHP = 50; c_armdp = 4; c_armev = 3; c_armhev = 4; c_armdr = 1; c_armMP = 10; }
                    if (armCaphLvl == 7) { c_armHP = 50; c_armdp = 4; c_armev = 3; c_armhev = 5; c_armdr = 1; c_armMP = 10; }
                    if (armCaphLvl == 8) { c_armHP = 50; c_armdp = 4; c_armev = 3; c_armhev = 5; c_armdr = 1; c_armMP = 10; c_armhdr = 1; }
                    if (armCaphLvl == 9) { c_armHP = 60; c_armdp = 4; c_armev = 3; c_armhev = 5; c_armdr = 1; c_armMP = 10; c_armhdr = 1; }
                    if (armCaphLvl == 10) { c_armHP = 60; c_armdp = 4; c_armev = 3; c_armhev = 5; c_armdr = 1; c_armMP = 15; c_armhdr = 1; }
                    if (armCaphLvl == 11) { c_armHP = 60; c_armdp = 4; c_armev = 3; c_armhev = 5; c_armdr = 1; c_armMP = 20; c_armhdr = 1; }
                    if (armCaphLvl == 12) { c_armHP = 60; c_armdp = 4; c_armev = 3; c_armhev = 6; c_armdr = 1; c_armMP = 20; c_armhdr = 1; }
                    if (armCaphLvl == 13) { c_armHP = 70; c_armdp = 4; c_armev = 3; c_armhev = 6; c_armdr = 1; c_armMP = 20; c_armhdr = 1; }
                    if (armCaphLvl == 14) { c_armHP = 70; c_armdp = 4; c_armev = 3; c_armhev = 6; c_armdr = 1; c_armMP = 25; c_armhdr = 1; }
                    if (armCaphLvl == 15) { c_armHP = 70; c_armdp = 4; c_armev = 3; c_armhev = 6; c_armdr = 1; c_armMP = 30; c_armhdr = 1; }
                    if (armCaphLvl == 16) { c_armHP = 70; c_armdp = 4; c_armev = 3; c_armhev = 6; c_armdr = 1; c_armMP = 30; c_armhdr = 2; }
                    if (armCaphLvl == 17) { c_armHP = 70; c_armdp = 4; c_armev = 3; c_armhev = 7; c_armdr = 1; c_armMP = 30; c_armhdr = 2; }
                    if (armCaphLvl == 18) { c_armHP = 80; c_armdp = 4; c_armev = 3; c_armhev = 7; c_armdr = 1; c_armMP = 30; c_armhdr = 2; }
                    if (armCaphLvl == 19) { c_armHP = 80; c_armdp = 4; c_armev = 3; c_armhev = 8; c_armdr = 1; c_armMP = 30; c_armhdr = 2; }
                    if (armCaphLvl == 20) { c_armHP = 80; c_armdp = 4; c_armev = 3; c_armhev = 8; c_armdr = 1; c_armMP = 30; c_armhdr = 3; }

                    cMaxHP += c_armHP;
                    cdp += c_armdp;
                    cev += c_armev;
                    chev += c_armhev;
                    cDR += c_armdr;
                    cMaxMP += c_armMP;
                    chdr += c_armhdr;
                }
                if (armEnchLvl == 20)
                {
                    cMaxHP -= c_armHP;
                    cdp -= c_armdp;
                    cev -= c_armev;
                    chev -= c_armhev;
                    cDR -= c_armdr;
                    cMaxMP -= c_armMP;
                    chdr -= c_armhdr;

                    if (armCaphLvl == 0) { c_armHP = 0; c_armdp = 0; c_armev = 0; c_armhev = 0; c_armdr = 0; c_armMP = 0; c_armhdr = 0; }
                    if (armCaphLvl == 1) { c_armHP = 20; c_armdp = 1; c_armev = 1; c_armhev = 1; c_armMP = 0; }
                    if (armCaphLvl == 2) { c_armHP = 30; c_armdp = 2; c_armev = 1; c_armhev = 1; c_armdr = 1; c_armhdr = 1; c_armMP = 0; }
                    if (armCaphLvl == 3) { c_armHP = 40; c_armdp = 3; c_armev = 2; c_armhev = 2; c_armdr = 1; c_armhdr = 1; c_armMP = 0; }
                    if (armCaphLvl == 4) { c_armHP = 50; c_armdp = 4; c_armev = 2; c_armhev = 2; c_armdr = 2; c_armhdr = 2; c_armMP = 0; }
                    if (armCaphLvl == 5) { c_armHP = 60; c_armdp = 5; c_armev = 3; c_armhev = 3; c_armdr = 2; c_armhdr = 2; c_armMP = 0; }
                    if (armCaphLvl == 6) { c_armHP = 70; c_armdp = 6; c_armev = 3; c_armhev = 3; c_armdr = 3; c_armhdr = 3; c_armMP = 0; }
                    if (armCaphLvl == 7) { c_armHP = 80; c_armdp = 7; c_armev = 4; c_armhev = 4; c_armdr = 3; c_armhdr = 3; c_armMP = 0; }
                    if (armCaphLvl == 8) { c_armHP = 90; c_armdp = 8; c_armev = 4; c_armhev = 4; c_armdr = 4; c_armhdr = 4; c_armMP = 0; }
                    if (armCaphLvl == 9) { c_armHP = 100; c_armdp = 10; c_armev = 5; c_armhev = 5; c_armdr = 5; c_armhdr = 5; c_armMP = 0; }
                    if (armCaphLvl == 10) { c_armHP = 110; c_armdp = 10; c_armev = 5; c_armhev = 6; c_armdr = 5; c_armhdr = 5; c_armMP = 0; }
                    if (armCaphLvl == 11) { c_armHP = 120; c_armdp = 10; c_armev = 5; c_armhev = 6; c_armdr = 5; c_armhdr = 6; c_armMP = 0; }
                    if (armCaphLvl == 12) { c_armHP = 120; c_armdp = 11; c_armev = 6; c_armhev = 6; c_armdr = 5; c_armhdr = 6; c_armMP = 0; }
                    if (armCaphLvl == 13) { c_armHP = 120; c_armdp = 12; c_armev = 6; c_armhev = 6; c_armdr = 6; c_armhdr = 6; c_armMP = 0; }
                    if (armCaphLvl == 14) { c_armHP = 130; c_armdp = 12; c_armev = 6; c_armhev = 7; c_armdr = 6; c_armhdr = 6; c_armMP = 0; }
                    if (armCaphLvl == 15) { c_armHP = 140; c_armdp = 12; c_armev = 6; c_armhev = 7; c_armdr = 6; c_armhdr = 7; c_armMP = 0; }
                    if (armCaphLvl == 16) { c_armHP = 140; c_armdp = 13; c_armev = 7; c_armhev = 7; c_armdr = 6; c_armhdr = 7; c_armMP = 0; }
                    if (armCaphLvl == 17) { c_armHP = 140; c_armdp = 14; c_armev = 7; c_armhev = 7; c_armdr = 7; c_armhdr = 7; c_armMP = 0; }
                    if (armCaphLvl == 18) { c_armHP = 150; c_armdp = 14; c_armev = 7; c_armhev = 8; c_armdr = 7; c_armhdr = 7; c_armMP = 0; }
                    if (armCaphLvl == 19) { c_armHP = 160; c_armdp = 14; c_armev = 7; c_armhev = 8; c_armdr = 7; c_armhdr = 8; c_armMP = 0; }
                    if (armCaphLvl == 20) { c_armHP = 160; c_armdp = 16; c_armev = 8; c_armhev = 8; c_armdr = 8; c_armhdr = 8; c_armMP = 0; }

                    cMaxHP += c_armHP;
                    cdp += c_armdp;
                    cev += c_armev;
                    chev += c_armhev;
                    cDR += c_armdr;
                    cMaxMP += c_armMP;
                    chdr += c_armhdr;
                }
            }
            if (sgn == 8)
            {
                if (helEnchLvl == 18 | helEnchLvl == 19)
                {
                    cMaxHP -= c_helHP;
                    cdp -= c_heldp;
                    cev -= c_helev;
                    chev -= c_helhev;
                    cDR -= c_heldr;
                    cMaxMP -= c_helMP;
                    chdr -= c_helhdr;

                    if (helCaphLvl == 0) { c_helHP = 0; c_heldp = 0; c_helev = 0; c_helhev = 0; c_heldr = 0; c_helMP = 0; c_helhdr = 0; }
                    if (helCaphLvl == 1) { c_helHP = 10; }
                    if (helCaphLvl == 2) { c_helHP = 20; c_heldp = 1; c_helev = 1; c_helhev = 2; }
                    if (helCaphLvl == 3) { c_helHP = 30; c_heldp = 3; c_helev = 2; c_helhev = 3; c_heldr = 1; }
                    if (helCaphLvl == 4) { c_helHP = 50; c_heldp = 4; c_helev = 3; c_helhev = 4; c_heldr = 1; }
                    if (helCaphLvl == 5) { c_helHP = 50; c_heldp = 4; c_helev = 3; c_helhev = 4; c_heldr = 1; c_helMP = 5; }
                    if (helCaphLvl == 6) { c_helHP = 50; c_heldp = 4; c_helev = 3; c_helhev = 4; c_heldr = 1; c_helMP = 10; }
                    if (helCaphLvl == 7) { c_helHP = 50; c_heldp = 4; c_helev = 3; c_helhev = 5; c_heldr = 1; c_helMP = 10; }
                    if (helCaphLvl == 8) { c_helHP = 50; c_heldp = 4; c_helev = 3; c_helhev = 5; c_heldr = 1; c_helMP = 10; c_helhdr = 1; }
                    if (helCaphLvl == 9) { c_helHP = 60; c_heldp = 4; c_helev = 3; c_helhev = 5; c_heldr = 1; c_helMP = 10; c_helhdr = 1; }
                    if (helCaphLvl == 10) { c_helHP = 60; c_heldp = 4; c_helev = 3; c_helhev = 5; c_heldr = 1; c_helMP = 15; c_helhdr = 1; }
                    if (helCaphLvl == 11) { c_helHP = 60; c_heldp = 4; c_helev = 3; c_helhev = 5; c_heldr = 1; c_helMP = 20; c_helhdr = 1; }
                    if (helCaphLvl == 12) { c_helHP = 60; c_heldp = 4; c_helev = 3; c_helhev = 6; c_heldr = 1; c_helMP = 20; c_helhdr = 1; }
                    if (helCaphLvl == 13) { c_helHP = 70; c_heldp = 4; c_helev = 3; c_helhev = 6; c_heldr = 1; c_helMP = 20; c_helhdr = 1; }
                    if (helCaphLvl == 14) { c_helHP = 70; c_heldp = 4; c_helev = 3; c_helhev = 6; c_heldr = 1; c_helMP = 25; c_helhdr = 1; }
                    if (helCaphLvl == 15) { c_helHP = 70; c_heldp = 4; c_helev = 3; c_helhev = 6; c_heldr = 1; c_helMP = 30; c_helhdr = 1; }
                    if (helCaphLvl == 16) { c_helHP = 70; c_heldp = 4; c_helev = 3; c_helhev = 6; c_heldr = 1; c_helMP = 30; c_helhdr = 2; }
                    if (helCaphLvl == 17) { c_helHP = 70; c_heldp = 4; c_helev = 3; c_helhev = 7; c_heldr = 1; c_helMP = 30; c_helhdr = 2; }
                    if (helCaphLvl == 18) { c_helHP = 80; c_heldp = 4; c_helev = 3; c_helhev = 7; c_heldr = 1; c_helMP = 30; c_helhdr = 2; }
                    if (helCaphLvl == 19) { c_helHP = 80; c_heldp = 4; c_helev = 3; c_helhev = 8; c_heldr = 1; c_helMP = 30; c_helhdr = 2; }
                    if (helCaphLvl == 20) { c_helHP = 80; c_heldp = 4; c_helev = 3; c_helhev = 8; c_heldr = 1; c_helMP = 30; c_helhdr = 3; }

                    cMaxHP += c_helHP;
                    cdp += c_heldp;
                    cev += c_helev;
                    chev += c_helhev;
                    cDR += c_heldr;
                    cMaxMP += c_helMP;
                    chdr += c_helhdr;

                }
                if (helEnchLvl == 20)
                {
                    cMaxHP -= c_helHP;
                    cdp -= c_heldp;
                    cev -= c_helev;
                    chev -= c_helhev;
                    cDR -= c_heldr;
                    cMaxMP -= c_helMP;
                    chdr -= c_helhdr;

                    if (helCaphLvl == 0) { c_helHP = 0; c_heldp = 0; c_helev = 0; c_helhev = 0; c_heldr = 0; c_helMP = 0; c_helhdr = 0; }
                    if (helCaphLvl == 1) { c_helHP = 20; c_heldp = 1; c_helev = 1; c_helhev = 1; c_helMP = 0; }
                    if (helCaphLvl == 2) { c_helHP = 30; c_heldp = 2; c_helev = 1; c_helhev = 1; c_heldr = 1; c_helhdr = 1; }
                    if (helCaphLvl == 3) { c_helHP = 40; c_heldp = 3; c_helev = 2; c_helhev = 2; c_heldr = 1; c_helhdr = 1; }
                    if (helCaphLvl == 4) { c_helHP = 50; c_heldp = 4; c_helev = 2; c_helhev = 2; c_heldr = 2; c_helhdr = 2; }
                    if (helCaphLvl == 5) { c_helHP = 60; c_heldp = 5; c_helev = 3; c_helhev = 3; c_heldr = 2; c_helhdr = 2; }
                    if (helCaphLvl == 6) { c_helHP = 70; c_heldp = 6; c_helev = 3; c_helhev = 3; c_heldr = 3; c_helhdr = 3; }
                    if (helCaphLvl == 7) { c_helHP = 80; c_heldp = 7; c_helev = 4; c_helhev = 4; c_heldr = 3; c_helhdr = 3; }
                    if (helCaphLvl == 8) { c_helHP = 90; c_heldp = 8; c_helev = 4; c_helhev = 4; c_heldr = 4; c_helhdr = 4; }
                    if (helCaphLvl == 9) { c_helHP = 100; c_heldp = 10; c_helev = 5; c_helhev = 5; c_heldr = 5; c_helhdr = 5; }
                    if (helCaphLvl == 10) { c_helHP = 110; c_heldp = 10; c_helev = 5; c_helhev = 6; c_heldr = 5; c_helhdr = 5; }
                    if (helCaphLvl == 11) { c_helHP = 120; c_heldp = 10; c_helev = 5; c_helhev = 6; c_heldr = 5; c_helhdr = 6; }
                    if (helCaphLvl == 12) { c_helHP = 120; c_heldp = 11; c_helev = 6; c_helhev = 6; c_heldr = 5; c_helhdr = 6; }
                    if (helCaphLvl == 13) { c_helHP = 120; c_heldp = 12; c_helev = 6; c_helhev = 6; c_heldr = 6; c_helhdr = 6; }
                    if (helCaphLvl == 14) { c_helHP = 130; c_heldp = 12; c_helev = 6; c_helhev = 7; c_heldr = 6; c_helhdr = 6; }
                    if (helCaphLvl == 15) { c_helHP = 140; c_heldp = 12; c_helev = 6; c_helhev = 7; c_heldr = 6; c_helhdr = 7; }
                    if (helCaphLvl == 16) { c_helHP = 140; c_heldp = 13; c_helev = 7; c_helhev = 7; c_heldr = 6; c_helhdr = 7; }
                    if (helCaphLvl == 17) { c_helHP = 140; c_heldp = 14; c_helev = 7; c_helhev = 7; c_heldr = 7; c_helhdr = 7; }
                    if (helCaphLvl == 18) { c_helHP = 150; c_heldp = 14; c_helev = 7; c_helhev = 8; c_heldr = 7; c_helhdr = 7; }
                    if (helCaphLvl == 19) { c_helHP = 160; c_heldp = 14; c_helev = 7; c_helhev = 8; c_heldr = 7; c_helhdr = 8; }
                    if (helCaphLvl == 20) { c_helHP = 160; c_heldp = 16; c_helev = 8; c_helhev = 8; c_heldr = 8; c_helhdr = 8; }

                    cMaxHP += c_helHP;
                    cdp += c_heldp;
                    cev += c_helev;
                    chev += c_helhev;
                    cDR += c_heldr;
                    cMaxMP += c_helMP;
                    chdr += c_helhdr;
                }
            }
            if (sgn == 9)
            {
                if (glovEnchLvl == 18 | glovEnchLvl == 19)
                {
                    cMaxHP -= c_glovHP;
                    cdp -= c_glovdp;
                    cev -= c_glovev;
                    chev -= c_glovhev;
                    cDR -= c_glovdr;
                    cMaxMP -= c_glovMP;
                    chdr -= c_glovhdr;

                    if (glovCaphLvl == 0) { c_glovHP = 0; c_glovdp = 0; c_glovev = 0; c_glovhev = 0; c_glovdr = 0; c_glovMP = 0; c_glovhdr = 0; }
                    if (glovCaphLvl == 1) { c_glovHP = 10; }
                    if (glovCaphLvl == 2) { c_glovHP = 20; c_glovdp = 1; c_glovev = 1; c_glovhev = 2; }
                    if (glovCaphLvl == 3) { c_glovHP = 30; c_glovdp = 3; c_glovev = 2; c_glovhev = 3; c_glovdr = 1; }
                    if (glovCaphLvl == 4) { c_glovHP = 50; c_glovdp = 4; c_glovev = 3; c_glovhev = 4; c_glovdr = 1; }
                    if (glovCaphLvl == 5) { c_glovHP = 50; c_glovdp = 4; c_glovev = 3; c_glovhev = 4; c_glovdr = 1; c_glovMP = 5; }
                    if (glovCaphLvl == 6) { c_glovHP = 50; c_glovdp = 4; c_glovev = 3; c_glovhev = 4; c_glovdr = 1; c_glovMP = 10; }
                    if (glovCaphLvl == 7) { c_glovHP = 50; c_glovdp = 4; c_glovev = 3; c_glovhev = 5; c_glovdr = 1; c_glovMP = 10; }
                    if (glovCaphLvl == 8) { c_glovHP = 50; c_glovdp = 4; c_glovev = 3; c_glovhev = 5; c_glovdr = 1; c_glovMP = 10; c_glovhdr = 1; }
                    if (glovCaphLvl == 9) { c_glovHP = 60; c_glovdp = 4; c_glovev = 3; c_glovhev = 5; c_glovdr = 1; c_glovMP = 10; c_glovhdr = 1; }
                    if (glovCaphLvl == 10) { c_glovHP = 60; c_glovdp = 4; c_glovev = 3; c_glovhev = 5; c_glovdr = 1; c_glovMP = 15; c_glovhdr = 1; }
                    if (glovCaphLvl == 11) { c_glovHP = 60; c_glovdp = 4; c_glovev = 3; c_glovhev = 5; c_glovdr = 1; c_glovMP = 20; c_glovhdr = 1; }
                    if (glovCaphLvl == 12) { c_glovHP = 60; c_glovdp = 4; c_glovev = 3; c_glovhev = 6; c_glovdr = 1; c_glovMP = 20; c_glovhdr = 1; }
                    if (glovCaphLvl == 13) { c_glovHP = 70; c_glovdp = 4; c_glovev = 3; c_glovhev = 6; c_glovdr = 1; c_glovMP = 20; c_glovhdr = 1; }
                    if (glovCaphLvl == 14) { c_glovHP = 70; c_glovdp = 4; c_glovev = 3; c_glovhev = 6; c_glovdr = 1; c_glovMP = 25; c_glovhdr = 1; }
                    if (glovCaphLvl == 15) { c_glovHP = 70; c_glovdp = 4; c_glovev = 3; c_glovhev = 6; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 1; }
                    if (glovCaphLvl == 16) { c_glovHP = 70; c_glovdp = 4; c_glovev = 3; c_glovhev = 6; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 2; }
                    if (glovCaphLvl == 17) { c_glovHP = 70; c_glovdp = 4; c_glovev = 3; c_glovhev = 7; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 2; }
                    if (glovCaphLvl == 18) { c_glovHP = 80; c_glovdp = 4; c_glovev = 3; c_glovhev = 7; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 2; }
                    if (glovCaphLvl == 19) { c_glovHP = 80; c_glovdp = 4; c_glovev = 3; c_glovhev = 8; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 2; }
                    if (glovCaphLvl == 20) { c_glovHP = 80; c_glovdp = 4; c_glovev = 3; c_glovhev = 8; c_glovdr = 1; c_glovMP = 30; c_glovhdr = 3; }

                    cMaxHP += c_glovHP;
                    cdp += c_glovdp;
                    cev += c_glovev;
                    chev += c_glovhev;
                    cDR += c_glovdr;
                    cMaxMP += c_glovMP;
                    chdr += c_glovhdr;

                }
                if (glovEnchLvl == 20)
                {
                    cMaxHP -= c_glovHP;
                    cdp -= c_glovdp;
                    cev -= c_glovev;
                    chev -= c_glovhev;
                    cDR -= c_glovdr;
                    cMaxMP -= c_glovMP;
                    chdr -= c_glovhdr;

                    if (glovCaphLvl == 0) { c_glovHP = 0; c_glovdp = 0; c_glovev = 0; c_glovhev = 0; c_glovdr = 0; c_glovMP = 0; c_glovhdr = 0; }
                    if (glovCaphLvl == 1) { c_glovHP = 20; c_glovdp = 1; c_glovev = 1; c_glovhev = 1; }
                    if (glovCaphLvl == 2) { c_glovHP = 30; c_glovdp = 2; c_glovev = 1; c_glovhev = 1; c_glovdr = 1; c_glovhdr = 1; }
                    if (glovCaphLvl == 3) { c_glovHP = 40; c_glovdp = 3; c_glovev = 2; c_glovhev = 2; c_glovdr = 1; c_glovhdr = 1; }
                    if (glovCaphLvl == 4) { c_glovHP = 50; c_glovdp = 4; c_glovev = 2; c_glovhev = 2; c_glovdr = 2; c_glovhdr = 2; }
                    if (glovCaphLvl == 5) { c_glovHP = 60; c_glovdp = 5; c_glovev = 3; c_glovhev = 3; c_glovdr = 2; c_glovhdr = 2; }
                    if (glovCaphLvl == 6) { c_glovHP = 70; c_glovdp = 6; c_glovev = 3; c_glovhev = 3; c_glovdr = 3; c_glovhdr = 3; }
                    if (glovCaphLvl == 7) { c_glovHP = 80; c_glovdp = 7; c_glovev = 4; c_glovhev = 4; c_glovdr = 3; c_glovhdr = 3; }
                    if (glovCaphLvl == 8) { c_glovHP = 90; c_glovdp = 8; c_glovev = 4; c_glovhev = 4; c_glovdr = 4; c_glovhdr = 4; }
                    if (glovCaphLvl == 9) { c_glovHP = 100; c_glovdp = 10; c_glovev = 5; c_glovhev = 5; c_glovdr = 5; c_glovhdr = 5; }
                    if (glovCaphLvl == 10) { c_glovHP = 110; c_glovdp = 10; c_glovev = 5; c_glovhev = 6; c_glovdr = 5; c_glovhdr = 5; }
                    if (glovCaphLvl == 11) { c_glovHP = 120; c_glovdp = 10; c_glovev = 5; c_glovhev = 6; c_glovdr = 5; c_glovhdr = 6; }
                    if (glovCaphLvl == 12) { c_glovHP = 120; c_glovdp = 11; c_glovev = 6; c_glovhev = 6; c_glovdr = 5; c_glovhdr = 6; }
                    if (glovCaphLvl == 13) { c_glovHP = 120; c_glovdp = 12; c_glovev = 6; c_glovhev = 6; c_glovdr = 6; c_glovhdr = 6; }
                    if (glovCaphLvl == 14) { c_glovHP = 130; c_glovdp = 12; c_glovev = 6; c_glovhev = 7; c_glovdr = 6; c_glovhdr = 6; }
                    if (glovCaphLvl == 15) { c_glovHP = 140; c_glovdp = 12; c_glovev = 6; c_glovhev = 7; c_glovdr = 6; c_glovhdr = 7; }
                    if (glovCaphLvl == 16) { c_glovHP = 140; c_glovdp = 13; c_glovev = 7; c_glovhev = 7; c_glovdr = 6; c_glovhdr = 7; }
                    if (glovCaphLvl == 17) { c_glovHP = 140; c_glovdp = 14; c_glovev = 7; c_glovhev = 7; c_glovdr = 7; c_glovhdr = 7; }
                    if (glovCaphLvl == 18) { c_glovHP = 150; c_glovdp = 14; c_glovev = 7; c_glovhev = 8; c_glovdr = 7; c_glovhdr = 7; }
                    if (glovCaphLvl == 19) { c_glovHP = 160; c_glovdp = 14; c_glovev = 7; c_glovhev = 8; c_glovdr = 7; c_glovhdr = 8; }
                    if (glovCaphLvl == 20) { c_glovHP = 160; c_glovdp = 16; c_glovev = 8; c_glovhev = 8; c_glovdr = 8; c_glovhdr = 8; }

                    cMaxHP += c_glovHP;
                    cdp += c_glovdp;
                    cev += c_glovev;
                    chev += c_glovhev;
                    cDR += c_glovdr;
                    cMaxMP += c_glovMP;
                    chdr += c_glovhdr;
                }
            }
            if (sgn == 10)
            {
                if (shEnchLvl == 18 | shEnchLvl == 19)
                {
                    cMaxHP -= c_shHP;
                    cdp -= c_shdp;
                    cev -= c_shev;
                    chev -= c_shhev;
                    cDR -= c_shdr;
                    cMaxMP -= c_shMP;
                    chdr -= c_shhdr;

                    if (shCaphLvl == 0) { c_shHP = 0; c_shdp = 0; c_shev = 0; c_shhev = 0; c_shdr = 0; c_shMP = 0; c_shhdr = 0; }
                    if (shCaphLvl == 1) { c_shHP = 10; }
                    if (shCaphLvl == 2) { c_shHP = 20; c_shdp = 1; c_shev = 1; c_shhev = 2; }
                    if (shCaphLvl == 3) { c_shHP = 30; c_shdp = 3; c_shev = 2; c_shhev = 3; c_shdr = 1; }
                    if (shCaphLvl == 4) { c_shHP = 50; c_shdp = 4; c_shev = 3; c_shhev = 4; c_shdr = 1; }
                    if (shCaphLvl == 5) { c_shHP = 50; c_shdp = 4; c_shev = 3; c_shhev = 4; c_shdr = 1; c_shMP = 5; }
                    if (shCaphLvl == 6) { c_shHP = 50; c_shdp = 4; c_shev = 3; c_shhev = 4; c_shdr = 1; c_shMP = 10; }
                    if (shCaphLvl == 7) { c_shHP = 50; c_shdp = 4; c_shev = 3; c_shhev = 5; c_shdr = 1; c_shMP = 10; }
                    if (shCaphLvl == 8) { c_shHP = 50; c_shdp = 4; c_shev = 3; c_shhev = 5; c_shdr = 1; c_shMP = 10; c_shhdr = 1; }
                    if (shCaphLvl == 9) { c_shHP = 60; c_shdp = 4; c_shev = 3; c_shhev = 5; c_shdr = 1; c_shMP = 10; c_shhdr = 1; }
                    if (shCaphLvl == 10) { c_shHP = 60; c_shdp = 4; c_shev = 3; c_shhev = 5; c_shdr = 1; c_shMP = 15; c_shhdr = 1; }
                    if (shCaphLvl == 11) { c_shHP = 60; c_shdp = 4; c_shev = 3; c_shhev = 5; c_shdr = 1; c_shMP = 20; c_shhdr = 1; }
                    if (shCaphLvl == 12) { c_shHP = 60; c_shdp = 4; c_shev = 3; c_shhev = 6; c_shdr = 1; c_shMP = 20; c_shhdr = 1; }
                    if (shCaphLvl == 13) { c_shHP = 70; c_shdp = 4; c_shev = 3; c_shhev = 6; c_shdr = 1; c_shMP = 20; c_shhdr = 1; }
                    if (shCaphLvl == 14) { c_shHP = 70; c_shdp = 4; c_shev = 3; c_shhev = 6; c_shdr = 1; c_shMP = 25; c_shhdr = 1; }
                    if (shCaphLvl == 15) { c_shHP = 70; c_shdp = 4; c_shev = 3; c_shhev = 6; c_shdr = 1; c_shMP = 30; c_shhdr = 1; }
                    if (shCaphLvl == 16) { c_shHP = 70; c_shdp = 4; c_shev = 3; c_shhev = 6; c_shdr = 1; c_shMP = 30; c_shhdr = 2; }
                    if (shCaphLvl == 17) { c_shHP = 70; c_shdp = 4; c_shev = 3; c_shhev = 7; c_shdr = 1; c_shMP = 30; c_shhdr = 2; }
                    if (shCaphLvl == 18) { c_shHP = 80; c_shdp = 4; c_shev = 3; c_shhev = 7; c_shdr = 1; c_shMP = 30; c_shhdr = 2; }
                    if (shCaphLvl == 19) { c_shHP = 80; c_shdp = 4; c_shev = 3; c_shhev = 8; c_shdr = 1; c_shMP = 30; c_shhdr = 2; }
                    if (shCaphLvl == 20) { c_shHP = 80; c_shdp = 4; c_shev = 3; c_shhev = 8; c_shdr = 1; c_shMP = 30; c_shhdr = 3; }

                    cMaxHP += c_shHP;
                    cdp += c_shdp;
                    cev += c_shev;
                    chev += c_shhev;
                    cDR += c_shdr;
                    cMaxMP += c_shMP;
                    chdr += c_shhdr;

                }
                if (shEnchLvl == 20)
                {
                    cMaxHP -= c_shHP;
                    cdp -= c_shdp;
                    cev -= c_shev;
                    chev -= c_shhev;
                    cDR -= c_shdr;
                    cMaxMP -= c_shMP;
                    chdr -= c_shhdr;

                    if (shCaphLvl == 0) { c_shHP = 0; c_shdp = 0; c_shev = 0; c_shhev = 0; c_shdr = 0; c_shMP = 0; c_shhdr = 0; }
                    if (shCaphLvl == 1) { c_shHP = 20; c_shdp = 1; c_shev = 1; c_shhev = 1; }
                    if (shCaphLvl == 2) { c_shHP = 30; c_shdp = 2; c_shev = 1; c_shhev = 1; c_shdr = 1; c_shhdr = 1; }
                    if (shCaphLvl == 3) { c_shHP = 40; c_shdp = 3; c_shev = 2; c_shhev = 2; c_shdr = 1; c_shhdr = 1; }
                    if (shCaphLvl == 4) { c_shHP = 50; c_shdp = 4; c_shev = 2; c_shhev = 2; c_shdr = 2; c_shhdr = 2; }
                    if (shCaphLvl == 5) { c_shHP = 60; c_shdp = 5; c_shev = 3; c_shhev = 3; c_shdr = 2; c_shhdr = 2; }
                    if (shCaphLvl == 6) { c_shHP = 70; c_shdp = 6; c_shev = 3; c_shhev = 3; c_shdr = 3; c_shhdr = 3; }
                    if (shCaphLvl == 7) { c_shHP = 80; c_shdp = 7; c_shev = 4; c_shhev = 4; c_shdr = 3; c_shhdr = 3; }
                    if (shCaphLvl == 8) { c_shHP = 90; c_shdp = 8; c_shev = 4; c_shhev = 4; c_shdr = 4; c_shhdr = 4; }
                    if (shCaphLvl == 9) { c_shHP = 100; c_shdp = 10; c_shev = 5; c_shhev = 5; c_shdr = 5; c_shhdr = 5; }
                    if (shCaphLvl == 10) { c_shHP = 110; c_shdp = 10; c_shev = 5; c_shhev = 6; c_shdr = 5; c_shhdr = 5; }
                    if (shCaphLvl == 11) { c_shHP = 120; c_shdp = 10; c_shev = 5; c_shhev = 6; c_shdr = 5; c_shhdr = 6; }
                    if (shCaphLvl == 12) { c_shHP = 120; c_shdp = 11; c_shev = 6; c_shhev = 6; c_shdr = 5; c_shhdr = 6; }
                    if (shCaphLvl == 13) { c_shHP = 120; c_shdp = 12; c_shev = 6; c_shhev = 6; c_shdr = 6; c_shhdr = 6; }
                    if (shCaphLvl == 14) { c_shHP = 130; c_shdp = 12; c_shev = 6; c_shhev = 7; c_shdr = 6; c_shhdr = 6; }
                    if (shCaphLvl == 15) { c_shHP = 140; c_shdp = 12; c_shev = 6; c_shhev = 7; c_shdr = 6; c_shhdr = 7; }
                    if (shCaphLvl == 16) { c_shHP = 140; c_shdp = 13; c_shev = 7; c_shhev = 7; c_shdr = 6; c_shhdr = 7; }
                    if (shCaphLvl == 17) { c_shHP = 140; c_shdp = 14; c_shev = 7; c_shhev = 7; c_shdr = 7; c_shhdr = 7; }
                    if (shCaphLvl == 18) { c_shHP = 150; c_shdp = 14; c_shev = 7; c_shhev = 8; c_shdr = 7; c_shhdr = 7; }
                    if (shCaphLvl == 19) { c_shHP = 160; c_shdp = 14; c_shev = 7; c_shhev = 8; c_shdr = 7; c_shhdr = 8; }
                    if (shCaphLvl == 20) { c_shHP = 160; c_shdp = 16; c_shev = 8; c_shhev = 8; c_shdr = 8; c_shhdr = 8; }

                    cMaxHP += c_shHP;
                    cdp += c_shdp;
                    cev += c_shev;
                    chev += c_shhev;
                    cDR += c_shdr;
                    cMaxMP += c_shMP;
                    chdr += c_shhdr;
                }
            }
        }
        public void AllWeaponCaphState()
        {
            if (sgn == 11) //AW
            {
                if (awkEnchLvl == 18 | awkEnchLvl == 19)
                {
                    caap -= c_awAAP;
                    cacc -= c_awAcc;

                    if (awkCaphLvl == 0) { c_awAAP = 0; c_awAcc = 0; }
                    if (awkCaphLvl == 1) { c_awAAP = 1; }
                    if (awkCaphLvl == 2) { c_awAAP = 2; }
                    if (awkCaphLvl == 3) { c_awAAP = 3; }
                    if (awkCaphLvl == 4) { c_awAAP = 4; }
                    if (awkCaphLvl == 5) { c_awAAP = 4; c_awAcc = 1; }
                    if (awkCaphLvl == 6) { c_awAAP = 4; c_awAcc = 2; }
                    if (awkCaphLvl == 7) { c_awAAP = 4; c_awAcc = 3; }
                    if (awkCaphLvl == 8) { c_awAAP = 5; c_awAcc = 3; }
                    if (awkCaphLvl == 9) { c_awAAP = 5; c_awAcc = 4; }
                    if (awkCaphLvl == 10) { c_awAAP = 5; c_awAcc = 5; }
                    if (awkCaphLvl == 11) { c_awAAP = 5; c_awAcc = 6; }
                    if (awkCaphLvl == 12) { c_awAAP = 6; c_awAcc = 6; }
                    if (awkCaphLvl == 13) { c_awAAP = 6; c_awAcc = 7; }
                    if (awkCaphLvl == 14) { c_awAAP = 6; c_awAcc = 8; }
                    if (awkCaphLvl == 15) { c_awAAP = 6; c_awAcc = 9; }
                    if (awkCaphLvl == 16) { c_awAAP = 7; c_awAcc = 9; }
                    if (awkCaphLvl == 17) { c_awAAP = 7; c_awAcc = 10; }
                    if (awkCaphLvl == 18) { c_awAAP = 7; c_awAcc = 11; }
                    if (awkCaphLvl == 19) { c_awAAP = 7; c_awAcc = 12; }
                    if (awkCaphLvl == 20) { c_awAAP = 8; c_awAcc = 12; }

                    caap += c_awAAP;
                    cacc += c_awAcc;
                }
                if (awkEnchLvl == 20)
                {
                    caap -= c_awAAP;
                    cacc -= c_awAcc;

                    if (awkCaphLvl == 0) { c_awAAP = 0; c_awAcc = 0; }
                    if (awkCaphLvl == 1) { c_awAAP = 1; }
                    if (awkCaphLvl == 2) { c_awAAP = 1; c_awAcc = 3; }
                    if (awkCaphLvl == 3) { c_awAAP = 2; c_awAcc = 3; }
                    if (awkCaphLvl == 4) { c_awAAP = 2; c_awAcc = 4; }
                    if (awkCaphLvl == 5) { c_awAAP = 3; c_awAcc = 4; }
                    if (awkCaphLvl == 6) { c_awAAP = 3; c_awAcc = 5; }
                    if (awkCaphLvl == 7) { c_awAAP = 4; c_awAcc = 5; }
                    if (awkCaphLvl == 8) { c_awAAP = 4; c_awAcc = 6; }
                    if (awkCaphLvl == 9) { c_awAAP = 5; c_awAcc = 6; }
                    if (awkCaphLvl == 10) { c_awAAP = 5; c_awAcc = 7; }
                    if (awkCaphLvl == 11) { c_awAAP = 6; c_awAcc = 7; }
                    if (awkCaphLvl == 12) { c_awAAP = 6; c_awAcc = 8; }
                    if (awkCaphLvl == 13) { c_awAAP = 7; c_awAcc = 8; }
                    if (awkCaphLvl == 14) { c_awAAP = 7; c_awAcc = 9; }
                    if (awkCaphLvl == 15) { c_awAAP = 8; c_awAcc = 9; }
                    if (awkCaphLvl == 16) { c_awAAP = 8; c_awAcc = 10; }
                    if (awkCaphLvl == 17) { c_awAAP = 9; c_awAcc = 10; }
                    if (awkCaphLvl == 18) { c_awAAP = 9; c_awAcc = 11; }
                    if (awkCaphLvl == 19) { c_awAAP = 10; c_awAcc = 11; }
                    if (awkCaphLvl == 20) { c_awAAP = 10; c_awAcc = 12; }

                    caap += c_awAAP;
                    cacc += c_awAcc;
                }
            }
            if (sgn == 12) //MW
            {
                if (mwEnchLvl == 18 | mwEnchLvl == 19)
                {
                    cap -= c_mwAP;
                    cacc -= c_mwAcc;

                    if (mwCaphLvl == 0) { c_mwAP = 0; c_mwAcc = 0; }
                    if (mwCaphLvl == 1) { c_mwAP = 1; }
                    if (mwCaphLvl == 2) { c_mwAP = 2; }
                    if (mwCaphLvl == 3) { c_mwAP = 3; }
                    if (mwCaphLvl == 4) { c_mwAP = 4; }
                    if (mwCaphLvl == 5) { c_mwAP = 4; c_mwAcc = 1; }
                    if (mwCaphLvl == 6) { c_mwAP = 4; c_mwAcc = 2; }
                    if (mwCaphLvl == 7) { c_mwAP = 4; c_mwAcc = 3; }
                    if (mwCaphLvl == 8) { c_mwAP = 5; c_mwAcc = 3; }
                    if (mwCaphLvl == 9) { c_mwAP = 5; c_mwAcc = 4; }
                    if (mwCaphLvl == 10) { c_mwAP = 5; c_mwAcc = 5; }
                    if (mwCaphLvl == 11) { c_mwAP = 5; c_mwAcc = 6; }
                    if (mwCaphLvl == 12) { c_mwAP = 6; c_mwAcc = 6; }
                    if (mwCaphLvl == 13) { c_mwAP = 6; c_mwAcc = 7; }
                    if (mwCaphLvl == 14) { c_mwAP = 6; c_mwAcc = 8; }
                    if (mwCaphLvl == 15) { c_mwAP = 6; c_mwAcc = 9; }
                    if (mwCaphLvl == 16) { c_mwAP = 7; c_mwAcc = 9; }
                    if (mwCaphLvl == 17) { c_mwAP = 7; c_mwAcc = 10; }
                    if (mwCaphLvl == 18) { c_mwAP = 7; c_mwAcc = 11; }
                    if (mwCaphLvl == 19) { c_mwAP = 7; c_mwAcc = 12; }
                    if (mwCaphLvl == 20) { c_mwAP = 8; c_mwAcc = 12; }

                    cap += c_mwAP;
                    cacc += c_mwAcc;
                }
                if (mwEnchLvl == 20)
                {
                    cap -= c_mwAP;
                    cacc -= c_mwAcc;

                    if (mwCaphLvl == 0) { c_mwAP = 0; c_mwAcc = 0; }
                    if (mwCaphLvl == 1) { c_mwAP = 1; }
                    if (mwCaphLvl == 2) { c_mwAP = 1; c_mwAcc = 3; }
                    if (mwCaphLvl == 3) { c_mwAP = 2; c_mwAcc = 3; }
                    if (mwCaphLvl == 4) { c_mwAP = 2; c_mwAcc = 4; }
                    if (mwCaphLvl == 5) { c_mwAP = 3; c_mwAcc = 4; }
                    if (mwCaphLvl == 6) { c_mwAP = 3; c_mwAcc = 5; }
                    if (mwCaphLvl == 7) { c_mwAP = 4; c_mwAcc = 5; }
                    if (mwCaphLvl == 8) { c_mwAP = 4; c_mwAcc = 6; }
                    if (mwCaphLvl == 9) { c_mwAP = 5; c_mwAcc = 6; }
                    if (mwCaphLvl == 10) { c_mwAP = 5; c_mwAcc = 7; }
                    if (mwCaphLvl == 11) { c_mwAP = 6; c_mwAcc = 7; }
                    if (mwCaphLvl == 12) { c_mwAP = 6; c_mwAcc = 8; }
                    if (mwCaphLvl == 13) { c_mwAP = 7; c_mwAcc = 8; }
                    if (mwCaphLvl == 14) { c_mwAP = 7; c_mwAcc = 9; }
                    if (mwCaphLvl == 15) { c_mwAP = 8; c_mwAcc = 9; }
                    if (mwCaphLvl == 16) { c_mwAP = 8; c_mwAcc = 10; }
                    if (mwCaphLvl == 17) { c_mwAP = 9; c_mwAcc = 10; }
                    if (mwCaphLvl == 18) { c_mwAP = 9; c_mwAcc = 11; }
                    if (mwCaphLvl == 19) { c_mwAP = 10; c_mwAcc = 11; }
                    if (mwCaphLvl == 20) { c_mwAP = 10; c_mwAcc = 12; }

                    cap += c_mwAP;
                    cacc += c_mwAcc;
                }
            }
            if (sgn == 13) //SW
            {
                if (swEnchLvl == 18 | swEnchLvl == 19)
                {
                    cap -= c_swAP;
                    caap -= c_swAAP;
                    cacc -= c_awAcc;
                    cMaxHP -= c_swHP;
                    cMaxMP -= c_swMP;
                    cdp -= c_swDP;
                    chdr -= c_swHDR;
                    cev -= c_swEva;
                    chev -= c_swHEva;

                    if (swCaphLvl == 0) { c_swAcc = 0; c_swHP = 0; c_swMP = 0; c_swDP = 0; c_swEva = 0; c_swHEva = 0; c_swHDR = 0; c_swAP = 0; c_swAAP = 0; }
                    if (swCaphLvl == 1) { c_swAcc = 4; }
                    if (swCaphLvl == 2) { c_swAcc = 4; c_swHP = 10; }
                    if (swCaphLvl == 3) { c_swAcc = 4; c_swHP = 10; c_swMP = 10; }
                    if (swCaphLvl == 4) { c_swAcc = 4; c_swHP = 10; c_swMP = 10; c_swDP = 1; c_swEva = 1; c_swHEva = 2; }
                    if (swCaphLvl == 5) { c_swAcc = 4; c_swHP = 10; c_swMP = 10; c_swDP = 1; c_swEva = 1; c_swHEva = 2; c_swHDR = 1; }
                    if (swCaphLvl == 6) { c_swAcc = 4; c_swHP = 20; c_swMP = 10; c_swDP = 1; c_swEva = 1; c_swHEva = 2; c_swHDR = 1; }
                    if (swCaphLvl == 7) { c_swAcc = 5; c_swHP = 20; c_swMP = 10; c_swDP = 1; c_swEva = 1; c_swHEva = 2; c_swHDR = 1; }
                    if (swCaphLvl == 8) { c_swAcc = 5; c_swHP = 20; c_swMP = 10; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; }
                    if (swCaphLvl == 9) { c_swAcc = 5; c_swHP = 20; c_swMP = 15; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; }
                    if (swCaphLvl == 10) { c_swAcc = 5; c_swHP = 20; c_swMP = 15; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 11) { c_swAcc = 6; c_swHP = 20; c_swMP = 15; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 12) { c_swAcc = 6; c_swHP = 30; c_swMP = 15; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 13) { c_swAcc = 6; c_swHP = 30; c_swMP = 20; c_swDP = 1; c_swEva = 1; c_swHEva = 3; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 14) { c_swAcc = 6; c_swHP = 30; c_swMP = 20; c_swDP = 1; c_swEva = 1; c_swHEva = 4; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 15) { c_swAcc = 7; c_swHP = 30; c_swMP = 20; c_swDP = 1; c_swEva = 1; c_swHEva = 4; c_swHDR = 1; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 16) { c_swAcc = 7; c_swHP = 30; c_swMP = 20; c_swDP = 1; c_swEva = 1; c_swHEva = 4; c_swHDR = 2; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 17) { c_swAcc = 7; c_swHP = 30; c_swMP = 25; c_swDP = 1; c_swEva = 1; c_swHEva = 4; c_swHDR = 2; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 18) { c_swAcc = 7; c_swHP = 30; c_swMP = 25; c_swDP = 1; c_swEva = 1; c_swHEva = 5; c_swHDR = 2; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 19) { c_swAcc = 8; c_swHP = 30; c_swMP = 25; c_swDP = 1; c_swEva = 1; c_swHEva = 5; c_swHDR = 2; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 20) { c_swAcc = 8; c_swHP = 30; c_swMP = 25; c_swDP = 1; c_swEva = 1; c_swHEva = 5; c_swHDR = 2; c_swAP = 2; c_swAAP = 2; }

                    cap += c_swAP;
                    caap += c_swAAP;
                    cacc += c_awAcc;
                    cMaxHP += c_swHP;
                    cMaxMP += c_swMP;
                    cdp += c_swDP;
                    chdr += c_swHDR;
                    cev += c_swEva;
                    chev += c_swHEva;
                }
                if (swEnchLvl == 20)
                {
                    cap -= c_swAP;
                    caap -= c_swAAP;
                    cacc -= c_awAcc;
                    cMaxHP -= c_swHP;
                    cDR -= c_swDR;
                    cdp -= c_swDP;
                    chdr -= c_swHDR;
                    cev -= c_swEva;
                    chev -= c_swHEva;

                    if (swCaphLvl == 0) { c_swAcc = 0; c_swHDR = 0; c_swDP = 0; c_swDR = 0; c_swHEva = 0; c_swEva = 0; c_swHP = 0; c_swAP = 0; c_swAAP = 0; }
                    if (swCaphLvl == 1) { c_swAcc = 4; }
                    if (swCaphLvl == 2) { c_swAcc = 4; c_swHDR = 1; }
                    if (swCaphLvl == 3) { c_swAcc = 4; c_swHDR = 1; c_swDP = 1; c_swDR = 1; }
                    if (swCaphLvl == 4) { c_swAcc = 4; c_swHDR = 1; c_swDP = 1; c_swDR = 1; c_swHEva = 3; }
                    if (swCaphLvl == 5) { c_swAcc = 4; c_swHDR = 1; c_swDP = 2; c_swDR = 1; c_swHEva = 3; c_swEva = 1; }
                    if (swCaphLvl == 6) { c_swAcc = 4; c_swHDR = 1; c_swDP = 2; c_swDR = 1; c_swHEva = 3; c_swEva = 1; c_swHP = 20; }
                    if (swCaphLvl == 7) { c_swAcc = 4; c_swHDR = 1; c_swDP = 2; c_swDR = 1; c_swHEva = 3; c_swEva = 1; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 8) { c_swAcc = 8; c_swHDR = 1; c_swDP = 2; c_swDR = 1; c_swHEva = 3; c_swEva = 1; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 9) { c_swAcc = 8; c_swHDR = 2; c_swDP = 2; c_swDR = 1; c_swHEva = 3; c_swEva = 1; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 10) { c_swAcc = 8; c_swHDR = 2; c_swDP = 3; c_swDR = 2; c_swHEva = 3; c_swEva = 1; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 11) { c_swAcc = 8; c_swHDR = 2; c_swDP = 3; c_swDR = 2; c_swHEva = 6; c_swEva = 1; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 12) { c_swAcc = 8; c_swHDR = 2; c_swDP = 4; c_swDR = 2; c_swHEva = 6; c_swEva = 2; c_swHP = 20; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 13) { c_swAcc = 8; c_swHDR = 2; c_swDP = 4; c_swDR = 2; c_swHEva = 6; c_swEva = 2; c_swHP = 40; c_swAP = 1; c_swAAP = 1; }
                    if (swCaphLvl == 14) { c_swAcc = 8; c_swHDR = 2; c_swDP = 4; c_swDR = 2; c_swHEva = 6; c_swEva = 2; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 15) { c_swAcc = 12; c_swHDR = 2; c_swDP = 4; c_swDR = 2; c_swHEva = 6; c_swEva = 2; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 16) { c_swAcc = 12; c_swHDR = 3; c_swDP = 4; c_swDR = 2; c_swHEva = 6; c_swEva = 2; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 17) { c_swAcc = 12; c_swHDR = 3; c_swDP = 5; c_swDR = 3; c_swHEva = 6; c_swEva = 2; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 18) { c_swAcc = 12; c_swHDR = 3; c_swDP = 5; c_swDR = 3; c_swHEva = 9; c_swEva = 2; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 19) { c_swAcc = 12; c_swHDR = 3; c_swDP = 6; c_swDR = 3; c_swHEva = 9; c_swEva = 3; c_swHP = 40; c_swAP = 2; c_swAAP = 2; }
                    if (swCaphLvl == 20) { c_swAcc = 12; c_swHDR = 3; c_swDP = 6; c_swDR = 3; c_swHEva = 9; c_swEva = 3; c_swHP = 60; c_swAP = 2; c_swAAP = 2; }

                    cap += c_swAP;
                    caap += c_swAAP;
                    cacc += c_awAcc;
                    cMaxHP += c_swHP;
                    cDR += c_swDR;
                    cdp += c_swDP;
                    chdr += c_swHDR;
                    cev += c_swEva;
                    chev += c_swHEva;
                }
            }
        }

        public void CrysMW1()
        {

            ccr -= wmcCrit;
                cCastSpeed -= wmcCastSpeed;
                cAtkSpeed -= wmcAtkSpeed;
                chap -= wmcHidenAP;
                cResistIgnore -= wmcIgnoreAll;
                cacc -= wmcAccuracy;
                cedh -= wmcDmgToHumans;

                cADtDemiH -= wmcDmgToDemi;
                cWeight -= wmcWeight;
                cRes1 -= wmcAllRes;
                cRes2 -= wmcAllRes;
                cRes3 -= wmcAllRes;
                cRes4 -= wmcAllRes;
                cMaxHP -= wmcMaxHP;
                cMaxST -= wmcMaxST;
                cDR -= wmcDR;
                cluck -= wmcLuck;
                cCombatExp -= wmcCombatEXP;
                cSkillExp -= wmcSkillEXP;

                wmcCrit = wmcDefCrit;
                wmcCastSpeed = wmcDefCastSpeed;
                wmcAtkSpeed = wmcDefAtkSpeed;
                wmcHidenAP = wmcDefHidenAP;
                wmcIgnoreAll = wmcDefIgnoreAll;
                wmcAccuracy = wmcDefAccuracy;
                wmcDmgToHumans = wmcDefDmgToHumans;

                wmcDmgToDemi = wmcDefDmgToDemi;
                wmcWeight = wmcDefWeight;
                wmcAllRes = wmcDefAllRes;
                wmcMaxHP = wmcDefMaxHP;
                wmcMaxST = wmcDefMaxST;
                wmcDR = wmcDefDR;
                wmcLuck = wmcDefLuck;
                wmcCombatEXP = wmcDefCombatEXP;
                wmcSkillEXP = wmcDefSkillEXP;

                ccr += wmcCrit;
                cCastSpeed += wmcCastSpeed;
                cAtkSpeed += wmcAtkSpeed;
                chap += wmcHidenAP;
                cResistIgnore += wmcIgnoreAll;
                cacc += wmcAccuracy;
                cedh += wmcDmgToHumans;

                cADtDemiH += wmcDmgToDemi;
                cWeight += wmcWeight;
                cRes1 += wmcAllRes;
                cRes2 += wmcAllRes;
                cRes3 += wmcAllRes;
                cRes4 += wmcAllRes;
                cMaxHP += wmcMaxHP;
                cMaxST += wmcMaxST;
                cDR += wmcDR;
                cluck += wmcLuck;
                cCombatExp += wmcCombatEXP;
                cSkillExp += wmcSkillEXP;

        }
        public void CrysMW1Clear()
        {
         wmcId = 0;
         wmcType = "Weapon";
         wmcDefCrit= 0;
         wmcDefCastSpeed= 0;
         wmcDefAtkSpeed= 0;
         wmcDefHidenAP= 0;
         wmcDefIgnoreAll= 0;
         wmcDefAccuracy= 0;
         wmcDefDmgToHumans= 0;
         wmcDefDmgToDemi= 0;
         wmcDefWeight= 0;
         wmcDefAllRes= 0;
         wmcDefMaxHP= 0;
         wmcDefMaxST= 0;
         wmcDefDR= 0;
         wmcDefLuck= 0;
         wmcDefCombatEXP= 0;
         wmcDefSkillEXP= 0;
    }

        public void CrysMW2()
        {

            ccr -= wmc2Crit;
            cCastSpeed -= wmc2CastSpeed;
            cAtkSpeed -= wmc2AtkSpeed;
            chap -= wmc2HidenAP;
            cResistIgnore -= wmc2IgnoreAll;
            cacc -= wmc2Accuracy;
            cedh -= wmc2DmgToHumans;

            cADtDemiH -= wmc2DmgToDemi;
            cWeight -= wmc2Weight;
            cRes1 -= wmc2AllRes;
            cRes2 -= wmc2AllRes;
            cRes3 -= wmc2AllRes;
            cRes4 -= wmc2AllRes;
            cMaxHP -= wmc2MaxHP;
            cMaxST -= wmc2MaxST;
            cDR -= wmc2DR;
            cluck -= wmc2Luck;
            cCombatExp -= wmc2CombatEXP;
            cSkillExp -= wmc2SkillEXP;

            wmc2Crit = wmc2DefCrit;
            wmc2CastSpeed = wmc2DefCastSpeed;
            wmc2AtkSpeed = wmc2DefAtkSpeed;
            wmc2HidenAP = wmc2DefHidenAP;
            wmc2IgnoreAll = wmc2DefIgnoreAll;
            wmc2Accuracy = wmc2DefAccuracy;
            wmc2DmgToHumans = wmc2DefDmgToHumans;

            wmc2DmgToDemi = wmc2DefDmgToDemi;
            wmc2Weight = wmc2DefWeight;
            wmc2AllRes = wmc2DefAllRes;
            wmc2MaxHP = wmc2DefMaxHP;
            wmc2MaxST = wmc2DefMaxST;
            wmc2DR = wmc2DefDR;
            wmc2Luck = wmc2DefLuck;
            wmc2CombatEXP = wmc2DefCombatEXP;
            wmc2SkillEXP = wmc2DefSkillEXP;

            ccr += wmc2Crit;
            cCastSpeed += wmc2CastSpeed;
            cAtkSpeed += wmc2AtkSpeed;
            chap += wmc2HidenAP;
            cResistIgnore += wmc2IgnoreAll;
            cacc += wmc2Accuracy;
            cedh += wmc2DmgToHumans;

            cADtDemiH += wmc2DmgToDemi;
            cWeight += wmc2Weight;
            cRes1 += wmc2AllRes;
            cRes2 += wmc2AllRes;
            cRes3 += wmc2AllRes;
            cRes4 += wmc2AllRes;
            cMaxHP += wmc2MaxHP;
            cMaxST += wmc2MaxST;
            cDR += wmc2DR;
            cluck += wmc2Luck;
            cCombatExp += wmc2CombatEXP;
            cSkillExp += wmc2SkillEXP;

        }
        public void CrysMW2Clear()
        {
            wmc2Id = 0;
            wmc2Type = "Weapon";
            wmc2DefCrit = 0;
            wmc2DefCastSpeed = 0;
            wmc2DefAtkSpeed = 0;
            wmc2DefHidenAP = 0;
            wmc2DefIgnoreAll = 0;
            wmc2DefAccuracy = 0;
            wmc2DefDmgToHumans = 0;
            wmc2DefDmgToDemi = 0;
            wmc2DefWeight = 0;
            wmc2DefAllRes = 0;
            wmc2DefMaxHP = 0;
            wmc2DefMaxST = 0;
            wmc2DefDR = 0;
            wmc2DefLuck = 0;
            wmc2DefCombatEXP = 0;
            wmc2DefSkillEXP = 0;
        }

        public void CrysSW1()
        {

            chap -= swmcHidenAP;
            cResistIgnore -= swmcIgnoreAll;
            cacc -= swmcAccuracy;
            cedh -= swmcDmgToHumans;
            cADtDemiH -= swmcDmgToDemi;
            cWeight -= swmcWeight;
            cRes1 -= swmcAllRes;
            cRes2 -= swmcAllRes;
            cRes3 -= swmcAllRes;
            cRes4 -= swmcAllRes;
            cMaxHP -= swmcMaxHP;
            cMaxST -= swmcMaxST;
            cDR -= swmcDR;
            cluck -= swmcLuck;
            cCombatExp -= swmcCombatEXP;
            cSkillExp -= swmcSkillEXP;

            cEDtoAir -= swmcAirDmg; 
            cEDtoCounter -=swmcCounterDmg;
            cEDtoDown -= swmcDownDmg;
            cGrapResistIgnore -= swmcGrapResIgnore; 
            cKBResistIgnore -= swmcKBResIgnore;
            cKDResistIgnore -= swmcKDResIgnore; 
            cStunResistIgnore -= swmcStunResIgnore; 
            cSpeedAtkDmg -= swmcSpeedAtkDmg;
            cCritHitDmg -= swmcCritDmg;


            swmcHidenAP = swmcDefHidenAP;
            swmcIgnoreAll = swmcDefIgnoreAll;
            swmcAccuracy = swmcDefAccuracy;
            swmcDmgToHumans = swmcDefDmgToHumans;
            swmcDmgToDemi = swmcDefDmgToDemi;
            swmcWeight = swmcDefWeight;
            swmcAllRes = swmcDefAllRes;
            swmcMaxHP = swmcDefMaxHP;
            swmcMaxST = swmcDefMaxST;
            swmcDR = swmcDefDR;
            swmcLuck = swmcDefLuck;
            swmcCombatEXP = swmcDefCombatEXP;
            swmcSkillEXP = swmcDefSkillEXP;

            swmcAirDmg = swmcDefAirDmg;
            swmcCounterDmg = swmcDefCounterDmg;
            swmcDownDmg = swmcDefDownDmg;
            swmcGrapResIgnore = swmcDefGrapResIgnore;
            swmcKBResIgnore = swmcDefKBResIgnore;
            swmcKDResIgnore = swmcDefKDResIgnore;
            swmcStunResIgnore = swmcDefStunResIgnore;
            swmcSpeedAtkDmg = swmcDefSpeedAtkDmg;
            swmcCritDmg = swmcDefCritDmg;

            chap += swmcHidenAP;
            cResistIgnore += swmcIgnoreAll;
            cacc += swmcAccuracy;
            cedh += swmcDmgToHumans;
            cADtDemiH += swmcDmgToDemi;
            cWeight += swmcWeight;
            cRes1 += swmcAllRes;
            cRes2 += swmcAllRes;
            cRes3 += swmcAllRes;
            cRes4 += swmcAllRes;
            cMaxHP += swmcMaxHP;
            cMaxST += swmcMaxST;
            cDR += swmcDR;
            cluck += swmcLuck;
            cCombatExp += swmcCombatEXP;
            cSkillExp += swmcSkillEXP;

            cEDtoAir += swmcAirDmg;
            cEDtoCounter += swmcCounterDmg;
            cEDtoDown += swmcDownDmg;
            cGrapResistIgnore += swmcGrapResIgnore;
            cKBResistIgnore += swmcKBResIgnore;
            cKDResistIgnore += swmcKDResIgnore;
            cStunResistIgnore += swmcStunResIgnore;
            cSpeedAtkDmg += swmcSpeedAtkDmg;
            cCritHitDmg += swmcCritDmg;


        }
        public void CrysSW1Clear()
        {
             swmcId = 0;
        swmcType = "Sub-Weapon";
         swmcDefHidenAP= 0;
         swmcDefIgnoreAll= 0;
         swmcDefAccuracy= 0;
         swmcDefDmgToHumans= 0;
         swmcDefDmgToDemi= 0;
         swmcDefWeight= 0;
         swmcDefAllRes= 0;
         swmcDefMaxHP= 0;
         swmcDefMaxST= 0;
         swmcDefDR= 0;
         swmcDefLuck= 0;
         swmcDefCombatEXP= 0;
         swmcDefSkillEXP= 0;
         swmcDefCritDmg= 0;
         swmcDefAirDmg= 0;
         swmcDefBackDmg= 0;
         swmcDefCounterDmg= 0;
         swmcDefSpeedAtkDmg= 0;
         swmcDefDownDmg= 0;
         swmcDefGrapResIgnore= 0;
         swmcDefKBResIgnore= 0;
         swmcDefKDResIgnore= 0;
         swmcDefStunResIgnore= 0;
         swmcDefDmgToKama= 0;
    }

        public void CrysSW2()
        {

            chap -= swmc2HidenAP;
            cResistIgnore -= swmc2IgnoreAll;
            cacc -= swmc2Accuracy;
            cedh -= swmc2DmgToHumans;
            cADtDemiH -= swmc2DmgToDemi;
            cWeight -= swmc2Weight;
            cRes1 -= swmc2AllRes;
            cRes2 -= swmc2AllRes;
            cRes3 -= swmc2AllRes;
            cRes4 -= swmc2AllRes;
            cMaxHP -= swmc2MaxHP;
            cMaxST -= swmc2MaxST;
            cDR -= swmc2DR;
            cluck -= swmc2Luck;
            cCombatExp -= swmc2CombatEXP;
            cSkillExp -= swmc2SkillEXP;

            cEDtoAir -= swmc2AirDmg;
            cEDtoCounter -= swmc2CounterDmg;
            cEDtoDown -= swmc2DownDmg;
            cGrapResistIgnore -= swmc2GrapResIgnore;
            cKBResistIgnore -= swmc2KBResIgnore;
            cKDResistIgnore -= swmc2KDResIgnore;
            cStunResistIgnore -= swmc2StunResIgnore;
            cSpeedAtkDmg -= swmc2SpeedAtkDmg;
            cCritHitDmg -= swmc2CritDmg;


            swmc2HidenAP = swmc2DefHidenAP;
            swmc2IgnoreAll = swmc2DefIgnoreAll;
            swmc2Accuracy = swmc2DefAccuracy;
            swmc2DmgToHumans = swmc2DefDmgToHumans;
            swmc2DmgToDemi = swmc2DefDmgToDemi;
            swmc2Weight = swmc2DefWeight;
            swmc2AllRes = swmc2DefAllRes;
            swmc2MaxHP = swmc2DefMaxHP;
            swmc2MaxST = swmc2DefMaxST;
            swmc2DR = swmc2DefDR;
            swmc2Luck = swmc2DefLuck;
            swmc2CombatEXP = swmc2DefCombatEXP;
            swmc2SkillEXP = swmc2DefSkillEXP;

            swmc2AirDmg = swmc2DefAirDmg;
            swmc2CounterDmg = swmc2DefCounterDmg;
            swmc2DownDmg = swmc2DefDownDmg;
            swmc2GrapResIgnore = swmc2DefGrapResIgnore;
            swmc2KBResIgnore = swmc2DefKBResIgnore;
            swmc2KDResIgnore = swmc2DefKDResIgnore;
            swmc2StunResIgnore = swmc2DefStunResIgnore;
            swmc2SpeedAtkDmg = swmc2DefSpeedAtkDmg;
            swmc2CritDmg = swmc2DefCritDmg;

            chap += swmc2HidenAP;
            cResistIgnore += swmc2IgnoreAll;
            cacc += swmc2Accuracy;
            cedh += swmc2DmgToHumans;
            cADtDemiH += swmc2DmgToDemi;
            cWeight += swmc2Weight;
            cRes1 += swmc2AllRes;
            cRes2 += swmc2AllRes;
            cRes3 += swmc2AllRes;
            cRes4 += swmc2AllRes;
            cMaxHP += swmc2MaxHP;
            cMaxST += swmc2MaxST;
            cDR += swmc2DR;
            cluck += swmc2Luck;
            cCombatExp += swmc2CombatEXP;
            cSkillExp += swmc2SkillEXP;

            cEDtoAir += swmc2AirDmg;
            cEDtoCounter += swmc2CounterDmg;
            cEDtoDown += swmc2DownDmg;
            cGrapResistIgnore += swmc2GrapResIgnore;
            cKBResistIgnore += swmc2KBResIgnore;
            cKDResistIgnore += swmc2KDResIgnore;
            cStunResistIgnore += swmc2StunResIgnore;
            cSpeedAtkDmg += swmc2SpeedAtkDmg;
            cCritHitDmg += swmc2CritDmg;


        }
        public void CrysSW2Clear()
        {
            swmc2Id = 0;
            swmc2Type = "Sub-Weapon";
            swmc2DefHidenAP = 0;
            swmc2DefIgnoreAll = 0;
            swmc2DefAccuracy = 0;
            swmc2DefDmgToHumans = 0;
            swmc2DefDmgToDemi = 0;
            swmc2DefWeight = 0;
            swmc2DefAllRes = 0;
            swmc2DefMaxHP = 0;
            swmc2DefMaxST = 0;
            swmc2DefDR = 0;
            swmc2DefLuck = 0;
            swmc2DefCombatEXP = 0;
            swmc2DefSkillEXP = 0;
            swmc2DefCritDmg = 0;
            swmc2DefAirDmg = 0;
            swmc2DefBackDmg = 0;
            swmc2DefCounterDmg = 0;
            swmc2DefSpeedAtkDmg = 0;
            swmc2DefDownDmg = 0;
            swmc2DefGrapResIgnore = 0;
            swmc2DefKBResIgnore = 0;
            swmc2DefKDResIgnore = 0;
            swmc2DefStunResIgnore = 0;
            swmc2DefDmgToKama = 0;
        }

        public void CrysH1()
        {

            cResistIgnore -= hmcIgnoreAll;
            cacc -= hmcAccuracy;
            cedh -= hmcDmgToHumans;
            cADtDemiH -= hmcDmgToDemi;
            cWeight -= hmcWeight;
            cRes1 -= hmcAllRes;
            cRes2 -= hmcAllRes;
            cRes3 -= hmcAllRes;
            cRes4 -= hmcAllRes;
            cMaxHP -= hmcMaxHP;
            cMaxST -= hmcMaxST;
            cDR -= hmcDR;
            cluck -= hmcLuck;
            cCombatExp -= hmcCombatEXP;
            cSkillExp -= hmcSkillEXP;

            chpr -= hmcHPRecovery;
            cev -= hmcEV;
            cCastSpeed -= hmcCastSpeed;
            cVisionRange -= hmcVisionRange;
            cRes1 -= hmcSSFRes;
            cRes2 -= hmcKBRes;





            hmcIgnoreAll = hmcDefIgnoreAll;
            hmcAccuracy = hmcDefAccuracy;
            hmcDmgToHumans = hmcDefDmgToHumans;
            hmcDmgToDemi = hmcDefDmgToDemi;
            hmcWeight = hmcDefWeight;
            hmcAllRes = hmcDefAllRes;
            hmcMaxHP = hmcDefMaxHP;
            hmcMaxST = hmcDefMaxST;
            hmcDR = hmcDefDR;
            hmcLuck = hmcDefLuck;
            hmcCombatEXP = hmcDefCombatEXP;
            hmcSkillEXP = hmcDefSkillEXP;

            hmcHPRecovery = hmcDefHPRecovery;
            hmcEV = hmcDefEV;
            hmcKBRes = hmcDefKBRes;
            hmcSSFRes = hmcDefSSFRes;
            hmcVisionRange = hmcDefVisionRange;
            hmcCastSpeed = hmcDefCastSpeed;



            cResistIgnore += hmcIgnoreAll;
            cacc += hmcAccuracy;
            cedh += hmcDmgToHumans;
            cADtDemiH += hmcDmgToDemi;
            cWeight += hmcWeight;
            cRes1 += hmcAllRes;
            cRes2 += hmcAllRes;
            cRes3 += hmcAllRes;
            cRes4 += hmcAllRes;
            cMaxHP += hmcMaxHP;
            cMaxST += hmcMaxST;
            cDR += hmcDR;
            cluck += hmcLuck;
            cCombatExp += hmcCombatEXP;
            cSkillExp += hmcSkillEXP;

            chpr += hmcHPRecovery;
            cev += hmcEV;
            cCastSpeed += hmcCastSpeed;
            cVisionRange += hmcVisionRange;
            cRes1 += hmcSSFRes;
            cRes2 += hmcKBRes;



        }
        public void CrysH1Clear()
        {

         hmcId = 0;
         hmcType = "Helmet";
         hmcDefIgnoreAll= 0 ;
         hmcDefAccuracy= 0 ;
         hmcDefDmgToHumans= 0 ;
         hmcDefDmgToDemi= 0 ;
         hmcDefWeight= 0 ;
         hmcDefAllRes= 0 ;
         hmcDefMaxHP= 0 ;
         hmcDefMaxST= 0 ;
         hmcDefDR= 0 ;
         hmcDefLuck= 0 ;
         hmcDefCombatEXP= 0 ;
         hmcDefSkillEXP= 0 ;
         hmcDefHPRecovery= 0 ;
         hmcDefEV= 0 ;
         hmcDefKBRes= 0 ;
         hmcDefSSFRes= 0 ;
         hmcDefCastSpeed= 0 ;
         hmcDefVisionRange= 0 ;

    }

        public void CrysH2()
        {

            cResistIgnore -= hmc2IgnoreAll;
            cacc -= hmc2Accuracy;
            cedh -= hmc2DmgToHumans;
            cADtDemiH -= hmc2DmgToDemi;
            cWeight -= hmc2Weight;
            cRes1 -= hmc2AllRes;
            cRes2 -= hmc2AllRes;
            cRes3 -= hmc2AllRes;
            cRes4 -= hmc2AllRes;
            cMaxHP -= hmc2MaxHP;
            cMaxST -= hmc2MaxST;
            cDR -= hmc2DR;
            cluck -= hmc2Luck;
            cCombatExp -= hmc2CombatEXP;
            cSkillExp -= hmc2SkillEXP;

            chpr -= hmc2HPRecovery;
            cev -= hmc2EV;
            cCastSpeed -= hmc2CastSpeed;
            cVisionRange -= hmc2VisionRange;
            cRes1 -= hmc2SSFRes;
            cRes2 -= hmc2KBRes;





            hmc2IgnoreAll = hmc2DefIgnoreAll;
            hmc2Accuracy = hmc2DefAccuracy;
            hmc2DmgToHumans = hmc2DefDmgToHumans;
            hmc2DmgToDemi = hmc2DefDmgToDemi;
            hmc2Weight = hmc2DefWeight;
            hmc2AllRes = hmc2DefAllRes;
            hmc2MaxHP = hmc2DefMaxHP;
            hmc2MaxST = hmc2DefMaxST;
            hmc2DR = hmc2DefDR;
            hmc2Luck = hmc2DefLuck;
            hmc2CombatEXP = hmc2DefCombatEXP;
            hmc2SkillEXP = hmc2DefSkillEXP;

            hmc2HPRecovery = hmc2DefHPRecovery;
            hmc2EV = hmc2DefEV;
            hmc2KBRes = hmc2DefKBRes;
            hmc2SSFRes = hmc2DefSSFRes;
            hmc2VisionRange = hmc2DefVisionRange;
            hmc2CastSpeed = hmc2DefCastSpeed;



            cResistIgnore += hmc2IgnoreAll;
            cacc += hmc2Accuracy;
            cedh += hmc2DmgToHumans;
            cADtDemiH += hmc2DmgToDemi;
            cWeight += hmc2Weight;
            cRes1 += hmc2AllRes;
            cRes2 += hmc2AllRes;
            cRes3 += hmc2AllRes;
            cRes4 += hmc2AllRes;
            cMaxHP += hmc2MaxHP;
            cMaxST += hmc2MaxST;
            cDR += hmc2DR;
            cluck += hmc2Luck;
            cCombatExp += hmc2CombatEXP;
            cSkillExp += hmc2SkillEXP;

            chpr += hmc2HPRecovery;
            cev += hmc2EV;
            cCastSpeed += hmc2CastSpeed;
            cVisionRange += hmc2VisionRange;
            cRes1 += hmc2SSFRes;
            cRes2 += hmc2KBRes;



        }
        public void CrysH2Clear()
        {

            hmc2Id = 0;
            hmc2Type = "Helmet";
            hmc2DefIgnoreAll = 0;
            hmc2DefAccuracy = 0;
            hmc2DefDmgToHumans = 0;
            hmc2DefDmgToDemi = 0;
            hmc2DefWeight = 0;
            hmc2DefAllRes = 0;
            hmc2DefMaxHP = 0;
            hmc2DefMaxST = 0;
            hmc2DefDR = 0;
            hmc2DefLuck = 0;
            hmc2DefCombatEXP = 0;
            hmc2DefSkillEXP = 0;
            hmc2DefHPRecovery = 0;
            hmc2DefEV = 0;
            hmc2DefKBRes = 0;
            hmc2DefSSFRes = 0;
            hmc2DefCastSpeed = 0;
            hmc2DefVisionRange = 0;

        }

        public void CrysA1()
        {

            cResistIgnore -= amcIgnoreAll;
            cacc -= amcAccuracy;
            cedh -= amcDmgToHumans;
            cADtDemiH -= amcDmgToDemi;
            cWeight -= amcWeight;
            cRes1 -= amcAllRes;
            cRes2 -= amcAllRes;
            cRes3 -= amcAllRes;
            cRes4 -= amcAllRes;
            cMaxHP -= amcMaxHP;
            cMaxST -= amcMaxST;
            cDR -= amcDR;
            cluck -= amcLuck;
            cCombatExp -= amcCombatEXP;
            cSkillExp -= amcSkillEXP;
            chpr -= amcHPRecovery;

            cMaxMP -= amcMaxMP;
            cRes1 -= amcSSFRes;
            cSpecialAttackEv -= amcSpecialAtkEvRate;
            cMagicDR -= amcMagicDR;
            cMeleeDR -= amcMelleDR;
            cRangeDR -= amcRangeDR;
            cSiegeWeaponEvRate -= amcSiegeWeaponEvRate;
            cmpr -= amcMPRecovery;




            amcIgnoreAll = amcDefIgnoreAll;
            amcAccuracy = amcDefAccuracy;
            amcDmgToHumans = amcDefDmgToHumans;
            amcDmgToDemi = amcDefDmgToDemi;
            amcWeight = amcDefWeight;
            amcAllRes = amcDefAllRes;
            amcMaxHP = amcDefMaxHP;
            amcMaxST = amcDefMaxST;
            amcDR = amcDefDR;
            amcLuck = amcDefLuck;
            amcCombatEXP = amcDefCombatEXP;
            amcSkillEXP = amcDefSkillEXP;
            amcHPRecovery = amcDefHPRecovery;
            amcSSFRes = amcDefSSFRes;

            amcMaxMP = amcDefMaxMP;
            amcSSFRes = amcDefSSFRes;
            amcSpecialAtkEvRate = amcDefSpecialAtkEvRate;
            amcMagicDR = amcDefMagicDR;
            amcMelleDR = amcDefMelleDR;
            amcRangeDR = amcDefRangeDR;
            amcSiegeWeaponEvRate = amcDefSiegeWeaponEvRate;
            amcMPRecovery = amcDefMPRecovery;

            cResistIgnore += amcIgnoreAll;
            cacc += amcAccuracy;
            cedh += amcDmgToHumans;
            cADtDemiH += amcDmgToDemi;
            cWeight += amcWeight;
            cRes1 += amcAllRes;
            cRes2 += amcAllRes;
            cRes3 += amcAllRes;
            cRes4 += amcAllRes;
            cMaxHP += amcMaxHP;
            cMaxST += amcMaxST;
            cDR += amcDR;
            cluck += amcLuck;
            cCombatExp += amcCombatEXP;
            cSkillExp += amcSkillEXP;
            chpr += amcHPRecovery;
            cRes1 += amcSSFRes;
            cMaxMP += amcMaxMP;
            cSpecialAttackEv += amcSpecialAtkEvRate;
            cMagicDR += amcMagicDR;
            cMeleeDR += amcMelleDR;
            cRangeDR += amcRangeDR;
            cSiegeWeaponEvRate += amcSiegeWeaponEvRate;
            cmpr += amcMPRecovery;

        }
        public void CrysA1Clear()
        {
            amcId = 0;
            amcType = "Armor";
            amcDefIgnoreAll = 0;
            amcDefAccuracy = 0;
            amcDefDmgToHumans = 0;
            amcDefDmgToDemi = 0;
            amcDefWeight = 0;
            amcDefAllRes = 0;
            amcDefMaxHP = 0;
            amcDefMaxST = 0;
            amcDefDR = 0;
            amcDefLuck = 0;
            amcDefCombatEXP = 0;
            amcDefSkillEXP = 0;

            amcDefMaxMP = 0;
            amcDefHPRecovery = 0;
            amcDefMPRecovery = 0;
            amcDefSSFRes = 0;
            amcDefSpecialAtkEvRate = 0;
            amcDefMagicDR = 0;
            amcDefMelleDR = 0;
            amcDefRangeDR = 0;
            amcDefSiegeWeaponEvRate = 0;
        }

        public void CrysA2()
        {

            cResistIgnore -= amc2IgnoreAll;
            cacc -= amc2Accuracy;
            cedh -= amc2DmgToHumans;
            cADtDemiH -= amc2DmgToDemi;
            cWeight -= amc2Weight;
            cRes1 -= amc2AllRes;
            cRes2 -= amc2AllRes;
            cRes3 -= amc2AllRes;
            cRes4 -= amc2AllRes;
            cMaxHP -= amc2MaxHP;
            cMaxST -= amc2MaxST;
            cDR -= amc2DR;
            cluck -= amc2Luck;
            cCombatExp -= amc2CombatEXP;
            cSkillExp -= amc2SkillEXP;
            chpr -= amc2HPRecovery;

            cMaxMP -= amc2MaxMP;
            cRes1 -= amc2SSFRes;
            cSpecialAttackEv -= amc2SpecialAtkEvRate;
            cMagicDR -= amc2MagicDR;
            cMeleeDR -= amc2MelleDR;
            cRangeDR -= amc2RangeDR;
            cSiegeWeaponEvRate -= amc2SiegeWeaponEvRate;
            cmpr -= amc2MPRecovery;




            amc2IgnoreAll = amc2DefIgnoreAll;
            amc2Accuracy = amc2DefAccuracy;
            amc2DmgToHumans = amc2DefDmgToHumans;
            amc2DmgToDemi = amc2DefDmgToDemi;
            amc2Weight = amc2DefWeight;
            amc2AllRes = amc2DefAllRes;
            amc2MaxHP = amc2DefMaxHP;
            amc2MaxST = amc2DefMaxST;
            amc2DR = amc2DefDR;
            amc2Luck = amc2DefLuck;
            amc2CombatEXP = amc2DefCombatEXP;
            amc2SkillEXP = amc2DefSkillEXP;
            amc2HPRecovery = amc2DefHPRecovery;
            amc2SSFRes = amc2DefSSFRes;

            amc2MaxMP = amc2DefMaxMP;
            amc2SSFRes = amc2DefSSFRes;
            amc2SpecialAtkEvRate = amc2DefSpecialAtkEvRate;
            amc2MagicDR = amc2DefMagicDR;
            amc2MelleDR = amc2DefMelleDR;
            amc2RangeDR = amc2DefRangeDR;
            amc2SiegeWeaponEvRate = amc2DefSiegeWeaponEvRate;
            amc2MPRecovery = amc2DefMPRecovery;

            cResistIgnore += amc2IgnoreAll;
            cacc += amc2Accuracy;
            cedh += amc2DmgToHumans;
            cADtDemiH += amc2DmgToDemi;
            cWeight += amc2Weight;
            cRes1 += amc2AllRes;
            cRes2 += amc2AllRes;
            cRes3 += amc2AllRes;
            cRes4 += amc2AllRes;
            cMaxHP += amc2MaxHP;
            cMaxST += amc2MaxST;
            cDR += amc2DR;
            cluck += amc2Luck;
            cCombatExp += amc2CombatEXP;
            cSkillExp += amc2SkillEXP;
            chpr += amc2HPRecovery;
            cRes1 += amc2SSFRes;
            cMaxMP += amc2MaxMP;
            cSpecialAttackEv += amc2SpecialAtkEvRate;
            cMagicDR += amc2MagicDR;
            cMeleeDR += amc2MelleDR;
            cRangeDR += amc2RangeDR;
            cSiegeWeaponEvRate += amc2SiegeWeaponEvRate;
            cmpr += amc2MPRecovery;

        }
        public void CrysA2Clear()
        {
            amc2Id = 0;
            amc2Type = "Armor";
            amc2DefIgnoreAll = 0;
            amc2DefAccuracy = 0;
            amc2DefDmgToHumans = 0;
            amc2DefDmgToDemi = 0;
            amc2DefWeight = 0;
            amc2DefAllRes = 0;
            amc2DefMaxHP = 0;
            amc2DefMaxST = 0;
            amc2DefDR = 0;
            amc2DefLuck = 0;
            amc2DefCombatEXP = 0;
            amc2DefSkillEXP = 0;

            amc2DefMaxMP = 0;
            amc2DefHPRecovery = 0;
            amc2DefMPRecovery = 0;
            amc2DefSSFRes = 0;
            amc2DefSpecialAtkEvRate = 0;
            amc2DefMagicDR = 0;
            amc2DefMelleDR = 0;
            amc2DefRangeDR = 0;
            amc2DefSiegeWeaponEvRate = 0;
        }

        public void CrysG1()
        {

            cResistIgnore -= gmcIgnoreAll;
            cacc -= gmcAccuracy;
            cedh -= gmcDmgToHumans;
            cADtDemiH -= gmcDmgToDemi;
            cWeight -= gmcWeight;
            cRes1 -= gmcAllRes;
            cRes2 -= gmcAllRes;
            cRes3 -= gmcAllRes;
            cRes4 -= gmcAllRes;
            cMaxHP -= gmcMaxHP;
            cMaxST -= gmcMaxST;
            cDR -= gmcDR;
            cluck -= gmcLuck;
            cCombatExp -= gmcCombatEXP;
            cSkillExp -= gmcSkillEXP;

            cAtkSpeed -= gmcAtkSpeed;
            cCastSpeed -= gmcCastSpeed;
            ccr -= gmcCrit;
            cRes3 -= gmcGrapRes;
            cRes4 -= gmcKFRes;
            cMagicAP -= gmcMagicAP;
            cMelleAP -= gmcMelleAP;
            cRangeAP -= gmcRangedAP;
            chap -= gmcHidenAP;





            gmcAccuracy = gmcDefAccuracy;
            gmcDmgToHumans = gmcDefDmgToHumans;
            gmcDmgToDemi = gmcDefDmgToDemi;
            gmcWeight = gmcDefWeight;
            gmcAllRes = gmcDefAllRes;
            gmcMaxHP = gmcDefMaxHP;
            gmcMaxST = gmcDefMaxST;
            gmcDR = gmcDefDR;
            gmcLuck = gmcDefLuck;
            gmcCombatEXP = gmcDefCombatEXP;
            gmcSkillEXP = gmcDefSkillEXP;
            gmcIgnoreAll = gmcDefIgnoreAll;


            gmcAtkSpeed = gmcDefAtkSpeed;
            gmcCastSpeed = gmcDefCastSpeed;
            gmcCrit = gmcDefCrit;
            gmcGrapRes = gmcDefGrapRes;
            gmcKFRes = gmcDefKFRes;
            gmcMagicAP = gmcDefMagicAP;
            gmcMelleAP = gmcDefMelleAP;
            gmcRangedAP = gmcDefRangedAP;
            gmcHidenAP = gmcDefHidenAP;

            cResistIgnore += gmcIgnoreAll;
            cacc += gmcAccuracy;
            cedh += gmcDmgToHumans;
            cADtDemiH += gmcDmgToDemi;
            cWeight += gmcWeight;
            cRes1 += gmcAllRes;
            cRes2 += gmcAllRes;
            cRes3 += gmcAllRes;
            cRes4 += gmcAllRes;
            cMaxHP += gmcMaxHP;
            cMaxST += gmcMaxST;
            cDR += gmcDR;
            cluck += gmcLuck;
            cCombatExp += gmcCombatEXP;
            cSkillExp += gmcSkillEXP;

            cAtkSpeed += gmcAtkSpeed;
            cCastSpeed += gmcCastSpeed;
            ccr += gmcCrit;
            cRes3 += gmcGrapRes;
            cRes4 += gmcKFRes;
            cMagicAP += gmcMagicAP;
            cMelleAP += gmcMelleAP;
            cRangeAP += gmcRangedAP;
            chap += gmcHidenAP;
        }
        public void CrysG1Clear()
        {
             gmcId = 0;
        gmcType = "Gloves";
         gmcDefIgnoreAll= 0;
         gmcDefAccuracy= 0;
         gmcDefDmgToHumans= 0;
         gmcDefDmgToDemi= 0;
         gmcDefWeight= 0;
         gmcDefAllRes= 0;
         gmcDefMaxHP= 0;
         gmcDefMaxST= 0;
         gmcDefDR= 0;
         gmcDefLuck= 0;
         gmcDefCombatEXP= 0;
         gmcDefSkillEXP= 0;

         gmcDefAtkSpeed= 0;
         gmcDefCastSpeed= 0;
         gmcDefCrit= 0;
         gmcDefGrapRes= 0;
         gmcDefKFRes= 0;
         gmcDefHidenAP= 0;
         gmcDefMagicAP= 0;
         gmcDefMelleAP= 0;
         gmcDefRangedAP= 0;
    }

        public void CrysG2()
        {

            cResistIgnore -= gmc2IgnoreAll;
            cacc -= gmc2Accuracy;
            cedh -= gmc2DmgToHumans;
            cADtDemiH -= gmc2DmgToDemi;
            cWeight -= gmc2Weight;
            cRes1 -= gmc2AllRes;
            cRes2 -= gmc2AllRes;
            cRes3 -= gmc2AllRes;
            cRes4 -= gmc2AllRes;
            cMaxHP -= gmc2MaxHP;
            cMaxST -= gmc2MaxST;
            cDR -= gmc2DR;
            cluck -= gmc2Luck;
            cCombatExp -= gmc2CombatEXP;
            cSkillExp -= gmc2SkillEXP;

            cAtkSpeed -= gmc2AtkSpeed;
            cCastSpeed -= gmc2CastSpeed;
            ccr -= gmc2Crit;
            cRes3 -= gmc2GrapRes;
            cRes4 -= gmc2KFRes;
            chap -= gmc2HidenAP;
            cMagicAP -= gmc2MagicAP;
            cMelleAP -= gmc2MelleAP;
            cRangeAP -= gmc2RangedAP;





            gmc2Accuracy = gmc2DefAccuracy;
            gmc2DmgToHumans = gmc2DefDmgToHumans;
            gmc2DmgToDemi = gmc2DefDmgToDemi;
            gmc2Weight = gmc2DefWeight;
            gmc2AllRes = gmc2DefAllRes;
            gmc2MaxHP = gmc2DefMaxHP;
            gmc2MaxST = gmc2DefMaxST;
            gmc2DR = gmc2DefDR;
            gmc2Luck = gmc2DefLuck;
            gmc2CombatEXP = gmc2DefCombatEXP;
            gmc2SkillEXP = gmc2DefSkillEXP;
            gmc2IgnoreAll = gmc2DefIgnoreAll;


            gmc2AtkSpeed = gmc2DefAtkSpeed;
            gmc2CastSpeed = gmc2DefCastSpeed;
            gmc2Crit = gmc2DefCrit;
            gmc2GrapRes = gmc2DefGrapRes;
            gmc2KFRes = gmc2DefKFRes;
            gmc2MagicAP = gmc2DefMagicAP;
            gmc2MelleAP = gmc2DefMelleAP;
            gmc2RangedAP = gmc2DefRangedAP;
            gmc2HidenAP = gmc2DefHidenAP;


            cResistIgnore += gmc2IgnoreAll;
            cacc += gmc2Accuracy;
            cedh += gmc2DmgToHumans;
            cADtDemiH += gmc2DmgToDemi;
            cWeight += gmc2Weight;
            cRes1 += gmc2AllRes;
            cRes2 += gmc2AllRes;
            cRes3 += gmc2AllRes;
            cRes4 += gmc2AllRes;
            cMaxHP += gmc2MaxHP;
            cMaxST += gmc2MaxST;
            cDR += gmc2DR;
            cluck += gmc2Luck;
            cCombatExp += gmc2CombatEXP;
            cSkillExp += gmc2SkillEXP;

            cAtkSpeed += gmc2AtkSpeed;
            cCastSpeed += gmc2CastSpeed;
            ccr += gmc2Crit;
            cRes3 += gmc2GrapRes;
            cRes4 += gmc2KFRes;
            cMagicAP += gmc2MagicAP;
            cMelleAP += gmc2MelleAP;
            cRangeAP += gmc2RangedAP;
            chap += gmc2HidenAP;
        }
        public void CrysG2Clear()
        {
            gmc2Id = 0;
            gmc2Type = "Gloves";
            gmc2DefIgnoreAll = 0;
            gmc2DefAccuracy = 0;
            gmc2DefDmgToHumans = 0;
            gmc2DefDmgToDemi = 0;
            gmc2DefWeight = 0;
            gmc2DefAllRes = 0;
            gmc2DefMaxHP = 0;
            gmc2DefMaxST = 0;
            gmc2DefDR = 0;
            gmc2DefLuck = 0;
            gmc2DefCombatEXP = 0;
            gmc2DefSkillEXP = 0;

            gmc2DefAtkSpeed = 0;
            gmc2DefCastSpeed = 0;
            gmc2DefCrit = 0;
            gmc2DefGrapRes = 0;
            gmc2DefKFRes = 0;
            gmc2DefHidenAP = 0;
            gmc2DefMagicAP = 0;
            gmc2DefMelleAP = 0;
            gmc2DefRangedAP = 0;
        }

        public void CrysS1()
        {

            cResistIgnore -= smcIgnoreAll;
            cacc -= smcAccuracy;
            cedh -= smcDmgToHumans;
            cADtDemiH -= smcDmgToDemi;
            cWeight -= smcWeight;
            cRes1 -= smcAllRes;
            cRes2 -= smcAllRes;
            cRes3 -= smcAllRes;
            cRes4 -= smcAllRes;
            cMaxHP -= smcMaxHP;
            cMaxST -= smcMaxST;
            cDR -= smcDR;
            cluck -= smcLuck;
            cCombatExp -= smcCombatEXP;
            cSkillExp -= smcSkillEXP;

            cRes4 -= smcKFRes;
            cRes2 -= smcKBRes;
            cRes1 -= smcSSFRes;
            cmvs -= smcMVSpeed;
            cJump -= smcJump;
            cFallDamage -= smcFallDamage;
            cUnderwaterBreath -= smcUnderWaterBreath;
            cMaxEnergy -= smcMaxEnergy;
          






            smcAccuracy = smcDefAccuracy;
            smcDmgToHumans = smcDefDmgToHumans;
            smcDmgToDemi = smcDefDmgToDemi;
            smcWeight = smcDefWeight;
            smcAllRes = smcDefAllRes;
            smcMaxHP = smcDefMaxHP;
            smcMaxST = smcDefMaxST;
            smcDR = smcDefDR;
            smcLuck = smcDefLuck;
            smcCombatEXP = smcDefCombatEXP;
            smcSkillEXP = smcDefSkillEXP;
            smcIgnoreAll = smcDefIgnoreAll;



            smcKFRes = smcDefKFRes;
            smcKBRes = smcDefKBRes;
            smcSSFRes = smcDefSSFRes;
            smcMVSpeed = smcDefMVSpeed;
            smcJump = smcDefJump;
            smcFallDamage = smcDefFallDamage;
            smcUnderWaterBreath = smcDefUnderWaterBreath;
            smcMaxEnergy = smcDefMaxEnergy;


            cResistIgnore += smcIgnoreAll;
            cacc += smcAccuracy;
            cedh += smcDmgToHumans;
            cADtDemiH += smcDmgToDemi;
            cWeight += smcWeight;
            cRes1 += smcAllRes;
            cRes2 += smcAllRes;
            cRes3 += smcAllRes;
            cRes4 += smcAllRes;
            cMaxHP += smcMaxHP;
            cMaxST += smcMaxST;
            cDR += smcDR;
            cluck += smcLuck;
            cCombatExp += smcCombatEXP;
            cSkillExp += smcSkillEXP;


            cRes4 += smcKFRes;
            cRes2 += smcKBRes;
            cRes1 += smcSSFRes;
            cmvs += smcMVSpeed;
            cJump += smcJump;
            cFallDamage += smcFallDamage;
            cUnderwaterBreath += smcUnderWaterBreath;
            cMaxEnergy += smcMaxEnergy;
        }
        public void CrysS1Clear()
        {
         smcId = 0;
         smcType = "Shoes";
         smcDefIgnoreAll= 0;
         smcDefAccuracy= 0;
         smcDefDmgToHumans= 0;
         smcDefDmgToDemi= 0;
         smcDefWeight= 0;
         smcDefAllRes= 0;
         smcDefMaxHP= 0;
         smcDefMaxST= 0;
         smcDefDR= 0;
         smcDefLuck= 0;
         smcDefCombatEXP= 0;
         smcDefSkillEXP= 0;

         smcDefMVSpeed= 0;
         smcDefKBRes= 0;
         smcDefKFRes= 0;
         smcDefSSFRes= 0;
         smcDefJump= 0;
         smcDefFallDamage= 0;
         smcDefUnderWaterBreath= 0;
         smcDefMaxEnergy= 0;
    }

        public void CrysS2()
        {

            cResistIgnore -= smc2IgnoreAll;
            cacc -= smc2Accuracy;
            cedh -= smc2DmgToHumans;
            cADtDemiH -= smc2DmgToDemi;
            cWeight -= smc2Weight;
            cRes1 -= smc2AllRes;
            cRes2 -= smc2AllRes;
            cRes3 -= smc2AllRes;
            cRes4 -= smc2AllRes;
            cMaxHP -= smc2MaxHP;
            cMaxST -= smc2MaxST;
            cDR -= smc2DR;
            cluck -= smc2Luck;
            cCombatExp -= smc2CombatEXP;
            cSkillExp -= smc2SkillEXP;

            cRes4 -= smc2KFRes;
            cRes2 -= smc2KBRes;
            cRes1 -= smc2SSFRes;
            cmvs -= smc2MVSpeed;
            cJump -= smc2Jump;
            cFallDamage -= smc2FallDamage;
            cUnderwaterBreath -= smc2UnderWaterBreath;
            cMaxEnergy -= smc2MaxEnergy;







            smc2Accuracy = smc2DefAccuracy;
            smc2DmgToHumans = smc2DefDmgToHumans;
            smc2DmgToDemi = smc2DefDmgToDemi;
            smc2Weight = smc2DefWeight;
            smc2AllRes = smc2DefAllRes;
            smc2MaxHP = smc2DefMaxHP;
            smc2MaxST = smc2DefMaxST;
            smc2DR = smc2DefDR;
            smc2Luck = smc2DefLuck;
            smc2CombatEXP = smc2DefCombatEXP;
            smc2SkillEXP = smc2DefSkillEXP;
            smc2IgnoreAll = smc2DefIgnoreAll;


            smc2KFRes = smc2DefKFRes;
            smc2KBRes = smc2DefKBRes;
            smc2SSFRes = smc2DefSSFRes;
            smc2MVSpeed = smc2DefMVSpeed;
            smc2Jump = smc2DefJump;
            smc2FallDamage = smc2DefFallDamage;
            smc2UnderWaterBreath = smc2DefUnderWaterBreath;
            smc2MaxEnergy = smc2DefMaxEnergy;


            cResistIgnore += smc2IgnoreAll;
            cacc += smc2Accuracy;
            cedh += smc2DmgToHumans;
            cADtDemiH += smc2DmgToDemi;
            cWeight += smc2Weight;
            cRes1 += smc2AllRes;
            cRes2 += smc2AllRes;
            cRes3 += smc2AllRes;
            cRes4 += smc2AllRes;
            cMaxHP += smc2MaxHP;
            cMaxST += smc2MaxST;
            cDR += smc2DR;
            cluck += smc2Luck;
            cCombatExp += smc2CombatEXP;
            cSkillExp += smc2SkillEXP;


            cRes4 += smc2KFRes;
            cRes2 += smc2KBRes;
            cRes1 += smc2SSFRes;
            cmvs += smc2MVSpeed;
            cJump += smc2Jump;
            cFallDamage += smc2FallDamage;
            cUnderwaterBreath += smc2UnderWaterBreath;
            cMaxEnergy += smc2MaxEnergy;
        }
        public void CrysS2Clear()
        {
            smc2Id = 0;
            smc2Type = "Shoes";
            smc2DefIgnoreAll = 0;
            smc2DefAccuracy = 0;
            smc2DefDmgToHumans = 0;
            smc2DefDmgToDemi = 0;
            smc2DefWeight = 0;
            smc2DefAllRes = 0;
            smc2DefMaxHP = 0;
            smc2DefMaxST = 0;
            smc2DefDR = 0;
            smc2DefLuck = 0;
            smc2DefCombatEXP = 0;
            smc2DefSkillEXP = 0;

            smc2DefMVSpeed = 0;
            smc2DefKBRes = 0;
            smc2DefKFRes = 0;
            smc2DefSSFRes = 0;
            smc2DefJump = 0;
            smc2DefFallDamage = 0;
            smc2DefUnderWaterBreath = 0;
            smc2DefMaxEnergy = 0;
        }
    }
}
